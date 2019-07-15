using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTable : ISkillTable
{
    // 第 0，1，2 格技能为可切换技能，3 格技能为持续型技能
    public ISkillCell[] SkillCells = new SkillCell[4];
    private int currentSkillNum = 1;
    // Test Needed
    private Unit caster;

    public ISkill CurrentSkill => SkillCells[currentSkillNum - 1].CurrentSkill;

    public void Init(Unit caster)
    {
        // Test Needed
        this.caster = caster;

        for (int i = 0; i < 4; i++)
        {
            SkillCells[i] = new SkillCell();
            SkillCells[i].Init(caster);
            // 设置初始技能
            ISkill tmpSkill = ConcreteSkillFactory.CreateSkill(caster.attributes.data.skills[i]);
            if (tmpSkill != null)
            {
                SkillCells[i].CurrentSkill = tmpSkill;
            }
        }

        EventMgr.KeyDownEvent.AddListener(SwitchCell);
        EventMgr.MouseButtonDownEvent.AddListener(CellMouseBTNDown);
        EventMgr.MouseButtonUpEvent.AddListener(CellMouseBTNUp);
    }

    public void SwitchCell(EventMgr.KeyDownEventInfo info)
    {
        // 判定切换前技能是否与切换后技能相同，如果不同则为 true，即可以重置精确度
        bool flag = false;
        switch (info.keyCode)
        {
            case KeyCode.Alpha1:
                // 如果切换前的技能还在施放，应该立即停止该技能
                if (currentSkillNum != 1)
                {
                    SkillCells[currentSkillNum].ForceToStopCasting();
                    flag = true;
                } 
                currentSkillNum = 1;
                if(flag)
                    SetUnitInitAccuracy(SkillCells[currentSkillNum].CurrentSkill.Data.Accuracy);
                flag = false;
                Debug.Log("切换至技能 1");
                break;
            case KeyCode.Alpha2:
                if (currentSkillNum != 2)
                    SkillCells[currentSkillNum].ForceToStopCasting();
                currentSkillNum = 2;
                if (flag)
                    SetUnitInitAccuracy(SkillCells[currentSkillNum].CurrentSkill.Data.Accuracy);
                flag = false;
                Debug.Log("切换至技能 2");
                break;
            case KeyCode.Alpha3:
                if (currentSkillNum != 3)
                    SkillCells[currentSkillNum].ForceToStopCasting();
                currentSkillNum = 3;
                if (flag)
                    SetUnitInitAccuracy(SkillCells[currentSkillNum].CurrentSkill.Data.Accuracy);
                flag = false;
                Debug.Log("切换至技能 3");
                break;
        }
    }

    private void CellMouseBTNDown(EventMgr.MouseButtonDownEventInfo info)
    {
        SkillCells[currentSkillNum - 1].OnMouseButtonDown();
    }

    private void CellMouseBTNUp(EventMgr.MouseButtonUpEventInfo info)
    {
        SkillCells[currentSkillNum - 1].OnMouseButtonUp();
    }

    private void SetUnitInitAccuracy(float accuracy)
    {
        caster.RuntimeAccuracy = accuracy * GameDB.INITIAL_ACCURACY;
    }
}

public partial class GameCtrl
{
    private void CheckInputForSkillTable()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            EventMgr.KeyDownEvent.OnTrigger(new EventMgr.KeyDownEventInfo(KeyCode.Alpha1));
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            EventMgr.KeyDownEvent.OnTrigger(new EventMgr.KeyDownEventInfo(KeyCode.Alpha2));
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            EventMgr.KeyDownEvent.OnTrigger(new EventMgr.KeyDownEventInfo(KeyCode.Alpha3));
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            EventMgr.MouseButtonDownEvent.OnTrigger(new EventMgr.MouseButtonDownEventInfo(0));
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            EventMgr.MouseButtonUpEvent.OnTrigger(new EventMgr.MouseButtonUpEventInfo(0));
        }
    }
}