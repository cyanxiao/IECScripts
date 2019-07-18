using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackSystem : MonoBehaviour
{
    /// <summary>
    /// 需要被追踪的目标（只能是 Unit）
    /// </summary>
    public Unit enemy;

    /// <summary>
    /// Missile 速度
    /// </summary>
    public float speed = 15;
    public float rotationSpeed;
    /// <summary>
    /// 最远追踪距离（目标与 Missile 距离）
    /// </summary>
    public float focusDistance = 5;

    /// <summary>
    /// 目标的 Transform
    /// </summary>
    public Transform target;

    
    bool isFollowingTarget = true;
    string targetTag;
    /// <summary>
    /// 是否一直面向目标
    /// </summary>
    bool faceTarget;
    Vector3 tempVector;

    private void Start()
    {
        // 可能需要重写
        target = enemy.gameObject.transform;
    }

    private void Update()
    {

        if (Vector3.Distance(transform.position, target.position) < focusDistance)
        {
            isFollowingTarget = false;
        }

        Vector3 targetDirection = target.position - transform.position;

        if (faceTarget)
        {
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, rotationSpeed * Time.deltaTime, 0.0F);

            MoveForward(Time.deltaTime);

            if (isFollowingTarget)
            {
                transform.rotation = Quaternion.LookRotation(newDirection);
            }
        }

        else
        {
            if (isFollowingTarget)
            {
                tempVector = targetDirection.normalized;

                transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(tempVector * Time.deltaTime * speed, Space.World);
            }
        }
    }

    private void MoveForward(float rate)
    {
        transform.Translate(Vector3.forward * rate * speed, Space.Self);
    }
}
