using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AR_Keyboard;
using TMPro;
using UnityEngine;

public class ListSearch : MonoBehaviour
{
    [SerializeField] private TMP_InputField tmpInput; 
    [SerializeField] private Transform content;
    // private List<Shortcut> _shortcuts;
    private List<ShortcutListItem> _shortcutListItems;
    void Start()
    {
        _shortcutListItems = content.GetComponentsInChildren<ShortcutListItem>().ToList();
    }

    private void OnEnable()
    {
        tmpInput.Select();
    }

    private void OnDisable()
    {
        tmpInput.text = "";
    }

    public void SearchList()
    {
        var searchText = tmpInput.text;
        
        foreach (var item in _shortcutListItems)
        {
            if (item.shortcutName.text.Length >= searchText.Length)
            {
                if (searchText.ToLower() == item.shortcutName.text.Substring(0, searchText.Length).ToLower())
                {
                    item.gameObject.SetActive(true);
                }
                else
                {
                    item.gameObject.SetActive(false);
                }
            }
            
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
