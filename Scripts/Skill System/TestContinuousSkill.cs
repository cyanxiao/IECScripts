using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 这个类是对持续型技能及其抽象父类的测试，只有log功能。
/// </summary>
public class TestContinuousSkill : AbstractContinuousSkill
{
    protected override void LoadData()
    {
        Data = Gamef.LoadSkillData(SkillName.TestContinuousSkill);
    }

    protected override void Start()
    {
        Debug.Log("啊哈，您成功释放了一个持续型技能！");
    }

    protected override void Stop()
    {
        Debug.Log("哦豁，您成功停止了一个持续型技能！");
    }
}


