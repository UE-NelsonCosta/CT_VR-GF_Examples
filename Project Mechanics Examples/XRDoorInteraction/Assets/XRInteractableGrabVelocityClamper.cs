using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is here to fix the faulty velocity tracking
public class XRInteractableGrabVelocityClamper : MonoBehaviour
{
    [SerializeField] private float MaxVelocityMagnitude = 30;
    private Rigidbody myRigidbody = null;

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (myRigidbody && myRigidbody.velocity.magnitude > MaxVelocityMagnitude)
        {
            myRigidbody.velocity = myRigidbody.velocity.normalized * MaxVelocityMagnitude;
        }
    }
}
