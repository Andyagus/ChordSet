using Effects;
using Enums;
using UnityEngine;

namespace AR_Keyboard.State
{
    public class CommandState : ARKeyboardState
    {
        public override void Entry(ARKeyboard keyboard)
        {
            //modifier keys are directly linked to the keyboard
            foreach (var modifierKey in keyboard.modifierKeys)
            {
                if (modifierKey.KeyName == "command-left" || modifierKey.KeyName == "command-right")
                {
                    KeyColorManager.ChangeKeyColor(modifierKey, Color.yellow);
                }
            }

            foreach (var primaryKey in keyboard.primaryKeys)
            {
                KeyShortcutManager.PlaceKeyShortcut(primaryKey, this);
            }
        }

        public override ARKeyboardState HandleInput(string keyName, EKeyState keyState, ARKeyboard keyboard)
        {
          
            //modifiers we have a specific we are looking for 
                if (keyName == "command-left")
                {
                    if (keyState == EKeyState.KEY_UNPRESSED)
                    {
                        Debug.Log("Return to typing state");
                        
                        var typingState = Instantiate(keyboard.typingState);
                        return typingState;
                    }
                }

            //primary, we are interested in all keys
                // foreach (var primaryKey in keyboard.primaryKeys)
                // {
                //     if (keyName == primaryKey.KeyName)
                //     {
                //         if (keyState == EKeyState.KEY_PRESSED)
                //         {
                //             primaryKey.GetComponentInChildren<Shortcut>().Execute(keyState, primaryKey);
                //         }
                //     }
                // }
                
                return null;
        }

        public override void Exit(ARKeyboard keyboard)
        {
            foreach (var primaryKey in keyboard.primaryKeys)
            {
                KeyShortcutManager.RemoveShortcut(primaryKey);
            }
        }
    }
    
    
}
