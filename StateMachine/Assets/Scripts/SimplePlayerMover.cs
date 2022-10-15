using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SimplePlayerMover : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 10;

    private Rigidbody myRigidbody = null;

    // Start is called before the first frame update
    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 inputDirection = new Vector3
            (
                Input.GetAxis("Horizontal"),
                0,
                Input.GetAxis("Vertical")
            );

        // Note this is all world, you'd need to transform to the cameras view if you want this to work elsewhere
        myRigidbody.velocity = inputDirection * movementSpeed;
    }
}
