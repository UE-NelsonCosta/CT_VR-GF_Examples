using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAudioEvent : MonoBehaviour
{
    public bool PlayOnAwake = false;

    public AudioEventData audioData;

    private AudioSource audioSource = null;

    private bool hasBegunPlay = false;

    public delegate void OnAudioTriggeredDelegate();
    public event OnAudioTriggeredDelegate OnAudioFinished;

    // Start is called before the first frame update
    void Awake()
    {
        if (PlayOnAwake)
        {
            RequestAudio();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (audioSource == null && hasBegunPlay)
        {
            // AudioEventHas Completed So Fire Off The OnAudioTriggered
            OnAudioFinished?.Invoke();
        }

        if (!audioSource.isPlaying && hasBegunPlay)
        {
            OnAudioFinished?.Invoke();
        }
    }

    public void RequestAudio()
    {
        audioSource = AudioManager.Instance.PlayEvent(audioData);
        if (audioSource)
            hasBegunPlay = true;
    }
}
