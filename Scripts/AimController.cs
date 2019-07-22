using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Unit))]
public class AimController : MonoBehaviour
{
    public static AimController Instance { get; private set; }
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
                AimingTime += Time.deltaTime;
            }
            else
            {
                target = value;
                AimingTime = 0f;
            }
        }
    }

    /// <summary>
    /// 点射型技能的已瞄准时间
    /// </summary>
    public float AimingTime
    {
        get;
        private set;
    }
    private void Awake()
    {
        Instance = this;
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
