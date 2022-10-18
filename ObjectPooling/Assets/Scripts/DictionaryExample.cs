using UnityEngine;
using System.Collections.Generic;

// Simple Class To Showcase The Use Of A Dictionary To Build A Pool
public class DictionaryExample
{
    // Dictionaries use a "Key" (a name in this case) to map it to a "value" (an age in this case) 
    private Dictionary<string, int> personToAgeDictionary = new Dictionary<string, int>();

    private void Start()
    {
        // Add In The Things
        personToAgeDictionary.Add("Nelson Costa", 32);
        personToAgeDictionary.Add("Miguel Boavida", 18);
    }
}
