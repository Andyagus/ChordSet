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
   // private ShortcutList _shortcutList;
   // private ScrollRect _scrollRect;
   //
   //
   // public Selectable inputSelectable;
   // public TextMeshProUGUI inputText; 
   //
   // private TMP_InputField _searchBar;
   //
   // private ListSearch _listSearch;
   // [SerializeField] private List<ShortcutListItem> currentListItems;
   //
   // [SerializeField] private List<GameObject> listItems;
   // private List<ShortcutListItem> _shortcutListItems;
   // [SerializeField] private int itemIndex = 0;
   //
   // private void Awake()
   // {
   //    InputSystem.DisableDevice(Keyboard.current);
   //    //
   //    // _shortcutList = GetComponent<ShortcutList>();
   //    // _listSearch = GetComponentInChildren<ListSearch>();
   //    // _scrollRect = GetComponentInChildren<ScrollRect>();
   //    // _searchBar = GetComponentInChildren<TMP_InputField>(true);
   //    //
   //    // listItems = new List<GameObject>();
   //    // listItems.Add(_searchBar.gameObject);
   //    // _listSearch.onListItemChanged += OnListItemChanged;
   // }
   //
   // private void OnListItemChanged()
   // {
   //    // currentListItems = GetComponentsInChildren<ShortcutListItem>(false).ToList();
   //    // listItems.Clear();
   //    // listItems.Add(_searchBar.gameObject);
   //    //
   //    // foreach (var item in currentListItems)
   //    // {
   //    //    listItems.Add(item.gameObject);
   //    // }
   //    //
   //    // Debug.Log("Current List Items count: " +  currentListItems.Count);
   //    //
   // }
   //
   // private void Start()
   // {
   //    // _searchBar.Select();
   //    // _shortcutListItems = _scrollRect.GetComponentsInChildren<ShortcutListItem>().ToList();
   //
   //    // listItems = new List<GameObject>();
   //    // listItems.Add(_searchBar.gameObject);
   //    //
   //    // foreach (var item in _shortcutListItems)
   //    // {
   //    //    listItems.Add(item.gameObject);
   //    // }
   //    
   // }
   // //
   // //
   // // private void OnEnable()
   // // {
   // //    TouchScreenKeyboard.hideInput = true;
   // //    _searchBar.Select();
   // //    _searchBar.ActivateInputField();
   // // }
   // //
   // // private void OnDisable()
   // // {
   // //    itemIndex = 0;
   // // }
   //
   // public void HandleInput(Key key)
   // {
   //    
   //    if (EventSystem.current.currentSelectedGameObject == inputSelectable.gameObject)
   //    {
   //       inputText.text = (inputText.text + key.KeyName);
   //    } 
   //    // if (key.KeyName == "Arrow-Down" && key.keyPressed == EKeyState.KEY_PRESSED)
   //    // {
   //    //
   //    //    if (itemIndex < listItems.Count-1)
   //    //    {
   //    //       itemIndex++;
   //    //    }
   //    // }
   //    //
   //    // if (key.KeyName == "Arrow-Up" && key.keyPressed == EKeyState.KEY_PRESSED)
   //    // {
   //    //    if (itemIndex > 0)
   //    //    {
   //    //       itemIndex--;
   //    //    }
   //    // }
   //
   //    // var currentItem = listItems[itemIndex];
   //    //
   //    // if (currentItem.GetComponent<TMP_InputField>() != null)
   //    // {
   //    //    var searchBar =currentItem.GetComponent<TMP_InputField>(); 
   //    //    searchBar.Select();
   //    //    searchBar.ActivateInputField();
   //    //
   //    //    if (searchBar.isFocused)
   //    //    {
   //    //       if (key.keyPressed == EKeyState.KEY_PRESSED)
   //    //       {
   //    //          if(key.KeyName == "Delete")
   //    //          {
   //    //             searchBar.text = searchBar.text.Remove(searchBar.text.Length - 1, 1);
   //    //          }
   //    //          else if (key.KeyName == "Arrow-Down" || key.KeyName == "Arrow-Up")
   //    //          {
   //    //             return;
   //    //          }
   //    //          else if (key.KeyName == "space")
   //    //          {
   //    //             searchBar.text = searchBar.text + " ";
   //    //          }
   //    //          else
   //    //          {
   //    //             searchBar.text = searchBar.text + key.KeyName;
   //    //             searchBar.MoveTextEnd(false);
   //    //          }
   //    //       }
   //    //    }
   //    //    
   //    // }else if (currentItem.GetComponent<Button>() != null)
   //    // {
   //    //    var listButton = currentItem.GetComponent<Button>();
   //    //    listButton.Select();
   //    // }
   //    //
   //    // if (key.KeyName == "Return" && key.keyPressed == EKeyState.KEY_PRESSED)
   //    // {
   //    //    if (listItems[itemIndex].GetComponent<Button>() != null)
   //    //    {
   //    //       listItems[itemIndex].GetComponent<Button>().onClick.Invoke();
   //    //    }
   //    // }
   // }

   private ShortcutList _shortcutList;
   private ListSearch _listSearch;
   [SerializeField] private TextMeshProUGUI searchBarPlaceholder;
   [SerializeField] private TextMeshProUGUI searchBarText;
   [SerializeField] private Selectable searchBarSelectable;

   private List<ShortcutListItem> _initialListItems;
   private List<GameObject> _currentListItems;

   private int _selectionIndex = 0;
   
   
   public Action<string> onKeySearchChanged;

   private void Awake()
   {
      _shortcutList = GetComponent<ShortcutList>();
      _listSearch = GetComponentInChildren<ListSearch>(true);
      _listSearch.onListItemUpdated += OnListItemUpdated;
      _currentListItems = new List<GameObject>();
      _initialListItems = GetComponentsInChildren<ShortcutListItem>(true).ToList();
      InitializeCurrentListItems();
   }

   private void InitializeCurrentListItems()
   {
      _currentListItems.Add(searchBarSelectable.gameObject);
      foreach (var item in _initialListItems)
      {
         _currentListItems.Add(item.gameObject);
      }
   }
   

   private void OnListItemUpdated()
   {
      _currentListItems.Clear();
      
      var tempList = GetComponentsInChildren<ShortcutListItem>(false).ToList();
      
      _currentListItems.Add(searchBarSelectable.gameObject);
      foreach(var item in tempList)
      {
         _currentListItems.Add(item.gameObject);
      }

      Debug.Log(_currentListItems.Count);
   }

   private void OnEnable()
   {
      _selectionIndex = 0;
      searchBarSelectable.Select();
      searchBarText.text = string.Empty;
   }
   
   public void HandleInput(Key key)
   {
      Search(key);
      Select(key);
   }

   private void Select(Key key)
   {
      // var itemType = Getcom
      
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

      var selectedItem = _currentListItems[_selectionIndex];
      
      if (selectedItem.GetComponent<Button>() != null)
      {
         selectedItem.GetComponent<Button>().Select();
      }
      else
      {
         searchBarSelectable.Select();
      }
      
      if (key.KeyName == "Return" && key.keyPressed == EKeyState.KEY_PRESSED)
      {
         if (selectedItem.GetComponent<Button>() != null)
         {
            selectedItem.GetComponent<Button>().onClick.Invoke();
         }
      }
      
      // if (_currentListItems[_selectionIndex].GetComponent<Button>() != null)
      // {
      //    
      // }
      
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
               searchBarText.text = searchBarText.text.Remove(searchBarText.text.Length - 1, 1);
            }else if (key.KeyName == "Arrow-Up" || key.KeyName == "Arrow-Down")
            {
               return;
            }
            else
            {
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
