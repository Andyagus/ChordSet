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
    [SerializeField] private ShortcutList shortcutList;
    private List<Key> _sequenceKeys;
    public Action onPreviewComplete;
    
    private void Awake()
    {
        _sequenceKeys = new List<Key>();
        _keyboard = GetComponentInParent<ARKeyboard>();
    }

    private void Start()
    {
        shortcutList.onListItemClicked += OnListItemClicked;
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
        
        // sequence.AppendInterval(0.72f);

        sequence.AppendCallback(() =>
        {
            onPreviewComplete();
        });
        
        foreach (var sequenceKey in _sequenceKeys)
        {
            sequence.AppendCallback(() => sequenceKey.keyPressed = EKeyState.KEY_UNPRESSED);
        }

        
        _sequenceKeys.Clear();
    }
}
