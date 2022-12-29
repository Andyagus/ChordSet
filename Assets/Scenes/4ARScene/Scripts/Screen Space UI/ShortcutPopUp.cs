using System;
using System.Collections;
using System.Collections.Generic;
using AR_Keyboard;
using UnityEngine;

public class ShortcutPopUp : MonoBehaviour
{
    private ShortcutListItem _shortcutListItem;
    // private PanelState _panelState;
    
    private ShortcutPopUpState _popUpState;
    [SerializeField] private ShortcutList shortcutList;
    //could implement panel state
    private void Awake()
    {
        // _panelState = Get
        
        _shortcutListItem = GetComponent<ShortcutListItem>();
        shortcutList.onListItemClicked += OnListItemClicked;
    }

    private void OnListItemClicked(Shortcut shortcut)
    {
        _popUpState.TogglePanelState();
        _shortcutListItem.shortcutName.text = shortcut.shortcutName;
        _shortcutListItem.shortcutImage.sprite = shortcut.shortcutSprite;
    }
}
