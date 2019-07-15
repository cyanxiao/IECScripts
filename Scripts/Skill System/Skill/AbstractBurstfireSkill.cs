using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractBurstfireSkill : ISkill
{
    public SkillData Data { get; protected set; }
    // 施法者
    protected Unit Caster { get; private set; }
    // 技能特效产生位置
    protected Transform SpawnTransform { get; private set; }

    /// <summary>
    /// 释放一次单发型技能
    /// </summary>
    protected abstract void Shoot();

    /// <summary>
    /// 根据具体技能，读取对应的技能数据。
    /// </summary>
    protected abstract void LoadData();

    public void Init(Unit caster)
    {
        this.Caster = caster;
        this.SpawnTransform = caster.SpawnTransform;
        LoadData();
    }

    public void Trigger()
    {
        Shoot();
    }

    public abstract void AccuracyCooldown(float dt);
}
