using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShortcutListInputHandler : MonoBehaviour
{
    private ShortcutList _shortcutList;
    private ScrollRect _scrollRect;

    private int _currentInputIndex = 0;
    
    private void Awake()
    {
        Debug.Log("Short cut list input awake");
        _shortcutList = GetComponent<ShortcutList>();
        _scrollRect = GetComponentInChildren<ScrollRect>();
        var listItems = _scrollRect.content.GetComponentsInChildren<ShortcutListItem>();
        
    }

    public void HandleInput(Key key)
    {
        Debug.Log("Shortcut List Input Handler: " + key);
        // throw new System.NotImplementedException();
    }
}
