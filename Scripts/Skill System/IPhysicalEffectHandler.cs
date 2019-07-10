using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPhysicalEffectHandler
{
    /// <summary>
    /// 创建一个发生于指定位置的爆炸力
    /// </summary>
    /// <param name="data">产生爆炸的技能数据</param>
    /// <param name="position">产生爆炸的位置</param>
    void CreateExplosiveForce(SkillData data, Vector3 position);

    /// <summary>
    /// 创建一个对 GameObject 产生的冲击力
    /// </summary>
    /// <param name="data">产生冲击力的技能数据</param>
    /// <param name="position">施力点</param>
    /// <param name="direction">施力方向</param>
    /// <param name="rigidbody">目标刚体</param>
    void CreateImpulse(SkillData data, Vector3 position, Vector3 direction, Rigidbody rigidbody);
}
