using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IReusableClass
{
    void Reset(params object[] Params);
}

public class ClassCache
{
    private static Dictionary<Type, Stack<IReusableClass>> typeDict = new Dictionary<Type, Stack<IReusableClass>>();

    public static void DestroyInstance(IReusableClass obj)
    {
        if (!typeDict.ContainsKey(obj.GetType()))
            typeDict.Add(obj.GetType(), new Stack<IReusableClass>());
        Stack<IReusableClass> stack = typeDict[obj.GetType()];
        lock (stack)
        {
            stack.Push(obj);
        }
    }


    public static T CreateInstance<T>(params object[] Params)
    {
        Type type = typeof(T);
        IReusableClass res;
        if (!typeof(IReusableClass).IsAssignableFrom(type))
        {
            Debug.LogError("类缓存只可以存储可重置的类");
            return default(T);
        }
        //如果还没记入字典，直接返回新建实例
        if (!typeDict.ContainsKey(type))
        {
            typeDict.Add(type, new Stack<IReusableClass>());
            return (T)Activator.CreateInstance(type, Params);
        }
        Stack<IReusableClass> stack = typeDict[type];
        lock (stack)
        {
            //如果栈不空，将栈顶实例重置并返回
            if (stack.Count > 0)
            {
                res = stack.Pop();
                if (res == null)
                {
                    Debug.LogError("存储在缓存中的类被销毁了");
                    return (T)Activator.CreateInstance(type, Params);
                }
                res.Reset(Params);
                return (T)res;
            }
            //否则返回新建实例
            else
            {
                return (T)Activator.CreateInstance(type, Params);
            }
        }
    }

}


public partial class Gamef
{
    public static void DestroyInstance(IReusableClass obj)
    {
        ClassCache.DestroyInstance(obj);
    }

    public static T CreateInstance<T>(params object[] Params)
    {
        return ClassCache.CreateInstance<T>(Params);
    }
}