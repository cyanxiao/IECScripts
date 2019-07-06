using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCell : ISkillCell
{
    ISkill skill;

    public void OnMouseButtonDown()
    {

        throw new System.NotImplementedException();
    }

    public void OnMouseButtonUp()
    {
        throw new System.NotImplementedException();
    }

    public void SetSkill(ISkill skill)
    {
        this.skill = skill;
        throw new System.NotImplementedException();
    }
}
