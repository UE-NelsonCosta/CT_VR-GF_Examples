using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// We Are Currently Expecting This To Be At The Root Of The Object
public interface IRecyclablePoolObject
{
    void InitializeRecyclableObject(IObjectPool parent, string recycleID);
    void OnSpawnedObject();
    void OnRecycleObject();
}
