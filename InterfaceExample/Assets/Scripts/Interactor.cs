using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EInteractorOriginCheck
{
    MiddleOfScreen,
    MousePosition
}

public class Interactor : MonoBehaviour
{
    [SerializeField] private float rayLength = 10.0f;

    [SerializeField] private bool showDebugLines = false;

    [SerializeField] private EInteractorOriginCheck interactionOrigin = EInteractorOriginCheck.MiddleOfScreen;
    
    Transform myTransform = null;


    void Start()
    {
        myTransform = GetComponent<Transform>();
    }

    void Update()
    {
        switch (interactionOrigin)
        {
            case EInteractorOriginCheck.MiddleOfScreen:
                {
                    if (showDebugLines)
                        DrawDebugLineForCenterOfScreen();

                    if (Input.GetKeyDown(KeyCode.Mouse0))
                        CheckInteractionFromCenterofScreen();

                    break;
                }
            case EInteractorOriginCheck.MousePosition:
                {

                    if (showDebugLines)
                        DrawDebugLineFromMousePosition();

                    if (Input.GetKeyDown(KeyCode.Mouse0))
                        CheckInteractionFromMousePosition();

                    break;

                }
            default:
                // Well Something Went Weirdly Wrong? :l
                break;
        }
    }

    private void DrawDebugLineForCenterOfScreen()
    {
        Vector3 lineStartPosition = myTransform.position;
        Vector3 lineEndPosition = lineStartPosition + myTransform.forward * rayLength;
        Color lineColor = Color.red;

        RaycastHit hit;
        if (Physics.Raycast(myTransform.position, myTransform.forward, out hit, rayLength))
        {
            lineEndPosition = hit.point;
            lineColor = Color.green;
        }

        Debug.DrawLine(lineStartPosition, lineEndPosition, lineColor);
    }

    private void CheckInteractionFromCenterofScreen()
    {
        RaycastHit hit;
        if (Physics.Raycast(myTransform.position, myTransform.forward, out hit, rayLength))
        {
            IInteractable interactableObject = hit.collider.GetComponent<IInteractable>();
            if (interactableObject != null && interactableObject.CanInteract(this.gameObject))
            {
                interactableObject.Interact(this.gameObject);
            }
        }
    }

    private void DrawDebugLineFromMousePosition()
    {
        Vector3 mouseToWorldDirection = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, rayLength)).normalized;

        Vector3 lineStartPosition = myTransform.position;
        Vector3 lineEndPosition = lineStartPosition + mouseToWorldDirection * rayLength;
        Color lineColor = Color.red;

        RaycastHit hit;
        if (Physics.Raycast(myTransform.position, mouseToWorldDirection, out hit, rayLength))
        {
            lineEndPosition = hit.point;
            lineColor = Color.green;
        }

        Debug.DrawLine(lineStartPosition, lineEndPosition, lineColor);
    }

    private void CheckInteractionFromMousePosition()
    {
        Vector3 mouseToWorldDirection = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, rayLength)).normalized;

        RaycastHit hit;
        if (Physics.Raycast(myTransform.position, mouseToWorldDirection, out hit, rayLength))
        {
            IInteractable interactableObject = hit.collider.GetComponent<IInteractable>();
            if (interactableObject != null && interactableObject.CanInteract(this.gameObject))
            {
                interactableObject.Interact(this.gameObject);
            }
        }
    }
}
