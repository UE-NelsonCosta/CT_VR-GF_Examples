using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

public struct SaveableObject
{
    public int mainVersion;
    public int subVersion;

    public float health;
    public float mana;
};

public enum ESerializeGameDataAs
{
    JSON,
    Binary,
}

public class SaveManager : Singleton<SaveManager>
{
    // SaveabelData
    SaveableObject saveableObject = new SaveableObject();

    ESerializeGameDataAs saveOutput = ESerializeGameDataAs.JSON;

    public delegate void SavingDelegate(ref SaveableObject obj);
    public event SavingDelegate OnPostLoadEvent;
    public event SavingDelegate OnPreSaveEvent;

    public void RequestSave()
    {
        OnPreSaveEvent?.Invoke(ref saveableObject);

        switch (saveOutput)
        {
            case ESerializeGameDataAs.JSON:
                {
                    SaveToJSON();
                    break; 
                }
            case ESerializeGameDataAs.Binary:
                {
                    SaveToBinary();
                    break;
                }
            default:
                // We Should never be here anyways
                break;
        }
    }

    public void RequestLoad()
    {
        switch (saveOutput)
        {
            case ESerializeGameDataAs.JSON:
                {
                    LoadFromJSON();
                    break;
                }
            case ESerializeGameDataAs.Binary:
                {
                    LoadFromBinary();
                    break;
                }
            default:
                // We Should never be here anyways
                break;
        }

        OnPostLoadEvent?.Invoke(ref saveableObject);
    }

    public void SaveToJSON()
    {
        string absoluteFilePath = $"{Application.persistentDataPath}/GameData.json";

        string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(saveableObject);

        File.WriteAllText(absoluteFilePath, jsonString);
    }

    public void LoadFromJSON()
    {
        string absoluteFilePath = $"{Application.persistentDataPath}/GameData.json";

        string jsonString = File.ReadAllText(absoluteFilePath);

        saveableObject = Newtonsoft.Json.JsonConvert.DeserializeObject<SaveableObject>(jsonString);
    }

    public void SaveToBinary()
    {

    }

    public void LoadFromBinary()
    {
        
    }

}
