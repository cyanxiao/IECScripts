using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AutoDeathAfterPlayAnimation : MonoBehaviour
{
    float lifespan = 1f;
    float startTime;
    [SerializeField]
    AnimationClip anim;

    private void OnEnable()
    {
        if (anim == null)
        {
            lifespan = 1e9f;
        }
        else
        {
            lifespan = anim.length;
        }
        timer = 0f;
    }

    float timer = 0f;
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > lifespan)
            Gamef.Destroy(gameObject);
    }
}
