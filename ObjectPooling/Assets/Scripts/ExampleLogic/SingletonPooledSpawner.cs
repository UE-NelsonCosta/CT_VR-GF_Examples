using UnityEngine;

public class SingletonPooledSpawner : MonoBehaviour
{
    [SerializeField] private CreatePoolObjectParameters poolableObject = null;

    private IObjectPool pool;

    void Start()
    {
        pool = LevelSingletonPoolManager.Instance;
        pool?.AddInstances(poolableObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject pooledObject = pool?.GetPooledInstance(poolableObject.KeyIdentifier);
            if (pooledObject == null)
                return;

            Vector3 location = new Vector3( Random.Range(-4, 4), Random.Range(2, 4), Random.Range(-4, 4));
            Vector3 rotation = new Vector3( Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));

            pooledObject.transform.position = location;
            pooledObject.transform.rotation = Quaternion.Euler(rotation);

            pooledObject.SetActive(true);
        }
    }
}
