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

   private void OnDisable()
   {
      _itemIndex = 0;
   }

   public void HandleInput(Key key)
   {
      
      if (key.KeyName == "Arrow-Down" && key.keyPressed == EKeyState.KEY_PRESSED)
      {
         _itemIndex++;
      }
      
      if (key.KeyName == "Arrow-Up" && key.keyPressed == EKeyState.KEY_PRESSED)
      {
         _itemIndex--;
      }
      
      var currentItem = _listItems[_itemIndex];
      
      if (currentItem.GetComponent<TMP_InputField>() != null)
      {
         var searchBar =currentItem.GetComponent<TMP_InputField>(); 
         searchBar.Select();
         searchBar.ActivateInputField();

         if (searchBar.isFocused)
         {
            if (key.keyPressed == EKeyState.KEY_PRESSED)
            {
               if (key.KeyName != null)
               {


               }
               if(key.KeyName == "X")
               {
                  searchBar.text = searchBar.text.Remove(searchBar.text.Length - 1, 1);
               }
               if (key.KeyName == "Arrow-Down" || key.KeyName == "Arrow-Up")
               {
                  return;
               }
               else
               {
                  searchBar.text = searchBar.text + key.KeyName;
                  searchBar.MoveTextEnd(false);

               }
            }
         }
         
      }else if (currentItem.GetComponent<Button>() != null)
      {
         var listButton = currentItem.GetComponent<Button>();
         listButton.Select();
      }
 
      if (key.KeyName == "Return" && key.keyPressed == EKeyState.KEY_PRESSED)
      {
         if (_shortcutListItems[_itemIndex].GetComponent<Button>() != null)
         {
            _shortcutListItems[_itemIndex].GetComponent<Button>().onClick.Invoke();
         }
      }
   }
}
