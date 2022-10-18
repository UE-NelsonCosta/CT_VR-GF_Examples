using UnityEngine;

// Object Pool Interface For The Various Types We Use
public interface IObjectPool
{
    // Generate Instances For Reuse
    public bool AddInstances(CreatePoolObjectParameters parameters);
    
    // Remove Instances Related To A Key
    public void RemoveInstances(string ID);

    // Get A Object From A Pool
    public GameObject GetPooledInstance(string ID);

    // Recycle Object Back Into It's Pool
    public void RecycleObject(string ID, GameObject instance);
}
