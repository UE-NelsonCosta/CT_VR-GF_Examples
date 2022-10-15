using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManagerTrigger : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SaveManager.Instance.RequestSave();
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            SaveManager.Instance.RequestLoad();
        }
    }
}
