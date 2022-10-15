using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface ISavableInformation
{
    public abstract void OnSave(ref SaveableObject obj);
    public abstract void OnLoad(ref SaveableObject obj);
}
