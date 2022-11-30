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
            HandlePrimaryKeys(keyboard);

            foreach (var modifierKey in keyboard.modifierKeys)
            {
                if (modifierKey.KeyName == "command-left" || modifierKey.KeyName == "command-right")
                {
                    modifierKey.Active();
                }
            }
        }

        public override ARKeyboardState HandleInput(string keyName, EKeyState keyState, ARKeyboard keyboard)
        {
            
            if (keyName == "command-left" || keyName == "command-right")
            {
                if (keyState == EKeyState.KEY_UNPRESSED)
                {
                    var newState = Instantiate(this.typingState);
                    return newState;
                }
            }
            return null;
        }

        
        private void HandlePrimaryKeys(ARKeyboard keyboard)
        {
            foreach (var primaryKey in keyboard.primaryKeys)
            {
                // primaryKey.StopSequence();
                
                if (primaryKey.commandStateShortcut != null)
                {
                    
                    if (primaryKey.GetComponentInChildren<Shortcut>() != null)
                    {
                        Destroy(primaryKey.GetComponentInChildren<Shortcut>().gameObject);
                        primaryKey.currentShortcut.StopSequence();
                    }
                    
                    var shortcut = Instantiate(primaryKey.commandStateShortcut, primaryKey.transform);

                    primaryKey.currentShortcut = shortcut;
                    
                    var offset = new Vector3(0f, 0.0007f, 0f);
                    shortcut.transform.position = primaryKey.transform.position + offset;
                    shortcut.SetGraphics(primaryKey);

                }
            }
            
        }
        
        public override void Exit(ARKeyboard keyboard)
        {
        }
    }
    
    
}
