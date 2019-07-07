using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface iSkillTable
{
    // 第 0，1，2 格技能为可切换技能，3 格技能为持续型技能
    ISkillCell[] SkillCell { get; set; }

    int SwitchCell();
}
