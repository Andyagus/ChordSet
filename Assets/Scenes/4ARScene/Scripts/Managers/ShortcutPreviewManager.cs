using System;
using System.Collections;
using System.Collections.Generic;
using AR_Keyboard;
using UnityEngine;

public class ShortcutPreviewManager : MonoBehaviour
{

    [SerializeField] private ShortcutList shortcutList; 
    
    private void Start()
    {
        shortcutList.onListItemClicked += OnListItemClicked;
    }

    private void OnListItemClicked(Shortcut shortcut)
    {
        Debug.Log("Shortcut Preview Manager: ");
        Debug.Log("clicked the " + shortcut.shortcutName + "shortcut");
    }
}
