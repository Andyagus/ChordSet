using System.Collections.Generic;
using AR_Keyboard;
using AR_Keyboard.State;
using DG.Tweening;
using Enums;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class SelectAllShortcutState : LearningModeState
{
    
    private Sequence _highlightKeySequence;
    
    public override void Entry(ARKeyboard keyboard)
    {
        var cmdLeftModifierKey = keyboard.modifierKeyDictionary["command-left"];
        var shiftLeftModifierKey = keyboard.modifierKeyDictionary["shift-left"];
        // shiftLeftModifierKey.ResetState();
        var aPrimaryKey = keyboard.primaryKeyDictionary["A"];
        
        keysInShortcut = new List<Key>()
        {
            cmdLeftModifierKey,
            shiftLeftModifierKey,
            aPrimaryKey
        };
        
        DisplayShortcutKeys();
        
        _highlightKeySequence = DOTween.Sequence();
        _highlightKeySequence.AppendInterval(1.3742f);
        _highlightKeySequence.AppendCallback(() => cmdLeftModifierKey.keyPressed = EKeyState.KEY_PRESSED);
        _highlightKeySequence.AppendInterval(0.75f);
        _highlightKeySequence.AppendCallback(() => shiftLeftModifierKey.keyPressed = EKeyState.KEY_PRESSED);
        _highlightKeySequence.AppendInterval(1f);
        _highlightKeySequence.AppendCallback(() => aPrimaryKey.keyPressed = EKeyState.KEY_PRESSED);
        _highlightKeySequence.AppendInterval(0.25f);
        _highlightKeySequence.AppendCallback(() => aPrimaryKey.keyPressed = EKeyState.KEY_UNPRESSED);
        _highlightKeySequence.AppendInterval(1f);
        _highlightKeySequence.AppendCallback(() => shiftLeftModifierKey.keyPressed = EKeyState.KEY_UNPRESSED);
        _highlightKeySequence.AppendInterval(0.3f);
        _highlightKeySequence.AppendCallback(() => cmdLeftModifierKey.keyPressed = EKeyState.KEY_UNPRESSED);

    }

    public override ARKeyboardState HandleInput(Key key, ARKeyboard keyboard)
    {
        if (key.KeyName == "left-arrow" && key.keyPressed == EKeyState.KEY_PRESSED)
        {
            var state = Instantiate(previousState);
            return state;
        }
        return base.HandleInput(key, keyboard);
    }

    public override void Exit(ARKeyboard keyboard)
    {
        DiscardShortcutKeys();
    }
}

