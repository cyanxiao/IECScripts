using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PrefabName
{
    EmptyObject = 0,
    Fireball = 1,
    黑魔爆球 = 2,
    FireballDeathEffect,
}

public class GameObjectCache
{
    private const int PREFAB_NUM = 8;
    private const int MAX_STACK_SIZE = 15;
    private const float STACK_DUMP_DELAY = 120;
    private const float DESTROY_DELAY = 1f;
    private struct CacheBlock
    {
        public Stack<GameObject> objStack;
        public float prevAccessedTime;
    }

    private static CacheBlock[] blocks = new CacheBlock[PREFAB_NUM];

    static bool isInit = false;
    public static void Init()
    {
        if (isInit)
            return;
        isInit = true;
        for (int i = 0; i < PREFAB_NUM; i++)
        {
            blocks[i].objStack = new Stack<GameObject>();
            blocks[i].prevAccessedTime = Time.time;
        }
    }

    public static void Instantiate(GameObject gameObject)
    {
        Instantiate(gameObject, gameObject.transform.position, gameObject.transform.rotation, null);
    }

    public static void Instantiate(GameObject gameObject, Transform parent)
    {
        Instantiate(gameObject, gameObject.transform.position, gameObject.transform.rotation, parent);
    }

    public static void Instantiate(GameObject gameObject, Vector3 position, Quaternion rotation)
    {
        Instantiate(gameObject, position, rotation, null);
    }

    public static GameObject Instantiate(GameObject gameObject, Vector3 position, Quaternion rotation, Transform parent)
    {
        GameObject res = null;
        ReusablePrefab reusablePrefab = gameObject.GetComponent<ReusablePrefab>();
        if (reusablePrefab == null)
        {
            res = Object.Instantiate(gameObject, position, rotation, parent);
            return res;
        }
        int index = (int)reusablePrefab.Prefab;
        //命中
        lock (blocks[index].objStack)
        {
            if (blocks[index].objStack.Count > 0)
            {
                GameObject obj = blocks[index].objStack.Pop();
                obj.transform.SetPositionAndRotation(position, rotation);
                obj.transform.SetParent(parent);
                obj.SetActive(true);
                res = obj;
                blocks[index].prevAccessedTime = Time.time;
            }
            //不命中
            else
            {
                res = Object.Instantiate(gameObject, position, rotation, parent);
            }
        }
        return res;
    }

    public static void Destroy(GameObject gameObject)
    {
        ReusablePrefab reusablePrefab = gameObject.GetComponent<ReusablePrefab>();
        gameObject.SetActive(false);
        if (reusablePrefab == null)
        {
            Object.Destroy(gameObject, DESTROY_DELAY);
            return;
        }
        int index = (int)reusablePrefab.Prefab;
        lock (blocks[index].objStack)
        {
            blocks[index].objStack.Push(gameObject);
            blocks[index].prevAccessedTime = Time.time;
            gameObject.transform.SetParent(GameDB.Instance.ReusableObjectPool);
        }
    }
}

public partial class Gamef
{
    public static GameObject Instantiate(GameObject gameObject)
    {
        return Instantiate(gameObject, gameObject.transform.position, gameObject.transform.rotation, null);
    }

    public static GameObject Instantiate(GameObject gameObject, Transform parent)
    {
        return Instantiate(gameObject, gameObject.transform.position, gameObject.transform.rotation, parent);
    }

    public static GameObject Instantiate(GameObject gameObject, Vector3 position, Quaternion rotation)
    {
        return Instantiate(gameObject, position, rotation, null);
    }

    public static GameObject Instantiate(GameObject gameObject, Vector3 position, Quaternion rotation, Transform parent)
    {
        return GameObjectCache.Instantiate(gameObject, position, rotation, parent);
    }

    public static void Destroy(GameObject gameObject)
    {
        GameObjectCache.Destroy(gameObject);
    }
}