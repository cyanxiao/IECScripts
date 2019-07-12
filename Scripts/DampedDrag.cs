using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
/// <summary>
/// 产生阻尼，包括运动阻尼和角阻尼
/// </summary>
public class DampedDrag : MonoBehaviour
{
    Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity -= rb.velocity * GameDB.DAMPED_CONST * Time.fixedDeltaTime;
    }
}
