using AR_Keyboard;
using AR_Keyboard.State;
using DG.Tweening;
using Enums;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class SelectAllShortcutState : ARKeyboardState
{
    public ARKeyboardState previousState;
    
    public override void Entry(ARKeyboard keyboard)
    {
        Debug.Log("Entered Select All State");
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
