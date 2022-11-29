using UnityEngine;

public class RaycastPainter : MonoBehaviour
{
    [SerializeField] private Transform originTransform;

    [SerializeField] private float rayDistance = .1f;
    // TODO: This is hardcoded should be using a second ray to figure out how wide to draw on any texture that way you can get a pencil or a spray
    [SerializeField] private int brushPixelRadius = 5;
    [SerializeField] private Color brushColor = Color.red;
    
    [SerializeField] private bool useCamera = false;
    [SerializeField] private bool useMouse = false; // To Disable This For VR

    private void Start()
    {
        if (originTransform == null)
        {
            Debug.LogError($"No Origin Defined On RaycastPainter {gameObject.name}");
            enabled = false;
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 origin = Vector3.zero;
        Vector3 direction = Vector3.zero;
        GetOriginAndDirection(ref origin, ref direction);

        Ray ray = new Ray(origin, direction);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            Debug.DrawLine(ray.origin, hit.point, Color.green);

            if (!Input.GetKey(KeyCode.Mouse0) && useMouse)
            {
                return;
            }

            PaintableSurface paintableSurface = hit.collider.GetComponent<PaintableSurface>();
            if (paintableSurface == null || !paintableSurface.IsValid())
            {
                return;
            }

            DrawOnTexture(paintableSurface, hit.textureCoord);
        }

        // Debug Drawing
        Debug.DrawLine(ray.origin, ray.origin + ray.direction * rayDistance, Color.red);
    }

    private void GetOriginAndDirection(ref Vector3 origin, ref Vector3 direction)
    {
        if (useCamera)
        {
            origin = Camera.main.transform.position;
            direction = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100)).normalized;
        }
        else
        {
            origin = originTransform.position;
            direction = originTransform.forward;
        }
    }

    private void DrawOnTexture(PaintableSurface paintableSurface, Vector2 hitCoord)
    {
        Texture2D materialTexture = paintableSurface.GetDrawableTexture();

        Vector2 hitUVToPixel = new Vector2(hitCoord.x * materialTexture.width, hitCoord.y * materialTexture.height); 

        // Draw a ... 10x10 circle, that said this isnt taking into account aspect ratios! :l
        for (int y = 0; y < brushPixelRadius * 2; ++y)
        {
            for (int x = 0; x < brushPixelRadius * 2; ++x)
            {
                // Truncating works perfectly Here So Keep It
                Vector2 shiftedPixel = new Vector2
                    (
                        (int)hitUVToPixel.x + (x - brushPixelRadius),
                        (int)hitUVToPixel.y + (y - brushPixelRadius)
                    ); 

                // TODO: Now take the shifted pixel and check it against the aspect ratio! Otherwise this will look squashed in non 1:1 ratios


                if (IsValidIndex((int)shiftedPixel.x, 0, materialTexture.width) && IsValidIndex((int)shiftedPixel.y, 0, materialTexture.height))
                {
                    float distanceToPoint = Mathf.Abs(Vector2.Distance(shiftedPixel, hitUVToPixel));

                    if (distanceToPoint <= brushPixelRadius)
                    {
                        materialTexture.SetPixel((int)shiftedPixel.x, (int)shiftedPixel.y, brushColor);
                    }
                }
            }
        }

        materialTexture.Apply();

        paintableSurface.GetDrawableMaterial().SetTexture("_MainTex", materialTexture);
    }

    private bool IsValidIndex(int index, int min, int max)
    {
        return index >= min && index <= max;
    }
}
