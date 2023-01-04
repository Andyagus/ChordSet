using System;
using System.Collections;
using System.Collections.Generic;
using AR_Keyboard;
using DG.Tweening;
using Enums;
using TMPro;
using UnityEngine;

public class ShortcutPreviewManager : MonoBehaviour
{
    private ARKeyboard _keyboard;
    private List<Key> _sequenceKeys;
    private ShortcutList _shortcutList;
    public Action onPreviewComplete;
    
    private void Awake()
    {
        _sequenceKeys = new List<Key>();
        _shortcutList = GameObject.Find("ScreenSpaceUI").GetComponentInChildren<ShortcutList>(true);
        _keyboard = GetComponentInParent<ARKeyboard>();
    }

    private void Start()
    {
        _shortcutList.onListItemClicked += OnListItemClicked;
    }

    private void OnListItemClicked(Shortcut shortcut)
    {
        //conducting seperate loops so in order
        foreach (var key in shortcut.keysToAccess)
        {
            if (_keyboard.modifierKeyDictionary.ContainsKey(key))
            {
                var modifierKey = _keyboard.modifierKeyDictionary[key];
                _sequenceKeys.Add(modifierKey);
            }
        }
        
        foreach (var key in shortcut.keysToAccess)
        {
            if (_keyboard.primaryKeyDictionary.ContainsKey(key))
            {
                var primaryKey = _keyboard.primaryKeyDictionary[key];
                _sequenceKeys.Add(primaryKey);
            }
        }
    
        CreateSequence();
    }

    private void CreateSequence()
    {
        var sequence = DOTween.Sequence();
    
        sequence.AppendInterval(0.72f);
        foreach (var sequenceKey in _sequenceKeys)
        {
            sequence.AppendCallback(() => sequenceKey.keyPressed = EKeyState.KEY_PRESSED);
            sequence.AppendInterval(0.72f);
        }
        
        
        sequence.AppendInterval(0.72f);
        
        //TODO Add callback in future
        //
        // sequence.AppendCallback(() =>
        // {
        //     onPreviewComplete();
        // });
        //
        
        foreach (var sequenceKey in _sequenceKeys)
        {
            sequence.AppendCallback(() => sequenceKey.keyPressed = EKeyState.KEY_UNPRESSED);
        }
    
        
        _sequenceKeys.Clear();
    }
}
