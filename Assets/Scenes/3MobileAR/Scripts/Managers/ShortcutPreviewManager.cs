using System.Collections.Generic;
using DG.Tweening;
using Scenes._1Desktop.Scripts;
using Scenes._3MobileAR.Scripts.Keyboard;
using Scenes._3MobileAR.Scripts.Keys;
using Scenes._3MobileAR.Scripts.Keys.Shortcuts;
using UnityEngine;

namespace Scenes._3MobileAR.Scripts.Managers
{
    /// <summary>
    /// This class displays shortcut previews that have been selected from the ScreenSpace UI List.
    /// It works by taking the 'KeysToAccess' on a shortcut and displaying those keys in animation
    /// TODO: Refactor - Would like this class to play more integral role to the app
    /// </summary>
    public class ShortcutPreviewManager : MonoBehaviour
    {
        private ARKeyboard _ARKeyboard;
        private List<Key> _sequenceKeys;
        private ShortcutList _shortcutList;

        [SerializeField] private float appendAmt = 0.72f; 
    
        private void Awake()
        {
            _sequenceKeys = new List<Key>();
            _shortcutList = GameObject.Find("ScreenSpaceUI").GetComponentInChildren<ShortcutList>(true);
            _ARKeyboard = GetComponentInParent<ARKeyboard>();
        }

        private void Start()
        {
            _shortcutList.onListItemClicked += OnListItemClicked;
        }

        private void OnListItemClicked(Shortcut shortcut)
        {
            //Accessing the KeysToAccess Putting them in order in a list (modifier first) 
            foreach (var key in shortcut.keysToAccess)
            {
                if (_ARKeyboard.modifierKeyDictionary.ContainsKey(key))
                {
                    var modifierKey = _ARKeyboard.modifierKeyDictionary[key];
                    _sequenceKeys.Add(modifierKey);
                }
            }
        
            foreach (var key in shortcut.keysToAccess)
            {
                if (_ARKeyboard.primaryKeyDictionary.ContainsKey(key))
                {
                    var primaryKey = _ARKeyboard.primaryKeyDictionary[key];
                    _sequenceKeys.Add(primaryKey);
                }
            }
    
            AnimateKeys();
        }

        private void AnimateKeys()
        {
            var sequence = DOTween.Sequence();
    
            sequence.AppendInterval(appendAmt);
            foreach (var sequenceKey in _sequenceKeys)
            {
                sequence.AppendCallback(() => sequenceKey.keyPressed = EKeyState.KEY_PRESSED);
                sequence.AppendInterval(appendAmt);
            }

            sequence.AppendInterval(appendAmt);
        
            foreach (var sequenceKey in _sequenceKeys)
            {
                sequence.AppendCallback(() => sequenceKey.keyPressed = EKeyState.KEY_UNPRESSED);
            }
            _sequenceKeys.Clear();
        }
    }
}
