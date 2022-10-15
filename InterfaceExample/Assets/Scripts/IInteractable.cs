using UnityEngine;

interface IInteractable
{
    bool CanInteract(GameObject instigator);
    void Interact(GameObject instigator);
}
