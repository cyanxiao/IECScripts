using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTable : ISkillTable
{
    // 第 0，1，2 格技能为可切换技能，3 格技能为持续型技能
    public ISkillCell[] SkillCells = new SkillCell[4];
    private int currentSkillNum = 1;

    public void Init(Unit caster, Transform spawnTransform)
    {
        for (int i = 0; i < 4; i++)
        {
            SkillCells[i] = new SkillCell();
            SkillCells[i].Init(caster, spawnTransform);
        }

        EventMgr.KeyDownEvent.AddListener(SwitchCell);
    }

    public void SwitchCell(EventMgr.KeyDownEventInfo info)
    {
        switch (info.keyCode)
        {
            case KeyCode.Alpha1:
                currentSkillNum = 1;
                Debug.Log("1");
                break;
            case KeyCode.Alpha2:
                currentSkillNum = 2;
                Debug.Log("2");
                break;
            case KeyCode.Alpha3:
                currentSkillNum = 3;
                Debug.Log("3");
                break;
        }
    }

    public int GetCurrentSkill()
    {
        return currentSkillNum;
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
    }
}