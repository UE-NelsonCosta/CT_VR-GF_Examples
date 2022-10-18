using UnityEngine;

public abstract class LevelSingleton<T> : MonoBehaviour where T : MonoBehaviour
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
        return instance;
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            LazyInstance = null;
        }
    }
}
