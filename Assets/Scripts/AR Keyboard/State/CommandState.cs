using Effects;
using Enums;
using UnityEngine;

namespace AR_Keyboard.State
{
    public class CommandState : ARKeyboardState
    {
        public override void Entry(ARKeyboard keyboard)
        {
            foreach (var modifierKey in keyboard.ARModifierKeys)
            {
                if (modifierKey.KeyName == "command-left" || modifierKey.KeyName == "command-right")
                {
                    KeyColorManager.ChangeKeyColor(modifierKey, Color.yellow);
                }
            }

            foreach (var primaryKey in keyboard.ARPrimaryKeys)
            {
                KeyShortcutManager.PlaceKeyShortcut(primaryKey, this);
            }
        }

        public override ARKeyboardState HandleInput(string keyName, EKeyState keyState, ARKeyboard keyboard)
        {
            foreach (var modifierKey in keyboard.ARModifierKeys)
            {
                if (modifierKey.KeyName == "command-left")
                {
                    if (keyState == EKeyState.KEY_UNPRESSED)
                    {
                        Debug.Log("Return to typing state");
                        
                        var typingState = Instantiate(keyboard.typingState);
                        return typingState;
                    }
                }
            }
            return null;
        }

        public override void Exit(ARKeyboard keyboard)
        {
            foreach (var primaryKey in keyboard.ARPrimaryKeys)
            {
                KeyShortcutManager.RemoveShortcut(primaryKey);
            }
        }
    }
    
    
}
