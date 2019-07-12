using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISkillTable
{
    /// <summary>
    /// 对玩家所控制的施法者和出生 Transform 初始化技能表
    /// </summary>
    /// <param name="caster">施法者 Unit</param>
    /// <param name="spawnTransform">出生位置的 Transform</param>
    void Init(Unit caster, Transform spawnTransform);
    /// <summary>
    /// 转换到玩家所选的技能
    /// </summary>
    /// <param name="info">键盘按下事件信息</param>
    void SwitchCell(EventMgr.KeyDownEventInfo info);
    /// <summary>
    /// 获得现在玩家技能的序号，可能是 1、2、3 号技能
    /// </summary>
    /// <returns>技能，1、2 或者 3 号技能</returns>
    ISkill CurrentSkill { get; }
}
