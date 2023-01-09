using System;
using System.Collections.Generic;
using System.Globalization;
using Scenes._3MobileAR.Scripts.Keys.Shortcuts;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes._3MobileAR.Scripts.Screen_Space_UI._1Main
{
    /// <summary>
    /// Managing the shortcuts in the ScrollView list. Also handling the individual buttons OnClick events.
    /// </summary>
    public class ShortcutList : MonoBehaviour
    {
        [SerializeField] private ShortcutListItem shortcutListItem;
        [SerializeField] private List<Shortcut> shortcuts;
        [SerializeField] private Transform contentParentObject;
    
        public Action<Shortcut> onListItemClicked;
        public Action onListPopulated;
    
        private void Awake()
        {
            InstantiateShortcuts();
        }
        
        /// <summary>
        /// Instantiate shortcuts for every shortcut in the inspector serialized list.
        /// TODO: Shortcuts should be same instance as shortcuts on ambient mode states (always on the keys) 
        /// </summary>
        private void InstantiateShortcuts()
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
    
        private void OnListItemClick(Shortcut shortcut)
        {
            //When on click event is fired, set the ShortcutList to false
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
        }
    }
}
