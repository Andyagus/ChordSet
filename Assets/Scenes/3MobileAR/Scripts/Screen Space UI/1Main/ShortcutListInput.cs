using System;
using System.Collections.Generic;
using System.Linq;
using Scenes._1Desktop.Scripts;
using Scenes._3MobileAR.Scripts.Keys;
using Scenes._3MobileAR.Scripts.Screen_Space_UI._2Utility;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Scenes._3MobileAR.Scripts.Screen_Space_UI._1Main
{
   /// <summary>
   /// Class handles input between Normcore and the UIList.  Handles ability to enter text in text field
   /// and traverse through shortcutList items in the list. 
   /// </summary>
   public class ShortcutListInput : MonoBehaviour
   {
      [Header("Searchbar")]
      private ListSearch _listSearch;
      [SerializeField] private TextMeshProUGUI searchBarPlaceholder;
      [SerializeField] private TextMeshProUGUI searchBarText;
      [SerializeField] private Selectable searchBarSelectable;

      //Access to all shortcuts on the list
      private List<ShortcutListItem> _initialListItems;
      //CurrentListItems holds dynamically updated list items.  Type is gameobject, because it holds both searchbar (always 
      //1st item in list) and the current available list items from search.
      private List<GameObject> _currentListItems;

      //SelectionIndex used to find/select list items.
      private int _selectionIndex;
      
      //When key is 'inputted' OnKeySearchChanged sends current text to ListSearch.
      public Action<string> onKeySearchChanged;

      private void Awake()
      {
         _listSearch = GetComponentInChildren<ListSearch>(true);
         _listSearch.onListItemUpdated += OnListItemUpdated;
         _initialListItems = GetComponentsInChildren<ShortcutListItem>(true).ToList();
         _currentListItems = new List<GameObject>();
         InitializeCurrentListItems();
      }

      /// <summary>
      /// Adding all items to current list (this is before any search)
      /// first item in list is the search bar.  SearchBar can be traversed
      /// like ShortcutListItems
      /// </summary>
      private void InitializeCurrentListItems()
      {
         _currentListItems.Add(searchBarSelectable.gameObject);
         foreach (var item in _initialListItems)
         {
            _currentListItems.Add(item.gameObject);
         }
      }
   
      /// <summary>
      /// OnListItemUpdated is called when ListSearch changes.
      /// Since ListSearch sets Shortcut List Items that dont match
      /// the search query to SetActive(false). The method finds only
      /// active child game objects and adds them to current list..
      /// TODO: Can improve get components in children call here.
      /// </summary>
      private void OnListItemUpdated()
      {
         _currentListItems.Clear();
      
         var tempList = GetComponentsInChildren<ShortcutListItem>(false).ToList();
      
         _currentListItems.Add(searchBarSelectable.gameObject);
         foreach(var item in tempList)
         {
            _currentListItems.Add(item.gameObject);
         }
      }

      private void OnEnable()
      {
         _selectionIndex = 0;
         //Always start list by selecting the SearchBar
         searchBarSelectable.Select();
         searchBarText.text = string.Empty;
         if (!searchBarPlaceholder.gameObject.activeSelf)
         {
            searchBarPlaceholder.gameObject.SetActive(true);
         }
      }
      
      private void OnDisable()
      {
         //Tell the list search to search for nothing (clearing results) and resetting currentList.
         onKeySearchChanged(string.Empty);
      }

   
      //Input being received from ARKeyboard.HandleInput()
      public void HandleInput(Key key)
      {
         Select(key);
         Search(key);
      }

      private void Select(Key key)
      {
         //Scroll through the items in the UIList with Arrow Keys
         if (key.KeyName == "Arrow-Down" && key.keyPressed == EKeyState.KEY_PRESSED)
         {
            if (_selectionIndex < _currentListItems.Count - 1)
            {
               _selectionIndex++;
            }
         }
         if (key.KeyName == "Arrow-Up" && key.keyPressed == EKeyState.KEY_PRESSED)
         {
            if (_selectionIndex > 0)
            {
               _selectionIndex--;
            }
         }

         //If item at currently selected index is a button, select it, otherwise select the searchbar.
         var selectedItem = _currentListItems[_selectionIndex];
         if (selectedItem.GetComponent<Button>() != null)
         {
            selectedItem.GetComponent<Button>().Select();
         }
         else
         {
            searchBarSelectable.Select();
         }
      
         //When Return key is pressed on the button, invoke the buttons OnClick event. 
         //This calls OnListItem clicked on ShortcutList class.
         if (key.KeyName == "Return" && key.keyPressed == EKeyState.KEY_PRESSED)
         {
            if (selectedItem.GetComponent<Button>() != null)
            {
               selectedItem.GetComponent<Button>().onClick.Invoke();
            }
         }
      }

      private void Search(Key key)
      {
         if (EventSystem.current.currentSelectedGameObject == searchBarSelectable.gameObject)
         {
            if (key.keyPressed == EKeyState.KEY_PRESSED)
            {
               if (key.KeyName == "space")
               {
                  searchBarText.text = searchBarText.text + " ";   
               }else if (key.KeyName == "Delete")
               {
                  if (searchBarText.text.Length > 0)
                  {
                     searchBarText.text = searchBarText.text.Remove(searchBarText.text.Length - 1, 1);
                  }
               }else if (key.KeyName == "Arrow-Up" || key.KeyName == "Arrow-Down")
               {
                  return;
               }
               else
               {
                  //Set the search bar text to the currently inputted text. And call OnKeySearchChanged 
                  //with current search string
                  searchBarPlaceholder.gameObject.SetActive(false);
                  searchBarText.text = searchBarText.text + key.KeyName;
               }

               var currentText = searchBarText.text;
               onKeySearchChanged(currentText);
            }

            if (searchBarText.text.Length == 0)
            {
               searchBarPlaceholder.gameObject.SetActive(true);
            }
         }   
      }
   }
}
