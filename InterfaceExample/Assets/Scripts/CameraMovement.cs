using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 90.0f;

    Transform myTransform = null;

    private void Awake()
    {
        myTransform = GetComponent<Transform>();
    }
    void Update()
    {
        if (!Input.GetKey(KeyCode.Mouse1))
            return;

        float inputX = Input.GetAxisRaw("Mouse X") * rotationSpeed * Time.deltaTime;
        float inputY = Input.GetAxisRaw("Mouse Y") * rotationSpeed * Time.deltaTime;
        
        Vector3 eulerAngles = myTransform.rotation.eulerAngles;
        eulerAngles += new Vector3 (-inputY, inputX, 0);

        myTransform.rotation = Quaternion.Euler(eulerAngles);
    }
}
