using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoveCtrl))]
[RequireComponent(typeof(Rigidbody))]
public class BodyBalancing : MonoBehaviour
{
    //空气阻尼
    public const float AIR_DAMP = 0.5f;
    public const float Z_ROT_CONST = 0.4f;
    //重力加速度
    public const float GRAVITY_CONST = 9.81f;
    public const float RECI_GRAVITY_CONST = 1 / GRAVITY_CONST;
    //空气阻尼与重力加速度的比值
    public const float LEAN_CONST = AIR_DAMP / GRAVITY_CONST;

    public const float APPROACHING_RATE = 5f;

    Rigidbody rb;
    private MoveCtrl moveCtrl;

    void Awake()
    {
        moveCtrl = GetComponent<MoveCtrl>();
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        rot = transform.eulerAngles;
    }

    float sinx, cosx, x, tanf, z;
    Vector3 rot;
    Vector3 prevRot;
    // Update is called once per frame
    void LateUpdate()
    {
        prevRot = rot;
        rot = transform.eulerAngles;
        Vector3 av = rot - prevRot;
        av.x = (av.x + 180f) % 360f - 180f;
        av.y = (av.y + 180f) % 360f - 180f;
        av.z = (av.z + 180f) % 360f - 180f;
        // Z轴平衡 (绕自转轴的平衡)
        // omega * v / g
        z = -Z_ROT_CONST * av.y * rb.velocity.magnitude * RECI_GRAVITY_CONST;
        z = Mathf.Atan(z) * Mathf.Rad2Deg;

        // X轴平衡 (俯仰平衡)
        Vector3 projection = Vector3.ProjectOnPlane(transform.forward, Vector3.up);
        x = Vector3.SignedAngle(transform.forward, projection, transform.right) * Mathf.Deg2Rad;
        //x = srb.XRot.eulerAngles.x * Mathf.Deg2Rad;
        sinx = Mathf.Sin(x);
        cosx = Mathf.Cos(x);
        tanf = (LEAN_CONST * rb.velocity.magnitude - sinx) / cosx;
        x =Mathf.Atan(tanf) * Mathf.Rad2Deg;

        moveCtrl.chara.localRotation = Quaternion.Slerp(moveCtrl.chara.localRotation, Quaternion.Euler(x, 0, z), APPROACHING_RATE * Time.deltaTime);

    }
}
