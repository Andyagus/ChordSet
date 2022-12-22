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
}
