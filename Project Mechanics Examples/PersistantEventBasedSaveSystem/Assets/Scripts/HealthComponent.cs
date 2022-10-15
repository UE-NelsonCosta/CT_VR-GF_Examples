using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour, ISavableInformation
{
    [SerializeField] public float health = 0.0f;
    public float Health{ get { return health; } set { health = value; } }

    public void OnLoad(ref SaveableObject obj)
    {
        Health = obj.health;
    }

    public void OnSave(ref SaveableObject obj)
    {
        obj.health = Health;
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
