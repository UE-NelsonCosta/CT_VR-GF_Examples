using UnityEngine;
using System.Collections.Generic;

// Class To Show How To Create A Localized Pool, This Just Means Its A Segregated Instance Of A Pool
// Thats Used Only For This Project
// NOTE: This is basically the same as the LevelSingletonPoolManager
public class LocalizedPool : MonoBehaviour, IObjectPool
{
    // Structure To Hold All Of Out Instances
    private Dictionary<string, List<GameObject>> objectPool = new Dictionary<string, List<GameObject>>();

    // TODO: Add This To Keep The Hierarchy Clean
    private GameObject poolParent = null;

    #region UnityFunctions
    private void Awake()
    {
        poolParent = new GameObject("Pool Parent");
    }

    #endregion

    #region Interface Implementation

    public bool AddInstances(CreatePoolObjectParameters parameters)
    {
        // Do Initial Checks Of Parameters
        if (!parameters.HasValidParameters())
        {
            Debug.LogError("LevelSingleton::AddInstances - Has Invalid Paramters!");
            return false;
        }

        // Lets Either Find The Existing Instance Lists Or Create A New One
        List<GameObject> instancesOfKeyType = GetOrCreateInstanceListForKey(parameters.KeyIdentifier, parameters.ReserveSize);

        // Let's Generate All These Instances!
        for (int i = 0; i < parameters.ReserveSize; ++i)
        {
            // Instantiate These Objects At World Origin And Turn Them off
            GameObject instance = Instantiate(parameters.PrefabToSpawn, Vector3.zero, Quaternion.identity);
            if (instance == null)
            {
                Debug.LogError("LevelSingleton::AddInstances, Failed To Instantiate, did you run out of memory?");
                return false;
            }

            // Turn The Object Off
            instance.SetActive(false);

            // Try Find The Component Where We Want It Or Throw An Error
            IRecyclablePoolObject instanceObjectInterface = instance.GetComponent<IRecyclablePoolObject>();
            if (instanceObjectInterface == null)
            {
                Debug.LogError("LevelSingleton::AddInstances - Prefab is incorrectly setup! Add a component at its root that uses the IRecyclablePoolObject interface");
                return false;
            }

            // Ensure To Initialize The Object
            instanceObjectInterface.InitializeRecyclableObject(this, parameters.KeyIdentifier);

            // Finally Add It :D
            instancesOfKeyType.Add(instance);
        }

        return true;
    }

    // We normally dont call this we let the scene handle cleanup
    public void RemoveInstances(string ID)
    {
        if (ID == "")
        {
            Debug.LogError("LevelSingleton::RemoveInstances - Empty ID!");
        }

        List<GameObject> objectInstances = null;
        if (objectPool.TryGetValue(ID, out objectInstances))
        {
            for (int i = 0; i < objectInstances.Count; ++i)
            {
                Destroy(objectInstances[i]);
            }

            objectInstances.Clear();
        }
    }

    public GameObject GetPooledInstance(string ID)
    {
        List<GameObject> objectInstanaces = null;
        if (objectPool.TryGetValue(ID, out objectInstanaces))
        {
            if (objectInstanaces.Count > 0)
            {
                GameObject firstObject = objectInstanaces[0];
                if (firstObject == null)
                {
                    // This should just find the next one, but as an example for students we want this to break so they
                    // can follow an example to fix things properly isntead of patching them.
                    Debug.LogError("LevelSingleton::GetPooledInstance: Someone Deleted My Pooled Object! Dont Destroy Objects!");
                    return null;
                }

                // Remove The Object From It's List For Now
                objectInstanaces.Remove(firstObject);

                // This Should Be Valid As It HAS To Have One When We Add It
                firstObject.GetComponent<IRecyclablePoolObject>()?.OnSpawnedObject();

                // Return It! :D
                return firstObject;
            }
            else
            {
                // TODO: Could Resize If We Want To But It's Better If They Ask For A Bigger Pool
                Debug.LogError("LevelSingleton::GetInstance: No Objects In List! Create A Pool With A Larget Value!");
            }
        }
        else
        {
            Debug.LogError($"LevelSingleton::GetInstance: Failed To Find Key: {ID}");
        }

        return null;
    }


    public void RecycleObject(string ID, GameObject instance)
    {
        if (ID == string.Empty || ID == "")
        {
            Debug.LogError("LevelSingleton::RecycleObject - Empty ID!");
            return;
        }

        if (instance == null)
        {
            Debug.LogError("LevelSingleton::RecycleObject - Cannot Recycle Null Object!");
            return;
        }

        // Let's Check If The ID Already Exists
        if (objectPool.ContainsKey(ID))
        {
            // Disable The Object
            instance.SetActive(false);

            // Give It A Chance To Turn Off Anything It Needs
            instance.GetComponent<IRecyclablePoolObject>()?.OnRecycleObject();

            // Add It Back To The List
            objectPool[ID].Add(instance);
        }
        else
        {
            Debug.LogError("LevelSingleton::RecycleObject: Bad ID Passed In, Did You Mistype It?");
        }
    }

    #endregion

    #region Auxiliary Functions

    // Tries To Get Otherwise Creates A List For Key Type
    List<GameObject> GetOrCreateInstanceListForKey(string ID, int poolSize)
    {
        List<GameObject> listForID = null;
        if (!objectPool.TryGetValue(ID, out listForID))
        {
            listForID = new List<GameObject>(poolSize);
            objectPool.Add(ID, listForID);
        }

        return listForID;
    }

    #endregion
}
