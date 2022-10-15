using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaComponent : MonoBehaviour, ISavableInformation
{
    [SerializeField] public float mana = 0;
    public float Mana { get { return mana; } set { mana = value; } }

    public void OnLoad(ref SaveableObject obj)
    {
        Mana = obj.mana;
    }

    public void OnSave(ref SaveableObject obj)
    {
        obj.mana = Mana;
    }

    // Start is called before the first frame update
    private void Awake()
    {
        SaveManager.Instance.OnPostLoadEvent += OnLoad;
        SaveManager.Instance.OnPreSaveEvent += OnSave;
    }

    private void OnDestroy()
    {
        SaveManager.Instance.OnPostLoadEvent -= OnLoad;
        SaveManager.Instance.OnPreSaveEvent -= OnSave;
    }
}
