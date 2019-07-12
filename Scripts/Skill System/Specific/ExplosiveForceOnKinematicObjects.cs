using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveForceOnKinematicObjects : MonoBehaviour {

    public Rigidbody[] rigidbodies;
    public float force = 50f;
    public Transform explosionPoint;
    public float radius = 5f;
    public float upwardsModifier = 0.1f;

    private void Awake()
    {
        if (explosionPoint == null)
            explosionPoint = transform;
    }

    private void OnEnable()
    {
        foreach (Rigidbody rb in rigidbodies)
        {
            rb.isKinematic = false;
            rb.AddExplosionForce(force, explosionPoint.position, radius, upwardsModifier, ForceMode.Impulse);
        }
    }

    private void OnDisable()
    {
        foreach (Rigidbody rb in rigidbodies)
        {
            rb.isKinematic = true;
        }
    }
}
