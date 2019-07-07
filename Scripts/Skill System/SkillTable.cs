using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTable : iSkillTable
{
    // 第 0，1，2 格技能为可切换技能，3 格技能为持续型技能
    public ISkillCell[] SkillCell { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public void Init()
    {
        //EventMgr.KeyDownEvent.OnTrigger();
    }

    public int SwitchCell()
    {
        throw new System.NotImplementedException();
    }

}
