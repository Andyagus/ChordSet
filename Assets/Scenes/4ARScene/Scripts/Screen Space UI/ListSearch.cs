using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AR_Keyboard;
using TMPro;
using UnityEngine;

public class ListSearch : MonoBehaviour
{

    private ShortcutListItem _shortcutListItem;
    private ShortcutListInput _shortcutListInput;
    public Action onListItemChanged;

    private void Awake()
    {
        _shortcutListItem = GetComponent<ShortcutListItem>();
        _shortcutListInput = GetComponentInParent<ShortcutListInput>();
        // _shortcutListInput.onKeySearchChanged += SearchList;
    }

    void Start()
    {
        // _shortcutListItems = content.GetComponentsInChildren<ShortcutListItem>().ToList();
        // onListItemChanged();

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
