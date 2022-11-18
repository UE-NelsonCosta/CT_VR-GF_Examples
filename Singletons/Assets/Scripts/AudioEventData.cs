using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AudioEventData
{
    public AudioClip Clip;
    
    public Vector3 Position;
 
    public Vector3 Rotation;

    public Transform OverrideTransform;

    public bool ShouldParentToPoint;

    public bool DestroyOnFinish;

    public bool ShouldLoop;

}
