using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDeathAfterPlayAudio : MonoBehaviour
{
    
    public AudioClip clip;


    private void OnEnable()
    {
        if (clip == null)
        {
            AudioSource audioSource = GetComponent<AudioSource>();
            if (audioSource != null)
            {
                clip = audioSource.clip;
            }
        }
        DelayedStop();
    }

    IEnumerator DelayedStop()
    {
        if (clip != null)
        {
            yield return new WaitForSeconds(clip.length);
            Gamef.Destroy(gameObject);
        }
    }
}
