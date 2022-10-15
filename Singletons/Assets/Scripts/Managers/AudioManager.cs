using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    public AudioSource PlaySoundAtLocation(
        GameObject prefab, 
        Vector3 location, 
        Quaternion rotation,
        bool destroySelf = false,
        bool shouldLoop = false)
    {
        if (!prefab)
        {
            Debug.LogError("AudioManager::PlaySoundAtLocation: Prefab Missing");
            return null;
        }

        GameObject gameObject = Instantiate(prefab, location, rotation);
        if (!gameObject)
        {
            Debug.LogError("AudioManager::PlaySoundAtLocation: Failed To Instantiate Object");
            return null;
        }

        AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        if (!audioSource)
        {
            Debug.LogError("AudioManager::PlaySoundAtLocation: Couldn't find the audio source component on the prfeab, Is it missing one?");
            return null;
        }

        audioSource.loop = shouldLoop;

        if (destroySelf)
            gameObject.AddComponent<DestroySFXWhenInactive>();

        return audioSource;
    }

    public AudioSource PlaySoundAtLocation(AudioClip clip, Vector3 location)
    {
        GameObject audioGameObject = new GameObject("SomeAudioClipExample");
        AudioSource source = audioGameObject.AddComponent<AudioSource>();
        source.clip = clip;

        source.Play();

        return source;
    }
}
