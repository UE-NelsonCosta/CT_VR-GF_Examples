using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Simple component to setup a basic texture to paint to!
public class PaintableSurface : MonoBehaviour
{
    // This would need configuring depending on the actual board, so pixels dont look stretched
    [SerializeField] private Vector2 defaultTextureSize = new Vector2(1280, 720);

    private Texture2D currentTexture;
    private Material currentMaterial;

    private void Start()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        if (!meshRenderer)
        {
            Debug.LogError($"Unable To Find A Renderer On The Object: {gameObject.name}! Please Add One!");
            this.enabled = false;
            return;
        }

        currentMaterial = meshRenderer.material;

        if (!currentMaterial)
        {
            Debug.LogError($"Unable To Find A Material On The Object: {gameObject.name}! Please Add One!");
            this.enabled = false;
            return;
        }
        
        currentTexture = (Texture2D)currentMaterial.GetTexture("_MainTex"); // TODO: Make this into a variable
        if (currentTexture == null)
        {
            if (defaultTextureSize == Vector2.zero)
            {
                Debug.LogWarning("PaintableSurface defaultTextureSize Parameter is invalid! Defaulting to 1280, 720");
                defaultTextureSize = new Vector2(1280, 720);
            }

            currentTexture = new Texture2D((int)defaultTextureSize.x, (int)defaultTextureSize.y);
        }
    }

    public bool IsValid()
    {
        return currentTexture && currentMaterial;
    }

    public Texture2D GetDrawableTexture()
    {
        return currentTexture;
    }

    public Material GetDrawableMaterial()
    {
        return currentMaterial;
    }
}
