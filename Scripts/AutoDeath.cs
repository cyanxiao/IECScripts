using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDeath : MonoBehaviour
{
    public float LifeSpan = 1f;
    float startTime;
    private void OnEnable()
    {
        startTime = Time.time;
    }

    private void Update()
    {
        if (Time.time - startTime > LifeSpan)
            Gamef.Destroy(gameObject);
    }
}
