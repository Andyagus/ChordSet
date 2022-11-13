using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using AR_Keyboard;
using AR_Keyboard.State;
using Desktop;
using Effects;
using Enums;
using UnityEngine;

public class State1 : ARKeyboardState
{
    
    public override void Entry(ARKeyboard keyboard)
    {
        foreach (var primaryKey in keyboard.ARPrimaryKeys)
        {
            KeyShortcutManager.PlaceKeyShortcut(primaryKey);
            //you'd want to subscribe here
        }
        
        foreach (var modifierKey in keyboard.ARModifierKeys)
        {
            if(modifierKey.KeyName == "command-left" || modifierKey.KeyName == "command-right")
            {
                KeyColorManager.ChangeKeyColor(modifierKey, Color.yellow);
            }
        }
    }

    public override ARKeyboardState HandleInput(InputKey input, ARKeyboard keyboard)
    {
        foreach (var modifierKey in keyboard.ARModifierKeys)
        {
            if (input.KeyName == modifierKey.KeyName)
            {
                if (modifierKey.KeyName == "command-left" || modifierKey.KeyName == "command-right")
                {
                    // Debug.Log("command released");
                    var state0 = Instantiate(keyboard.states[0]);
                    return state0;
                }
            }
        }

        foreach (var primaryKey in keyboard.ARPrimaryKeys)
        {
            
            if (input.KeyName == primaryKey.KeyName)
            {
                if (primaryKey.shortcuts[1] != null && input.keyState == EKeyState.KEY_PRESSED)
                {
                    
                    //getting the active Shortcut and calling execute on it 
                    primaryKey.GetComponentInChildren<Shortcut>().Execute();

                }
            }
        }
        
        return base.HandleInput(input, keyboard);
    }

    public override void Exit(ARKeyboard keyboard)
    {
        foreach (var primaryKey in keyboard.ARPrimaryKeys)
        {
            if (primaryKey.shortcuts[1] != null)
            {
                KeyShortcutManager.RemoveShortcut(primaryKey);
            }
        }
    }
}
