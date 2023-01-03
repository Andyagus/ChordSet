using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using AR_Keyboard;
using UnityEngine;
using UnityEngine.UI;

public class ShortcutList : MonoBehaviour
{
    [SerializeField] private ShortcutListItem shortcutListItem;
    [SerializeField] private List<Shortcut> shortcuts;
    [SerializeField] private Transform contentParentObject;

    public Action<Shortcut> onListItemClicked;
    public Action onListPopulated;
    
    
    private void Awake()
    {
        foreach (var shortcut in shortcuts)
        {
            var listItem = Instantiate(shortcutListItem, contentParentObject);
            listItem.shortcutName.text = shortcut.shortcutName;
            listItem.shortcutImage.sprite = shortcut.shortcutSprite;
            listItem.shortcutKeys.text = FormatKeysToAccessString(shortcut.keysToAccess);
            listItem.GetComponentInChildren<Button>().onClick.AddListener(() => OnListItemClick(shortcut));
        }
    }

    private void Start()
    {
        if (onListPopulated != null)
        {
            onListPopulated();
        }
    }


    public void HandleInput(Key key)
    {
        
    }

    private void OnListItemClick(Shortcut shortcut)
    {
        onListItemClicked(shortcut);
        gameObject.SetActive(false);
    }
    
    private string FormatKeysToAccessString(List<string> keysToAccess)
    {
        var combinedString = string.Join("\n", keysToAccess);
        TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
        var updatedString = textInfo.ToTitleCase(combinedString);
        if (updatedString.Contains("Left"))
        {
            updatedString = updatedString.Replace("-Left", "");
        }
        if (updatedString.Contains("Right"))
        {
            updatedString = updatedString.Replace("-Right", "");
        }
        
        return updatedString;

        // return string.Join(", ", keysToAccess);
    }
}
