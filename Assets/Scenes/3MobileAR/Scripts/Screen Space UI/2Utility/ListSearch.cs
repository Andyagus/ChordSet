using System;
using System.Collections.Generic;
using System.Linq;
using Scenes._3MobileAR.Scripts.Screen_Space_UI._1Main;
using UnityEngine;

namespace Scenes._3MobileAR.Scripts.Screen_Space_UI._2Utility
{
    public class ListSearch : MonoBehaviour
    {

        private ShortcutList _shortcutList;
        private List<ShortcutListItem> _shortcutListItems;
        private ShortcutListInput _shortcutListInput;
        public Action onListItemUpdated;
    
        private void Awake()
        {
            _shortcutList = GetComponentInParent<ShortcutList>();
            _shortcutList.onListPopulated += OnListPopulated;
            _shortcutListInput = GetComponentInParent<ShortcutListInput>();
            _shortcutListInput.onKeySearchChanged += ValidateListItem;
        }

        private void OnListPopulated()
        {
            _shortcutListItems = GetComponentsInChildren<ShortcutListItem>().ToList();
        }
        
        /// <summary>
        /// Called when a new key is inputted in ShortcutListInput. Compares each shortcut
        /// to the passed in string and sets gameObject to active or inactive accordingly 
        /// </summary>
        private void ValidateListItem(string currentSearchString)
        {
            foreach(var shortcut in _shortcutListItems){
                if (shortcut.shortcutName.text.Length >= currentSearchString.Length)
                {
                    gameObject.SetActive(currentSearchString.ToLower() ==
                                         shortcut.shortcutName.text.Substring(0, currentSearchString.Length).ToLower());
                }
            }

            //When search is updated onListItemUpdated is called for ShortcutListInput to refresh its current list
            if (onListItemUpdated != null)
            {
                onListItemUpdated();
            }
        }   
    }
}
