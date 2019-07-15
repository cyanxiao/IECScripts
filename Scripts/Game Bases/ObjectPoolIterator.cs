using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Object Pool的迭代器
/// </summary>
/// <typeparam name="T"></typeparam>
public class ObjectPoolEnumerator<T> : IEnumerator<T>
{
    public T Current => pool.GetObject(currentID);
    ObjectPool<T> pool;
    int currentID = -1;
    object IEnumerator.Current => currentID;

    public ObjectPoolEnumerator(ObjectPool<T> pool)
    {
        this.pool = pool;
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
                return true;
            }
        }
        return false;
    }

    public void Reset()
    {
        int n = pool.MaxLength;
        for (int i = 0; i < n; i++)
        {
            if (pool.CheckID(i))
            {
                currentID = i;
                break;
            }
        }
    }
}