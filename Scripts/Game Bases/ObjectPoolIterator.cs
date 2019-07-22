using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Object Pool的迭代器
/// </summary>
/// <typeparam name="T"></typeparam>
public class ObjectPoolEnumerator<T> : IEnumerator<T>
{
    public T Current => currentID == -1 ? default : pool.GetObject(currentID);
    ObjectPool<T> pool;
    // 当前的物体在池中的ID。-1，表示当前物体为空。
    int currentID = -1;
    object IEnumerator.Current => currentID;

    public ObjectPoolEnumerator(ObjectPool<T> pool)
    {
        this.pool = pool;
        Reset();
    }

    public void Dispose()
    {
        pool = null;
    }

    public bool MoveNext()
    {
        int n = pool.MaxLength;
        for (int i = currentID + 1; i < n; i++)
        {
            if (pool.CheckID(i))
            {
                currentID = i;
                UnityEngine.Debug.Log("Move Iterator to " + i);
                return true;
            }
        }
        return false;
    }

    public void Reset()
    {
        currentID = -1;
        int n = pool.MaxLength;
        for (int i = 0; i < n; i++)
        {
            if (pool.CheckID(i))
            {
                currentID = i;
                UnityEngine.Debug.Log("Reset Iterator to " + i);
                break;
            }
        }
        UnityEngine.Debug.Log("No Unit");
    }
}