using System.Collections.Generic;
using AR_Keyboard;
using AR_Keyboard.State;
using DG.Tweening;
using Enums;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class UndoShortcutState : LearningModeState
{
    private Sequence highlightKeySequence;
    
    public override void Entry(ARKeyboard keyboard)
    {
        var zPrimaryKey = keyboard.primaryKeyDictionary["Z"];
        var commandModifierKey = keyboard.modifierKeyDictionary["command-left"];
        
        keysInShortcut = new List<Key>()
        {
            zPrimaryKey,
            commandModifierKey
        };

        DisplayShortcutKeys();
        
        highlightKeySequence = DOTween.Sequence();
        highlightKeySequence.AppendInterval(1.3742f);
        highlightKeySequence.AppendCallback(() => commandModifierKey.keyPressed = EKeyState.KEY_PRESSED);
        highlightKeySequence.AppendInterval(0.75f);
        highlightKeySequence.AppendCallback(() => zPrimaryKey.keyPressed = EKeyState.KEY_PRESSED);
        highlightKeySequence.AppendInterval(0.3f);
        highlightKeySequence.AppendCallback(() => zPrimaryKey.keyPressed = EKeyState.KEY_UNPRESSED);
        highlightKeySequence.AppendInterval(0.45f);
        highlightKeySequence.AppendCallback(() => commandModifierKey.keyPressed = EKeyState.KEY_UNPRESSED);
        
    }

    public override ARKeyboardState HandleInput(Key key, ARKeyboard keyboard)
    {
        if (key.KeyName == "right-arrow" && key.keyPressed == EKeyState.KEY_PRESSED)
        {
            var state = Instantiate(nextState);
            return state;
        }
        return base.HandleInput(key, keyboard);
    }

    public override void Exit(ARKeyboard keyboard)
    {
        highlightKeySequence.Kill();
        var zKey = keyboard.primaryKeyDictionary["Z"];
        zKey.keyOutline = KeyOutlineState.EKeyOutline.NO_OUTLINE;
    }
}
