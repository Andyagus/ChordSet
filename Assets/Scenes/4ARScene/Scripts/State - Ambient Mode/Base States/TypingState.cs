using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using DG.Tweening;
using Effects;
using Enums;
using UnityEngine;

namespace AR_Keyboard.State
{
    public class TypingState : ARKeyboardState
    {
        public ARKeyboardState commandState;
        
        public override void Entry(ARKeyboard keyboard)
        {
            foreach (var kvp in keyboard.modifierKeyDictionary)
            {
                var modifierKey = kvp.Value;
                modifierKey.keyAvailability = KeyAvailabilityState.EKeyAvailability.AVAILABLE;
                modifierKey.keyOutline = KeyOutlineState.EKeyOutline.NO_OUTLINE;

                if (modifierKey.KeyName == "command-left")
                {
                    modifierKey.keyOutline = KeyOutlineState.EKeyOutline.OUTLINE;
                }
                else
                {
                    modifierKey.keyAvailability = KeyAvailabilityState.EKeyAvailability.UNAVAILABLE;
                }
            }

            foreach (var kvp in keyboard.primaryKeyDictionary)
            {
                var primaryKey = kvp.Value;
                // primaryKey.keyShortcutState = KeyShortcutState.EKeyShortcutState.NO_SHORTCUT;
                primaryKey.keyAvailability = KeyAvailabilityState.EKeyAvailability.AVAILABLE;
                primaryKey.keyOutline = KeyOutlineState.EKeyOutline.NO_OUTLINE;

                if (primaryKey.KeyName == "space")
                {
                    primaryKey.keyAvailability = KeyAvailabilityState.EKeyAvailability.DISABLE_DISPLAY_TEXT_IMAGE;
                }

                if (primaryKey.KeyName == "Q" || primaryKey.KeyName == "W" || primaryKey.KeyName == "E" || primaryKey.KeyName == "R" 
                    || primaryKey.KeyName == "T" || primaryKey.KeyName == "A" || primaryKey.KeyName == "S" || primaryKey.KeyName == "D" )
                {
                    primaryKey.ResetCharacter();
  
                    primaryKey.keyAvailability = KeyAvailabilityState.EKeyAvailability.AVAILABLE;
                }
            
                var shortcutState = primaryKey.GetComponentInChildren<KeyShortcutState>();
                // if (shortcutState.typingStateShortcut != null)
                // {
                //     primaryKey.keyShortcutState = KeyShortcutState.EKeyShortcutState.TYPING_STATE_SHORTCUT;
                // }
            
            }
        }
        
        public override ARKeyboardState HandleInput(Key key, ARKeyboard keyboard)
        {
            
            if (key.KeyName == "command-left" || key.KeyName == "command-right" )
            {

                if (key.keyPressed == EKeyState.KEY_PRESSED)
                {
                    var state = Instantiate(commandState);
                    return state;
                }
            }
            return null;
        }
    }
}
