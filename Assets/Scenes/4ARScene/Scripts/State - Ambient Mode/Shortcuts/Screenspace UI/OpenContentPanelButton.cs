using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenContentPanelButton : MonoBehaviour
{
    public GameObject shortcutListObject;
    
    public void ToggleShortcutListActive()
    {
        switch (shortcutListObject.activeSelf)
        {
            case(true):
                shortcutListObject.SetActive(false);
                break;
            case(false):
                shortcutListObject.SetActive(true);
                break;
        }    
    }
}
