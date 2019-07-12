using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngularVelocityOnStart : MonoBehaviour
{
    public bool IsRandomAngularVelocityDirection = true;
    public bool IsRandomRotation = false;
    public Vector3 angularVelocityDirection = Vector3.forward;
    public float maxMagnitude = 30f;
    public float minMagnitude = 10f;
    Vector3 av;
    Quaternion tq;
    private void OnEnable()
    {
        if (maxMagnitude <= minMagnitude)
            maxMagnitude = minMagnitude + 1e-5f;
        if (IsRandomAngularVelocityDirection)
            av = Random.onUnitSphere * Random.Range(minMagnitude, maxMagnitude);
        else av = angularVelocityDirection * Random.Range(minMagnitude, maxMagnitude);
        tq = Quaternion.Euler(av);

        if (IsRandomRotation)
            transform.rotation = Random.rotation;
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, transform.rotation * tq, Time.fixedDeltaTime);
    }
}
