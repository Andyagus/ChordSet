using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenContentPanelButton : MonoBehaviour
{
    public GameObject shortcutListObject;

    public void OnContentPanelButtonClick()
    {
        Debug.Log("Clicked Panel Button");
    }
    
    public void ToggleShortcutListActive()
    {
        switch (shortcutListObject.activeSelf)
        {
            case(true):
                Debug.Log("Clicked, now true");
                // shortcutListObject.SetActive(false);
                break;
            case(false):
                Debug.Log("Clicked, now false");
                // shortcutListObject.SetActive(true);
                break;
        }    
    }
}
