using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 该组件用于玩家操控单位。非玩家控制单位不使用该组件。
/// </summary>
[RequireComponent(typeof(Unit))]
[RequireComponent(typeof(Rigidbody))]
public class MoveCtrl : MonoBehaviour
{
    //public GameObject CastPrefab;

    private Unit unit;
    private UnitAttributes unitAttributes;
    private Rigidbody rigbody;
    public Vector3 charaUp = Vector3.up;

    public Transform chara;
    public Transform eye;
    public Transform glass;
    public float speed = 0f;
    public float angularSpeed = 0f;

    private const float  APPROACHING_CONST = 3f;

    private void Awake()
    {
        EventMgr.UnitBirthEvent.AddListener(Init);
    }

    private float v;
    private float h;
    private float ac;
    private void Update()
    {
        v = /*Input.GetAxis("Vertical")*/InputMgr.GetVerticalAxis();
        h = /*Input.GetAxis("Horizontal")*/InputMgr.GetHorizontalAxis();
        ac = Input.GetKey(InputMgr.AccelerationKey) ? 1f : 0f;
        eye.position = glass.position;
        eye.localEulerAngles = Vector3.forward * chara.localEulerAngles.z;
    }

    private void FixedUpdate()
    {
        if (InputMgr.MobileControlKeyEnable)
        {
            Turning(Time.fixedDeltaTime);
            UpdateVelocity(Time.fixedDeltaTime);
        }
        //speed = rigbody.velocity.magnitude;
        //angularSpeed = srb.angularVelocity.magnitude * Mathf.Rad2Deg;
    }
    /// <summary>
    /// 转向。即更新转向速度angularVelocity
    /// </summary>
    private void Turning(float dt)
    {
        if (!InputMgr.MobileControlKeyEnable) return;

        Quaternion tarRot = CameraCtrl.Instance.transform.rotation;
        Quaternion rot = transform.rotation;
        Quaternion dRot = Quaternion.Slerp(rot, tarRot, APPROACHING_CONST * dt);
        transform.rotation = dRot;
    }

    /// <summary>
    /// 加速。即更新速度Velocity, 并调整速度方向。
    /// </summary>
    /// <param name="dt">时间间隔</param>
    private void UpdateVelocity(float dt)
    {
        rigbody.velocity += transform.forward * ac * unitAttributes.Acceleration * Time.fixedDeltaTime;
        // 令速度方向趋近镜头方向。
        rigbody.velocity = Vector3.Lerp(rigbody.velocity.normalized, CameraCtrl.Instance.transform.forward, APPROACHING_CONST * dt).normalized * rigbody.velocity.magnitude;
    }
    

    private bool isInit = false;
    private void Init(EventMgr.UnitBirthEventInfo info)
    {
        if (isInit)
            return;
        if (info.Unit.gameObject != gameObject)
            return;
        unit = info.Unit;
        unitAttributes = unit.attributes;
        rigbody = unit.rigbody;
        isInit = true;
    }
}
