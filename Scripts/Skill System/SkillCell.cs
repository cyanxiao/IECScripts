using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 这个类表示一个技能槽位。
/// 该类需要通过Skill Table调用ISkillCell.Init()进行初始化。初始化只需要进行一次。
/// 
/// 该类通过实现OnMouseButtonDown和OnMouseButtonUp实现对3种类型的技能的调用（不负责技能实现），包括计算CD和开火频率等等。
/// 同时，施法扣除法力值也由该类实现。
/// </summary>
public class SkillCell : ISkillCell
{
    ISkill skill;
    bool isCasting = false;
    Unit caster;
    Transform spawnTransform;

    readonly object mutex = new object();

    
    public void SetSkill(ISkill skill)
    {
        this.skill = skill;
        skill.Init(caster, spawnTransform);
        switch (skill.Data.SkillType)
        {
            case SkillType.StrafeSkill:
                cooldown = 60f / skill.Data.RPM;
                break;

            case SkillType.BurstfireSkill:
                cooldown = skill.Data.Cooldown;
                break;

            case SkillType.ContinuousSkill:
                cooldown = skill.Data.Cooldown;
                break;

            default:
                break;
        }
    }
    
    public void Init(Unit caster, Transform spawnTransform)
    {
        this.caster = caster;
        this.spawnTransform = spawnTransform;
        EventMgr.UpdateEvent.AddListener(Update);
    }

    float timer = 0f;
    float cooldown;
    public void OnMouseButtonDown()
    {
        StartCasting();
    }

    public void OnMouseButtonUp()
    {
        StopCasting();
    }
    
    private void StartCasting()
    {
        // 如果不在施法且冷却完毕，则进行施法
        lock (mutex)
        {
            if (isCasting)
            {
                return;
            }
            if (timer > 1e-5f)
            {
                return;
            }
            isCasting = true;
        }

        switch (skill.Data.SkillType)
        {
            case SkillType.StrafeSkill:
                timer = 0f;
                EventMgr.UpdateEvent.AddListener(Strafe);
                break;

            case SkillType.BurstfireSkill:
                if (Cast())
                {
                    StopCasting();
                }
                else
                {
                    // prompt
                }
                break;

            case SkillType.ContinuousSkill:
                if (Cast())
                {
                    StopCasting();
                }
                else
                {
                    // prompt
                }
                break;

            default:
                break;
        }
    }

    private void StopCasting()
    {
        // 如果不在施法，则进行施法
        lock (mutex)
        {
            if (!isCasting)
            {
                return;
            }
            isCasting = false;
        }

        switch (skill.Data.SkillType)
        {
            case SkillType.StrafeSkill:
                EventMgr.UpdateEvent.RemoveListener(Strafe);
                break;

            case SkillType.BurstfireSkill:
                timer = cooldown;
                break;

            case SkillType.ContinuousSkill:
                timer = cooldown;
                break;

            default:
                break;
        }
    }

    private void Update()
    {
        // 技能冷却
        if (!isCasting)
        {
            // 计时器倒计时
            if (timer > 1e-5f)
            {
                timer -= Time.deltaTime;
                // 如果数过了，归零
                if (timer < -1e-5f)
                {
                    timer = 0f;
                }
            }
        }
    }

    private void Strafe()
    {
        timer -= Time.deltaTime;
        // 每隔duration触发一次
        if (timer < 1e-5f)
        {
            timer += cooldown;
            if (!Cast())
            {
                StopCasting();
            }
        }
    }

    /// <summary>
    /// 进行施法。要求施法者存活且法力充足。
    /// </summary>
    /// <returns>施法成功，返回真；否则，返回假。</returns>
    private bool Cast()
    {
        if (caster.attributes.isAlive && caster.attributes.ManaPoint.Value >= skill.Data.ManaCost)
        {
            caster.attributes.ManaPoint.Value -= skill.Data.ManaCost;
            skill.Trigger();
            return true;
        }
        else
        {
            return false;
        }
    }
}
