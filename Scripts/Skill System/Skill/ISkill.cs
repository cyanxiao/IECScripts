using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 该接口是技能接口，任何具体或抽象技能类都需要实现该接口。
/// 注意！！！
/// 具体技能类的名称必须为 Skill_技能名，这里的技能名必须和SkillName枚举中的技能名一致，
/// 否则无法通过技能名反射到对应的技能类。
/// </summary>
public interface ISkill
{
    /// <summary>
    /// 技能数据（只读）
    /// </summary>
    SkillData Data { get; }
    /// <summary>
    /// 触发技能效果
    /// </summary>
    void Trigger();
    /// <summary>
    /// 初始化技能
    /// </summary>
    /// <param name="caster">施法者，即技能的拥有者和释放着</param>
    void Init(Unit caster);
    /// <summary>
    /// 技能逐帧冷却
    /// </summary>
    /// <param name="dt">一帧的时长</param>
    void AccuracyCooldown(float dt);
}
