using System.Collections.Generic;
using UnityEngine;

// Basic Manager For Points of interest, used as a patrol point at this moment.
public class POIManager : MonoBehaviour
{
    [SerializeField] private List<Transform> pois = new List<Transform>();

    // Get an element from the list.
    public Transform GetPOIAtIndex(int index)
    {
        if (!IsIndexValid(index)) 
            return null;
        
        return pois[index];
    }

    // Check if the index is valid in the list
    public bool IsIndexValid(int index)
    {
        return index < pois.Count && index >= 0;
    }

}
