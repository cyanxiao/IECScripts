using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMissileHitHandler
{
    /// <summary>
    /// 投掷物撞到地形。
    /// </summary>
    /// <param name="self">投掷物</param>
    void HitTerrain(Missile self);

    /// <summary>
    /// 投掷物撞到其他投掷物。
    /// </summary>
    /// <param name="self">投掷物</param>
    /// <param name="other">其他投掷物</param>
    void HitMissile(Missile self, Missile other);

    /// <summary>
    /// 投掷物撞到单位。
    /// </summary>
    /// <param name="self">投掷物</param>
    /// <param name="unit">单位</param>
    void HitUnit(Missile self, Unit unit);

    /// <summary>
    /// 投掷物死亡。投掷物在到达一定时限或者被HP归零后会死亡。
    /// </summary>
    /// <param name="self">投掷物</param>
    void Fade(Missile self);
}
