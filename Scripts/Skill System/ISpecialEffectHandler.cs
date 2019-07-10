using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpecialEffectHandler
{
    /// <summary>
    /// 创建一个指定 Missile 的出生特效
    /// </summary>
    /// <param name="caster">该 Missile 的施放者</param>
    /// <param name="missile">指定的 Missile 对象</param>
    /// <param name="prefab">特效的 prefab</param>
    /// <param name="pos">创建特效位置</param>
    void CreateSpawnEffect(Unit caster, Missile missile, GameObject prefab, Vector3 pos);

    /// <summary>
    /// 创建一个指定 Missile 的死亡特效
    /// </summary>
    /// <param name="caster">该 Missile 的施放者</param>
    /// <param name="missile">指定的 Missile 对象</param>
    /// <param name="prefab">特效的 prefab</param>
    /// <param name="pos">创建特效位置</param>
    void CreateDestroyEffect(Unit caster, Missile missile, GameObject prefab, Vector3 pos);
}
