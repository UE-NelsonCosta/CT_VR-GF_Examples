using UnityEngine;

// This Is An Object To Pack Together The Bits Required To Spawn A Poolable Object
// Uses this in order to show the fields in the inspector
// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-7.3/auto-prop-field-attrs
[System.Serializable]
public class CreatePoolObjectParameters
{
    [field: SerializeField] public string KeyIdentifier { get; set; } = string.Empty;

    [field: SerializeField] public int ReserveSize { get; set; } = 0;

    [field: SerializeField] public GameObject PrefabToSpawn { get; set; } = null;

    public CreatePoolObjectParameters(string keyIdentifier, int reserveSize, GameObject prefab)
    {
        KeyIdentifier = keyIdentifier;
        ReserveSize = reserveSize;   
        PrefabToSpawn = prefab;
    }

    public bool HasValidParameters()
    {
        return !(KeyIdentifier == string.Empty || KeyIdentifier == "" || ReserveSize <= 0 || PrefabToSpawn == null);
    }
}
