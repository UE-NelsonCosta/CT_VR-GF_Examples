using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastPainter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        float rayDistance = 100.0f;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100)).normalized);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            if (Input.GetKey(KeyCode.Mouse0))
                DrawOnTexture(hit.collider.GetComponent<MeshRenderer>().material, hit.textureCoord);
        }

        Debug.DrawLine(ray.origin, ray.origin + ray.direction * rayDistance);
    }

    private void DrawOnTexture(Material materialToWriteTo, Vector2 hitCoord)
    {
        Texture2D materialTexture = (Texture2D)materialToWriteTo.GetTexture("_MainTex");
        // Bad Name Or Just Simply No Assigned Texture
        if (materialTexture == null)
        {
            materialTexture = new Texture2D(128, 128);            
        }

        const int brushRadiusInPixels = 5;

        Vector2 hitUVToPixel = new Vector2(hitCoord.x * materialTexture.width, hitCoord.y * materialTexture.height); 

        // Draw a ... 10x10 red square
        for (int y = 0; y < brushRadiusInPixels; ++y)
        {
            for (int x = 0; x < brushRadiusInPixels; ++x)
            {
                // Truncating works perfectly Here So Keep It
                int XShiftedCoord = (int)hitUVToPixel.x + (x - brushRadiusInPixels / 2);
                int YShiftedCoord = (int)hitUVToPixel.y + (y - brushRadiusInPixels / 2);

                if (IsValidIndex(XShiftedCoord, 0, materialTexture.width) && IsValidIndex(YShiftedCoord, 0, materialTexture.height))
                {
                    materialTexture.SetPixel(XShiftedCoord, YShiftedCoord, Color.red);
                }
            }
        }

        materialTexture.Apply();

        materialToWriteTo.SetTexture("_MainTex", materialTexture);
    }

    private bool IsValidIndex(int index, int min, int max)
    {
        return index >= min && index <= max;
    }
}
