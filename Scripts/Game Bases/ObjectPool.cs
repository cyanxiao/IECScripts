using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

public class ObjectPool<T> : IEnumerable<T>
{
    public const int BLK_LENGTH = 1 << 8;
    public const int BLK_MASK = ~0xff;
    public const int OFFSET_MASK = 0xff;
    public struct Cell
    {
        public T content;
        public bool isValid;
    }

    List<Cell[]> blkList = new List<Cell[]>();
    // 最大可能的ID（实际上，最大ID应当小于MaxLength）
    public int MaxLength { get; private set; } = 0;

    //存储已经不被占用的id（即对象被清除）
    Queue<int> idQueue = new Queue<int>();
    /// <summary>
    /// 给对象分配ID
    /// </summary>
    /// <param name="obj">目标对象</param>
    /// <returns>对象ID</returns>
    public int IDAlloc(T obj)
    {
        lock (blkList)
        {
            int res = -1;
            if (idQueue.Count > 0)
                res = idQueue.Dequeue();
            else
            {
                res = MaxLength++;
                //如果超负荷，则申请一个新的数组
                if ((res & BLK_MASK) >= blkList.Count)
                {
                    ExtendPool();
                }
            }
            blkList[res & BLK_MASK][res & OFFSET_MASK] = new Cell()
            {
                isValid = true,
                content = obj,
            };
            Debug.Log("Add " + typeof(T).ToString() + " to blk " + (res & BLK_MASK) + ", cell " + (res & OFFSET_MASK));
            return res;
        }
    }
    /// <summary>
    /// 获取ID对应对象
    /// </summary>
    /// <param name="id">对象ID</param>
    /// <returns>对象</returns>
    public T GetObject(int id)
    {
        return blkList[id & BLK_MASK][id & OFFSET_MASK].content;
    }
    /// <summary>
    /// 检查ID是否被占用
    /// </summary>
    /// <param name="id">对象ID</param>
    /// <returns>是否被占用</returns>
    public bool CheckID(int id)
    {
        return blkList[id & BLK_MASK][id & OFFSET_MASK].isValid;
    }
    /// <summary>
    /// 移除对象
    /// </summary>
    /// <param name="id">对象ID</param>
    public void RemoveObject(int id)
    {
        lock (blkList)
        {
            blkList[id & ~0xff][id & 0xff].isValid = false;
            idQueue.Enqueue(id);
        }
    }

    public ObjectPool()
    {
        ExtendPool();
    }

    private void ExtendPool()
    {
        Cell[] cells = new Cell[BLK_LENGTH];
        for (int i = 0; i < BLK_LENGTH; i++)
        {
            cells[i].isValid = false;
        }
        blkList.Add(cells);
    }

    public delegate void TraversalHandler(T obj);
    /// <summary>
    /// 遍历所有池中对象
    /// </summary>
    /// <param name="handler"></param>
    public void Traversal(TraversalHandler handler)
    {
        foreach (Cell[] cells in blkList)
        {
            for (int i = 0; i < BLK_LENGTH; i++)
            {
                if (cells[i].isValid)
                {
                    handler(cells[i].content);
                }
            }
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new ObjectPoolEnumerator<T>(this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return new ObjectPoolEnumerator<T>(this);
    }
}