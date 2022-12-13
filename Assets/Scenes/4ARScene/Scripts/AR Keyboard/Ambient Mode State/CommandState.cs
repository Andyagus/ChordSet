using System.Collections;
using System.Collections.Generic;
using Effects;
using Enums;
using UnityEngine;

namespace AR_Keyboard.State
{
    public class CommandState : ARKeyboardState
    {
        public ARKeyboardState typingState;
        
        public override void Entry(ARKeyboard keyboard)
        {
            foreach (var primaryKey in keyboard.primaryKeys)
            {
                primaryKey.keyShortcutState = KeyShortcutState.EKeyShortcutState.COMMAND_STATE_SHORTCUT;
            }
        }
        
        public override ARKeyboardState HandleInput(Key key, ARKeyboard keyboard)
        {
            if (key.GetComponentInChildren<ARPrimaryKey>() != null)
            {
                var primaryKey = key.GetComponentInChildren<ARPrimaryKey>();
                    if (primaryKey.GetComponentInChildren<Shortcut>() != null)
                    {
                        var currentShortcut = primaryKey.GetComponentInChildren<Shortcut>();
                        currentShortcut.Execute(primaryKey);
                    }
            }
            
            if (key.KeyName == "command-left" && key.keyPressed == EKeyState.KEY_UNPRESSED)
            {
                return Instantiate(typingState);
            }
            else
            {
                return null;
            }
        }
        
        public override void Exit(ARKeyboard keyboard)
        {
        }
    }
}
