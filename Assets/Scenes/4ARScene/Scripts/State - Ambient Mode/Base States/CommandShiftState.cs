using System.Collections;
using System.Collections.Generic;
using AR_Keyboard;
using AR_Keyboard.State;
using Enums;
using UnityEngine;

public class CommandShiftState : ARKeyboardState
{
    public ARKeyboardState CommandState;
    
    public override void Entry(ARKeyboard keyboard)
    {
        foreach (var primaryKey in keyboard.primaryKeys)
        {
            
            primaryKey.keyShortcutState = KeyShortcutState.EKeyShortcutState.NO_SHORTCUT;
            // primaryKey.keyAvailability = KeyAvailabilityState.EKeyAvailability.UNAVAILABLE;

            var shortcutState = primaryKey.GetComponentInChildren<KeyShortcutState>();
            if (shortcutState.commandShiftStateShortcut != null)
            {
                primaryKey.keyShortcutState = KeyShortcutState.EKeyShortcutState.COMMAND_SHIFT_STATE_SHORTCUT;
            }
            else
            {
                // primaryKey.keyAvailability = KeyAvailabilityState.EKeyAvailability.UNAVAILABLE;
            }
            
        }

        foreach (var modifierKey in keyboard.modifierKeys)
        {
            
        }

    }

    public override ARKeyboardState HandleInput(Key key, ARKeyboard keyboard)
    {
        if (key.KeyName == "shift-left" && key.keyPressed == EKeyState.KEY_UNPRESSED)
        {
            var commandState = Instantiate(CommandState);
            return commandState;
        }

        return null;
    }
}
