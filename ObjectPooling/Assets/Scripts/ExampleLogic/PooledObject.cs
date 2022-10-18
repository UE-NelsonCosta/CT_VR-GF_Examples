using UnityEngine;

public class PooledObject : MonoBehaviour, IRecyclablePoolObject
{
    [SerializeField] private float timeToRecycle = 3.0f;
    private float timer = 0.0f;

    // This is initialized from the DictionaryExample
    public IObjectPool parentPool = null;
    public string recycleID = "";

    private void Start()
    {
        timer = timeToRecycle;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = timeToRecycle;

            parentPool.RecycleObject(recycleID, this.gameObject);
        }
    }

    public void InitializeRecyclableObject(IObjectPool parent, string recycleID)
    {
        parentPool = parent;
        this.recycleID = recycleID;
    }

    public void OnSpawnedObject()
    {
        GetComponent<Rigidbody>().isKinematic = false;

        this.enabled = true;
    }

    public void OnRecycleObject()
    {
        GetComponent<Rigidbody>().isKinematic = true;

        this.enabled = false;
    }
}
