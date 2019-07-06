using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 技能槽位
/// </summary>
public interface ISkillCell
{
    /// <summary>
    /// 当鼠标左键被按下
    /// </summary>
    void OnMouseButtonDown();
    /// <summary>
    /// 当鼠标左键被松开
    /// </summary>
    void OnMouseButtonUp();
    /// <summary>
    /// 将当前的技能槽位中的技能设置为skill
    /// </summary>
    /// <param name="skill">技能</param>
    void SetSkill(ISkill skill);
}
