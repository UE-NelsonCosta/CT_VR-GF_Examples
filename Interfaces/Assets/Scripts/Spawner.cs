using UnityEngine;

public class Spawner : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject objectToSpawn = null;

    Transform myCachedTransform = null;
    public bool CanInteract(GameObject instigator)
    {
        return true;
    }

    public void Interact(GameObject instigator)
    {
        Instantiate
            (
                objectToSpawn, 
                myCachedTransform.position + new Vector3(0, 2, 0), 
                myCachedTransform.rotation 
            );
    }

    private void Start()
    {
        myCachedTransform = GetComponent<Transform>();
    }
}
