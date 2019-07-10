using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpecialEffectHandler
{
    /// <summary>
    /// 创建一个特效
    /// </summary>
    /// <param name="prefab">特效的 prefab</param>
    /// <param name="transform">创建特效位置</param>
    void CreateSpecialEffect(GameObject prefab, Transform transform);
}
