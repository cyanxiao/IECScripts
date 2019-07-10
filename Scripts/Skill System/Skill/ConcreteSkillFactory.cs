using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ConcreteSkillFactory
{
    private static Dictionary<SkillName, Type> skillDict = new Dictionary<SkillName, Type>();
    /// <summary>
    /// 通过技能名创建对应的技能类的实例
    /// </summary>
    /// <param name="name">技能名</param>
    /// <returns>对应的技能类的实例</returns>
    public static ISkill CreateSkill(SkillName name)
    {
        if (!isInit)
        {
            Init();
        }

        if (skillDict.ContainsKey(name))
        {
            Type type = skillDict[name];
            return (ISkill)Activator.CreateInstance(type);
        }
        UnityEngine.Debug.Log("No class for skill named :" + name.ToString());
        return null;
    }


    private static bool isInit = false;
    private static object mutex = new object();
    private static void Init()
    {
        lock (mutex)
        {
            if (isInit)
            {
                return;
            }
            isInit = true;
        }
        foreach (SkillName name in Enum.GetValues(typeof(SkillName)))
        {
            Type type = Type.GetType("Skill_" + name.ToString());
            if (type == null)
            {
                UnityEngine.Debug.Log("No class for skill named :" + name.ToString());
                continue;
            }
            skillDict.Add(name, type);
        }
    }
}
