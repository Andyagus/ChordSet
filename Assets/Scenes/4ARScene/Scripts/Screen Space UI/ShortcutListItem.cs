using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShortcutListItem : MonoBehaviour
{
    public TextMeshProUGUI shortcutName;
    public Image shortcutImage;
    public TextMeshProUGUI shortcutKeys;
    
    //related to search
    private ShortcutListInput _shortcutListInput;

    public Action onListItemUpdated;
    
    private void Awake()
    {
        _shortcutListInput = GetComponentInParent<ShortcutListInput>(true);
        _shortcutListInput.onKeySearchChanged += ValidateListItem;
        // onListItemUpdated();
    }
    
    //functions as a 'search' - if does not meet conditions, set unactive 
    private void ValidateListItem(string currentSearchString)
    {

        if (shortcutName.text.Length >= currentSearchString.Length)
        {
            if (currentSearchString.ToLower() == shortcutName.text.Substring(0, currentSearchString.Length).ToLower())
            {
                gameObject.SetActive(true);
            }
            else
            {
                gameObject.SetActive(false);
            }

            onListItemUpdated();
        }
    }
}

// if (item.shortcutName.text.Length >= searchText.Length)
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
