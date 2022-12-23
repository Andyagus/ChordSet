using System.Collections.Generic;
using AR_Keyboard;
using AR_Keyboard.State;
using DG.Tweening;
using Enums;
using TMPro;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class UndoShortcutState : LearningModeState
{
    private Sequence _highlightKeySequence;
    
    public override void Entry(ARKeyboard keyboard)
    {
        var zPrimaryKey = keyboard.primaryKeyDictionary["Z"];
        zPrimaryKey.isInLearningMode = true;
        zPrimaryKey.keyOutline = KeyOutlineState.EKeyOutline.OUTLINE;
        zPrimaryKey.keyAvailability = KeyAvailabilityState.EKeyAvailability.AVAILABLE;
        
        // zPrimaryKey.LearningModeAvailable();
        // zPrimaryKey.PrimaryKeyAvailable();

        // var commandModifierKey = keyboard.modifierKeyDictionary["command-left"];
        //
        // keysInShortcut = new List<Key>()
        // {
        //     zPrimaryKey,
        //     commandModifierKey
        // };
        //
        // zPrimaryKey.keyOutline = KeyOutlineState.EKeyOutline.OUTLINE;
        // zPrimaryKey.isInLearningMode = true;
        // DisplayShortcutKeys();

        // _highlightKeySequence = DOTween.Sequence();
        // _highlightKeySequence.AppendInterval(1.3742f);
        // _highlightKeySequence.AppendCallback(() => commandModifierKey.keyPressed = EKeyState.KEY_PRESSED);
        // _highlightKeySequence.AppendInterval(0.75f);
        // _highlightKeySequence.AppendCallback(() => zPrimaryKey.keyPressed = EKeyState.KEY_PRESSED);
        // _highlightKeySequence.AppendInterval(0.3f);
        // _highlightKeySequence.AppendCallback(() => zPrimaryKey.keyPressed = EKeyState.KEY_UNPRESSED);
        // _highlightKeySequence.AppendInterval(0.45f);
        // _highlightKeySequence.AppendCallback(() => commandModifierKey.keyPressed = EKeyState.KEY_UNPRESSED);

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
        keyboard.primaryKeyDictionary["Z"].keyOutline = KeyOutlineState.EKeyOutline.NO_OUTLINE;
        keyboard.primaryKeyDictionary["Z"].isInLearningMode = false;
        _highlightKeySequence.Kill();
        // DiscardShortcutKeys();
    }
}
