using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAudioManagerScript : MonoBehaviour
{
    [SerializeField] private GameObject prefab = null;
    [SerializeField] private AudioClip clip = null;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            AudioManager.Instance.PlaySoundAtLocation
                (
                    prefab,
                    Vector3.zero,
                    Quaternion.identity
                );
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            AudioManager.Instance.PlaySoundAtLocation
                (
                    clip,
                    Vector3.zero
                );
        }
    }
}
