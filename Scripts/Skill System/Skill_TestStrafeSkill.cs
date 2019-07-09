using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_TestStrafeSkill : AbstractStrafeSkill
{
    protected override void LoadData()
    {
        Data = Gamef.LoadSkillData(SkillName.TestStrafeSkill);
    }

    protected override void Shoot()
    {
        Debug.Log("Release Strafe Skill");
    }
}
