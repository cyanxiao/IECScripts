using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 该组件用于保证玩家的子弹发射方向和摄像机一致
/// </summary>
public class PlayerBulletSpawnControl : MonoBehaviour
{
    public Transform spawnParent;
    private void Update()
    {
        if (spawnParent != null)
        {
            spawnParent.rotation = CameraCtrl.Instance.transform.rotation;
        }
    }
}
