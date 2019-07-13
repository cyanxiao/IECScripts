using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractStrafeSkill : ISkill
{
    public SkillData Data { get; protected set; }
    // 施法者
    protected Unit Caster { get; private set; }
    // 技能特效产生位置
    protected Transform SpawnTransform { get; private set; }

    /// <summary>
    /// 根据具体技能，读取对应的技能数据。
    /// </summary>
    protected abstract void LoadData();

    /// <summary>
    /// 开始释放连射型技能
    /// </summary>
    protected abstract void Shoot();

    public void Init(Unit caster, Transform transform)
    {
        this.Caster = caster;
        this.SpawnTransform = transform;
        LoadData();
    }

    public void Trigger()
    {
        Shoot();
    }
}
