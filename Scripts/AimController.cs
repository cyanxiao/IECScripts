using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Unit))]
public class AimController : MonoBehaviour
{
    /// <summary>
    /// 玩家
    /// </summary>
    private Unit unit;
    /// <summary>
    /// 连射型技能的追踪目标
    /// </summary>
    public Unit TargetForStrafeSkill
    {
        get
        {
            return CameraCtrl.Instance.GetClosestUnit();
        }
    }

    private Unit target = null;
    /// <summary>
    /// 点射型技能的追踪目标
    /// </summary>
    public Unit TargetForBurstfireSkill
    {
        get
        {
            return target;
        }

        private set
        {
            if (value == target)
            {
                TrackingAbilityBonus += Time.deltaTime / unit.SkillTable.CurrentSkill.Data.AimingTime * (GameDB.MAX_ACCURACY_BONUS - GameDB.MIN_ACCURACY_BONUS);
            }
            else
            {
                target = value;
                bonus = GameDB.MIN_ACCURACY_BONUS;
            }
        }
    }
    private float bonus = GameDB.MIN_ACCURACY_BONUS;
    /// <summary>
    /// 点射型技能的追踪能力加成
    /// </summary>
    public float TrackingAbilityBonus
    {
        get
        {
            return bonus;
        }
        set
        {
            bonus = Mathf.Clamp(value, GameDB.MIN_ACCURACY_BONUS, GameDB.MAX_ACCURACY_BONUS);
        }
    }
    private void Awake()
    {
        unit = GetComponent<Unit>();
    }


    // Update is called once per frame
    void Update()
    {
        switch (unit.SkillTable.CurrentSkill.Data.SkillType)
        {
            case SkillType.StrafeSkill:
                // do nothing
                break;
            case SkillType.BurstfireSkill:
                if (InputMgr.AimingButtonPressed)
                {
                    TargetForBurstfireSkill = CameraCtrl.Instance.GetClosestUnit();
                }
                break;
            case SkillType.ContinuousSkill:
                break;
        }
    }
}
