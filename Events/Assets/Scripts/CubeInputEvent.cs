using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeInputEvent : MonoBehaviour
{
    public delegate void InputDelegate();
    public event InputDelegate OnInteractStarted;
    public event InputDelegate OnInteractionStopped;

    public delegate void ConstantInputDelegate(float axis);
    public event ConstantInputDelegate OnInteracting;

    private float previousFrameInputAxis = 0.0f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnInteractStarted?.Invoke();
        }

        if (Input.GetMouseButtonUp(0))
        {
            OnInteractionStopped?.Invoke();
        }

        float currentFrameInputAxis = Input.GetAxis("Horizontal");
        if (currentFrameInputAxis != previousFrameInputAxis)
        {
            OnInteracting?.Invoke(currentFrameInputAxis);
            previousFrameInputAxis = currentFrameInputAxis;
        }
    }
}
