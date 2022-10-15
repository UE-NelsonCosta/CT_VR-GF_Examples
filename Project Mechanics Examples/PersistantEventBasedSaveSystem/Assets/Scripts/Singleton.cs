using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T LazyInstance;

    public static T Instance 
    {
        get
        {
            if (LazyInstance == null)
            {
                LazyInstance = CreateSingleton();
            }

            return LazyInstance;
        }
    }

    private static T CreateSingleton()
    {
        GameObject ownerObject = new GameObject($"{typeof(T).Name} (singleton)");
        T instance = ownerObject.AddComponent<T>();
        DontDestroyOnLoad(ownerObject);
        return instance;
    }
}
