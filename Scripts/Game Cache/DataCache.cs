using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataCache<T, V>
{
    public const int MIN_BUFF_SIZE = 2;
    public const int MAX_BUFF_SIZE = 25;
    private const int INF = int.MaxValue;
    
    private struct Cell
    {
        public T Object;
        public V Tag;
        public int LRU;
        public bool IsValid;
    }
    private Cell[] dataCells;

    public DataCache(int buffSize)
    {
        if (typeof(T) != typeof(BuffData) && typeof(T) != typeof(SkillData) && typeof(T) != typeof(UnitData))
        {
            Debug.LogError("数据类型[" + typeof(T) + "]不满足数据缓存条件");
            return;
        }
        if (typeof(V) != typeof(BuffName) && typeof(V) != typeof(SkillName) && typeof(V) != typeof(UnitName))
        {
            Debug.LogError("标签类型[" + typeof(V) + "]不满足数据缓存条件");
            return;
        }
        if (typeof(T) == typeof(BuffData))
        {
            getData = getBuffData;
        }
        else if (typeof(T) == typeof(SkillData))
        {
            getData = getSkillData;
        }
        else if (typeof(T) == typeof(UnitData))
        {
            getData = getUnitData;
        }
        buffSize = Mathf.Clamp(buffSize, MIN_BUFF_SIZE, MAX_BUFF_SIZE);
        dataCells = new Cell[buffSize];
        for (int i = 0; i < buffSize; i++)
        {
            dataCells[i].IsValid = false;
        }
    }

    Type IntType = typeof(int);
    public T LoadData(V tag)
    {
        object tmp;
        int tagInt = (int)(tmp = tag);
        Debug.Log("尝试读取：" + tag.ToString());
        int index = -1, minLRU = INF;
        bool findFlag = false, evictFlag = true;
        T res = default(T);
        for (int i = 0; i < dataCells.Length; i++)
        {
            //如果不为空
            if (dataCells[i].IsValid)
            {
                //如果标签一致
                if (dataCells[i].Tag.Equals(tag))
                {
                    findFlag = true;
                    res = dataCells[i].Object;
                    dataCells[i].LRU = INF;
                    Debug.Log("缓存命中！！！");
                }
                //标签不一致
                else
                {
                    //LRU减一
                    dataCells[i].LRU--;
                    //如果需要evict并且没有find，则需要搜索最小LRU
                    if (evictFlag && !findFlag && minLRU > dataCells[i].LRU)
                    {
                        minLRU = dataCells[i].LRU;
                        index = i;
                    }
                }
            }
            //单元格为空时，如果需要evict，则记录该空格为可替换的空格
            else if (evictFlag && !findFlag)
            {
                evictFlag = false;
                index = i;
            }
        }

        if (!findFlag)
        {
            if (evictFlag)
            {
                Debug.Log("冲突不命中");
            }
            else
                Debug.Log("冷不命中");
            dataCells[index].IsValid = true;
            dataCells[index].LRU = INF;
            dataCells[index].Tag = tag;
            dataCells[index].Object = getData(tagInt);
            res = dataCells[index].Object;
        }
        return res;
    }

    private delegate T GetDataHandler(int tagInt);

    private GetDataHandler getData;

    private T getSkillData(int tagInt)
    {
        object tmp;
        return (T)(tmp = Resources.Load(GameDB.Instance.skillDataPath.paths[tagInt]));
    }

    private T getBuffData(int tagInt)
    {
        object tmp;
        return (T)(tmp = Resources.Load(GameDB.Instance.buffDataPath.paths[tagInt]));
    }

    private T getUnitData(int tagInt)
    {
        object tmp;
        return (T)(tmp = Resources.Load(GameDB.Instance.unitDataPath.paths[tagInt]));
    }

}

public class DataCacheForBuff
{
    public const int MIN_BUFF_SIZE = 2;
    public const int MAX_BUFF_SIZE = 25;
    private const int INF = int.MaxValue;

    private struct Cell
    {
        public BuffData Object;
        public BuffName Tag;
        public int LRU;
        public bool IsValid;
    }
    private Cell[] dataCells;

    public DataCacheForBuff(int buffSize)
    {
        buffSize = Mathf.Clamp(buffSize, MIN_BUFF_SIZE, MAX_BUFF_SIZE);
        dataCells = new Cell[buffSize];
        for (int i = 0; i < buffSize; i++)
        {
            dataCells[i].IsValid = false;
        }
    }


    public BuffData LoadData(BuffName tag)
    {;
        Debug.Log("尝试读取：" + tag.ToString());
        int index = -1, minLRU = INF;
        bool findFlag = false, evictFlag = true;
        BuffData res = null;
        for (int i = 0; i < dataCells.Length; i++)
        {
            //如果不为空
            if (dataCells[i].IsValid)
            {
                //如果标签一致
                if (dataCells[i].Tag == tag)
                {
                    findFlag = true;
                    res = dataCells[i].Object;
                    dataCells[i].LRU = INF;
                    Debug.Log("缓存命中！！！");
                }
                //标签不一致
                else
                {
                    //LRU减一
                    dataCells[i].LRU--;
                    //如果需要evict并且没有find，则需要搜索最小LRU
                    if (evictFlag && !findFlag && minLRU > dataCells[i].LRU)
                    {
                        minLRU = dataCells[i].LRU;
                        index = i;
                    }
                }
            }
            //单元格为空时，如果需要evict，则记录该空格为可替换的空格
            else if (evictFlag && !findFlag)
            {
                evictFlag = false;
                index = i;
            }
        }

        if (!findFlag)
        {
            if (evictFlag)
            {
                Debug.Log("冲突不命中");
            }
            else
                Debug.Log("冷不命中");
            dataCells[index].IsValid = true;
            dataCells[index].LRU = INF;
            dataCells[index].Tag = tag;
            dataCells[index].Object = Resources.Load<BuffData>(GameDB.Instance.buffDataPath.paths[(int)tag]);
            res = dataCells[index].Object;
        }
        return res;
    }
}


public partial class Gamef
{
    public const int BUFF_DATA_CACHE_SIZE = 6;
    public const int SKILL_DATA_CACHE_SIZE = 8;
    public const int UNIT_DATA_CACHE_SIZE = 6;

    public static DataCacheForBuff buffCache_StandAlone = new DataCacheForBuff(BUFF_DATA_CACHE_SIZE);

    private static DataCache<BuffData, BuffName> buffCache = new DataCache<BuffData, BuffName>(BUFF_DATA_CACHE_SIZE);
    private static DataCache<SkillData, SkillName> skillCache = new DataCache<SkillData, SkillName>(SKILL_DATA_CACHE_SIZE);
    private static DataCache<UnitData, UnitName> unitCache = new DataCache<UnitData, UnitName>(UNIT_DATA_CACHE_SIZE);
}