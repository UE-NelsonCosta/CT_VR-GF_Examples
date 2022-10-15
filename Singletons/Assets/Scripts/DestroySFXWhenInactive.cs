using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySFXWhenInactive : MonoBehaviour
{
    AudioSource audioSource = null;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            Destroy(gameObject);
        }
    }
}
