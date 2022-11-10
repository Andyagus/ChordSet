using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using AR_Keyboard.State;
using Desktop;
using Effects;
using UnityEngine;

public class State1 : ARKeyboardState
{
    public override void Entry(ARKeyboard keyboard)
    {

        foreach (var primaryKey in keyboard.ARPrimaryKeys)
        {
            if (primaryKey.KeyName == "C")
            {
                KeyShortcutManager.PlaceKeyShortcut(primaryKey);
                // KeyShortcutManager(key)
            }
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
        return base.HandleInput(input, keyboard);
    }

    public override void Exit(ARKeyboard keyboard)
    {
        
        
        foreach (var primaryKey in keyboard.ARPrimaryKeys)
        {
            if (primaryKey.KeyName == "C")
            {
                KeyShortcutManager.RemoveShortcut(primaryKey);
                // KeyShortcutManager(key)
            }
        }
    }
}
