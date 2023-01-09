using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ListSearch : MonoBehaviour
{

    private ShortcutList _shortcutList;
    private List<ShortcutListItem> _shortcutListItems;
    private ShortcutListInput _shortcutListInput;
    public Action onListItemUpdated;
    
    private void Awake()
    {
        _shortcutList = GetComponentInParent<ShortcutList>();
        // _shortcutListItems = GetComponent<ShortcutListItem>();
        _shortcutListInput = GetComponentInParent<ShortcutListInput>();

        _shortcutList.onListPopulated += OnListPopulated;
        _shortcutListInput.onKeySearchChanged += ValidateListItem;
        // _shortcutListInput.onKeySearchChanged += SearchList;
    }

    private void OnListPopulated()
    {
        _shortcutListItems = GetComponentsInChildren<ShortcutListItem>().ToList();
    }

    private void Start()
    {
        // _shortcutListItems = content.GetComponentsInChildren<ShortcutListItem>().ToList();
        // onListItemChanged();

    }
    
    private void ValidateListItem(string currentSearchString)
    {
        foreach(var shortcut in _shortcutListItems){
            if (shortcut.shortcutName.text.Length >= currentSearchString.Length)
            {
                if (currentSearchString.ToLower() == shortcut.shortcutName.text.Substring(0, currentSearchString.Length).ToLower())
                {
                    gameObject.SetActive(true);
                }
                else
                {
                    gameObject.SetActive(false);
                }
            }
        }

        if (onListItemUpdated != null)
        {
            onListItemUpdated();
        }
    }   
}
