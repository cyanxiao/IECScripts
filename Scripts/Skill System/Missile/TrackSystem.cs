using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackSystem : MonoBehaviour
{
    /// <summary>
    /// 需要被追踪的目标（只能是 Unit）
    /// </summary>
    public Unit enemy;

    public float trackingAbility = 0f;

    /// <summary>
    /// 最远追踪距离（目标与 Missile 距离）
    /// </summary>
    public float focusDistance = 30;

    /// <summary>
    /// 目标的 Transform
    /// </summary>
    public Transform target;


    bool isFollowingTarget = true;
    string targetTag;
    ///// <summary>
    ///// 是否一直面向目标
    ///// </summary>
    //bool faceTarget;
    Vector3 tempVector;


    public bool IsTracking { get; private set; } = false;
    public void StartTracking(Unit targetEnemy, float trackingAbility)
    {
        enemy = targetEnemy;
        if (enemy != null)
            target = targetEnemy.transform;
        this.trackingAbility = trackingAbility;
        IsTracking = true;
        Debug.Log(string.Format("Missile {0} starts to track Unit {1}", gameObject.name, enemy.gameObject.name));
    }

    public void StopTracking()
    {
        IsTracking = false;
    }

    private void Update()
    {
        if (!IsTracking)
        {
            return;
        }
        if (enemy == null)
        {
            StopTracking();
            return;
        }
        Vector3 targetDirection = target.position - transform.position;
        if (Vector3.Distance(transform.position, target.position) < focusDistance ||
            Vector3.Angle(transform.forward, targetDirection) > 90f)
        {
            // do nothing
        }
        else
        {
            // 转向目标
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetDirection), trackingAbility * Time.deltaTime);
        }
        

        //if (faceTarget)
        //{
        //    Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, rotationSpeed * Time.deltaTime, 0.0F);

        //    //MoveForward(Time.deltaTime);

        //    if (isFollowingTarget)
        //    {
        //        transform.rotation = Quaternion.LookRotation(newDirection);
        //    }
        //}

        //else
        //{
        //if (isFollowingTarget)
        //{
        //    tempVector = targetDirection.normalized;

        //    transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        //}
        //else
        //{
        //    transform.Translate(tempVector * Time.deltaTime * speed, Space.World);
        //}
        //}
    }

    //private void MoveForward(float rate)
    //{
    //    transform.Translate(Vector3.forward * rate * speed, Space.Self);
    //}
}
