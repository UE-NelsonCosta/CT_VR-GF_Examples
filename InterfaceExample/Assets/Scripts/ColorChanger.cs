using UnityEngine;
using System.Collections.Generic;

// For Example Sake
//[RequireComponent(typeof(MeshFilter))]
//[RequireComponent(typeof(MeshRenderer))]
public class ColorChanger : MonoBehaviour, IInteractable
{
    bool canInteract = true;
    MeshRenderer meshRenderer = null;

    //public List<Color> someListOfColors = new List<Color>() { new Color(), new Color(), new Color() };

    public bool CanInteract(GameObject instigator)
    {
        return canInteract;
    }

    public void Interact(GameObject instigator)
    {
        //canInteract = false;
        Color color = new Color
            (
                Random.RandomRange(0.0f, 1.0f), 
                Random.RandomRange(0.0f, 1.0f), 
                Random.RandomRange(0.0f, 1.0f), 
                1                   
            );
        meshRenderer.material.SetColor("_Color", color);
    }

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        if (meshRenderer == null)
        {
            Debug.Log("ColorChanger::Start() Failed To Find Mesh Renderer");
            enabled = false;
        }
    }

    //void Update()
    //{
    //    Interact(null);
    //}
}
