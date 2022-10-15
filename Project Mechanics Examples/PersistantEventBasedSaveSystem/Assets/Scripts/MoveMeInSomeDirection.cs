using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MoveMeInSomeDirection : MonoBehaviour
{
    [SerializeField] private Vector3 worldDirection = Vector3.zero;
    [SerializeField] private float movementSpeed = 1.0f;

    private Rigidbody myRigidbody = null;

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();

        CubeInputEvent eventComponentToRegisterTo = FindObjectOfType<CubeInputEvent>();
        if (eventComponentToRegisterTo)
        {
            eventComponentToRegisterTo.OnInteractStarted += OnExampleCubeActivated;
            eventComponentToRegisterTo.OnInteractionStopped += OnExampleCubeDeactivated;

            eventComponentToRegisterTo.OnInteracting += OnExampleCubeInteracting;
        }
    }

    public void OnExampleCubeActivated()
    {
        myRigidbody.velocity = worldDirection * movementSpeed;
    }

    public void OnExampleCubeDeactivated()
    {
        myRigidbody.velocity = Vector3.zero;
    }

    public void OnExampleCubeInteracting(float axis)
    {
        myRigidbody.velocity = worldDirection * axis * movementSpeed;
    }
}
