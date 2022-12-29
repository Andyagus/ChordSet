using System;
using System.Collections;
using System.Collections.Generic;
using AR_Keyboard;
using UnityEngine;

public class ShortcutPopUp : MonoBehaviour
{
    private ShortcutListItem _shortcutListItem;
    private ShortcutPopUpState _popUpState;
    public ShortcutPopUpState.EShortcutPopUp popUpState;
    [SerializeField] private ShortcutList shortcutList;
    [SerializeField] private ShortcutPreviewManager shortcutPreviewManager;
    
    
    private void Awake()
    {
        _popUpState = GetComponent<ShortcutPopUpState>();
        _shortcutListItem = GetComponent<ShortcutListItem>();
        shortcutList.onListItemClicked += OnListItemClicked;
        shortcutPreviewManager.onPreviewComplete += OnPreviewComplete;
    }


    private void OnListItemClicked(Shortcut shortcut)
    {
        popUpState = ShortcutPopUpState.EShortcutPopUp.ACTIVE;
        _popUpState.SetPopUpState(popUpState);
        _shortcutListItem.shortcutName.text = shortcut.shortcutName;
        _shortcutListItem.shortcutImage.sprite = shortcut.shortcutSprite;
    }
    
    private void OnPreviewComplete()
    {
        popUpState = ShortcutPopUpState.EShortcutPopUp.INACTIVE;
        _popUpState.SetPopUpState(popUpState);
    }
}
