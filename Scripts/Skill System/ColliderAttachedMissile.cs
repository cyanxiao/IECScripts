using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 放在Collider上，用于指定碰撞体(Collier)所附着的Missile组件或Unit组件
/// </summary>
public class ColliderAttachedMissileOrUnit : MonoBehaviour
{
    public Missile missile;
    public Unit unit;
    public bool isMissile = true;
}
