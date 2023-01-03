using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Enums;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShortcutListInput : MonoBehaviour
{
   private ShortcutList _shortcutList;
   private ScrollRect _scrollRect;
   private List<ShortcutListItem> _shortcutListItems;

   private List<GameObject> _listItems;
   
   private TMP_InputField _searchBar;
   
   private int _itemIndex = 0;
   
   private void Awake()
   {
      _shortcutList = GetComponent<ShortcutList>();
      _scrollRect = GetComponentInChildren<ScrollRect>();
      _searchBar = GetComponentInChildren<TMP_InputField>(true);
   }
   
   private void Start()
   {
      // _searchBar.Select();
      _shortcutListItems = _scrollRect.GetComponentsInChildren<ShortcutListItem>().ToList();

      _listItems = new List<GameObject>();
      _listItems.Add(_searchBar.gameObject);

      foreach (var item in _shortcutListItems)
      {
         _listItems.Add(item.gameObject);
      }
      
      Debug.Log("Scroll rect count: " + _shortcutListItems.Count);
   }

   private void OnEnable()
   {
      // var currentItem = _listItems[_itemIndex];
      // currentItem.GetComponent<TMP_InputField>().Select();
   }


   public void HandleInput(Key key)
   {

      // var currentItem = _listItems[_itemIndex];
      // currentItem.GetComponent<TMP_InputField>().Select();
      
      _searchBar.Select();
      _searchBar.ActivateInputField();

      if (_searchBar.isFocused)
      {
         if (key.keyPressed == EKeyState.KEY_PRESSED)
         {
            _searchBar.DeactivateInputField();
            _searchBar.text = _searchBar.text + key.KeyName;
         }
         
      }

      // if (_searchBar.isFocused)
      // {
      //    if (key.keyPressed == EKeyState.KEY_PRESSED)
      //    {
      //       _searchBar.text = key.KeyName;
      //    }
      // }

      // if (key.KeyName == "Arrow-Down" && key.keyPressed == EKeyState.KEY_PRESSED)
      // {
      //    _shortcutListItems[_currentItem].GetComponent<Button>().Select();
      // }
      //
      // if (key.KeyName == "Return" && key.keyPressed == EKeyState.KEY_PRESSED)
      // {
      //    _shortcutListItems[_currentItem].GetComponent<Button>().onClick.Invoke();
      // }
   }
}
