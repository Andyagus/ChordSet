using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Enums;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ShortcutListInput : MonoBehaviour
{
   private ShortcutList _shortcutList;
   private ScrollRect _scrollRect;


   public Selectable inputSelectable;
   public TextMeshProUGUI inputText; 
   
   private TMP_InputField _searchBar;

   private ListSearch _listSearch;
   [SerializeField] private List<ShortcutListItem> currentListItems;
   
   [SerializeField] private List<GameObject> listItems;
   private List<ShortcutListItem> _shortcutListItems;
   [SerializeField] private int itemIndex = 0;
   
   private void Awake()
   {
      InputSystem.DisableDevice(Keyboard.current);
      //
      // _shortcutList = GetComponent<ShortcutList>();
      // _listSearch = GetComponentInChildren<ListSearch>();
      // _scrollRect = GetComponentInChildren<ScrollRect>();
      // _searchBar = GetComponentInChildren<TMP_InputField>(true);
      //
      // listItems = new List<GameObject>();
      // listItems.Add(_searchBar.gameObject);
      // _listSearch.onListItemChanged += OnListItemChanged;
   }

   private void OnListItemChanged()
   {
      // currentListItems = GetComponentsInChildren<ShortcutListItem>(false).ToList();
      // listItems.Clear();
      // listItems.Add(_searchBar.gameObject);
      //
      // foreach (var item in currentListItems)
      // {
      //    listItems.Add(item.gameObject);
      // }
      //
      // Debug.Log("Current List Items count: " +  currentListItems.Count);
      //
   }

   private void Start()
   {
      // _searchBar.Select();
      // _shortcutListItems = _scrollRect.GetComponentsInChildren<ShortcutListItem>().ToList();

      // listItems = new List<GameObject>();
      // listItems.Add(_searchBar.gameObject);
      //
      // foreach (var item in _shortcutListItems)
      // {
      //    listItems.Add(item.gameObject);
      // }
      
   }
   //
   //
   // private void OnEnable()
   // {
   //    TouchScreenKeyboard.hideInput = true;
   //    _searchBar.Select();
   //    _searchBar.ActivateInputField();
   // }
   //
   // private void OnDisable()
   // {
   //    itemIndex = 0;
   // }

   public void HandleInput(Key key)
   {
      
      if (EventSystem.current.currentSelectedGameObject == inputSelectable.gameObject)
      {
         inputText.text = (inputText.text + key.KeyName);
      } 
      // if (key.KeyName == "Arrow-Down" && key.keyPressed == EKeyState.KEY_PRESSED)
      // {
      //
      //    if (itemIndex < listItems.Count-1)
      //    {
      //       itemIndex++;
      //    }
      // }
      //
      // if (key.KeyName == "Arrow-Up" && key.keyPressed == EKeyState.KEY_PRESSED)
      // {
      //    if (itemIndex > 0)
      //    {
      //       itemIndex--;
      //    }
      // }

      // var currentItem = listItems[itemIndex];
      //
      // if (currentItem.GetComponent<TMP_InputField>() != null)
      // {
      //    var searchBar =currentItem.GetComponent<TMP_InputField>(); 
      //    searchBar.Select();
      //    searchBar.ActivateInputField();
      //
      //    if (searchBar.isFocused)
      //    {
      //       if (key.keyPressed == EKeyState.KEY_PRESSED)
      //       {
      //          if(key.KeyName == "Delete")
      //          {
      //             searchBar.text = searchBar.text.Remove(searchBar.text.Length - 1, 1);
      //          }
      //          else if (key.KeyName == "Arrow-Down" || key.KeyName == "Arrow-Up")
      //          {
      //             return;
      //          }
      //          else if (key.KeyName == "space")
      //          {
      //             searchBar.text = searchBar.text + " ";
      //          }
      //          else
      //          {
      //             searchBar.text = searchBar.text + key.KeyName;
      //             searchBar.MoveTextEnd(false);
      //          }
      //       }
      //    }
      //    
      // }else if (currentItem.GetComponent<Button>() != null)
      // {
      //    var listButton = currentItem.GetComponent<Button>();
      //    listButton.Select();
      // }
      //
      // if (key.KeyName == "Return" && key.keyPressed == EKeyState.KEY_PRESSED)
      // {
      //    if (listItems[itemIndex].GetComponent<Button>() != null)
      //    {
      //       listItems[itemIndex].GetComponent<Button>().onClick.Invoke();
      //    }
      // }
   }
}
