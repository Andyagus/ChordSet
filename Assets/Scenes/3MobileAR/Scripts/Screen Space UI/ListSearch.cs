using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AR_Keyboard;
using TMPro;
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

    void Start()
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
    //
    // private void OnEnable()
    // {
    //     tmpInput.Select();
    // }
    //
    // private void OnDisable()
    // {
    //     tmpInput.text = "";
    // }
    //
    
    // public void SearchList()
    // {
    //     // _shortcutListItem.
    // }
    
    // public void SearchList()
    // {
    //     var searchText = tmpInput.text;
    //     
    //     foreach (var item in _shortcutListItems)
    //     {
    //         if (item.shortcutName.text.Length >= searchText.Length)
    //         {
    //             if (searchText.ToLower() == item.shortcutName.text.Substring(0, searchText.Length).ToLower())
    //             {
    //                 item.gameObject.SetActive(true);
    //             }
    //             else
    //             {
    //                 item.gameObject.SetActive(false);
    //             }
    //         }
    //     }
    //
    //     onListItemChanged();
    //
    // }
    
}
