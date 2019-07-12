using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_TestBurstfireSkill : AbstractBurstfireSkill
{
    protected override void LoadData()
    {
        Data = Gamef.LoadSkillData(SkillName.TestBurstfireSkill);
    }

    protected override void Shoot()
    {
        Debug.Log("Release a single burst fire skill.");
    }
}
