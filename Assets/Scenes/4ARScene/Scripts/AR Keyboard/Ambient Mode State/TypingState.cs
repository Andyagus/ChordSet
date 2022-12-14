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
            foreach (var modifier in keyboard.modifierKeys)
            {
                modifier.keyAvailability = KeyAvailabilityState.EKeyAvailability.AVAILABLE;
                modifier.keyOutline = KeyOutlineState.EKeyOutline.NO_OUTLINE;

                if (modifier.KeyName == "command-left")
                {
                    modifier.keyOutline = KeyOutlineState.EKeyOutline.OUTLINE;
                }
                else
                {
                    modifier.keyAvailability = KeyAvailabilityState.EKeyAvailability.UNAVAILABLE;
                }
            }

            foreach (var primaryKey in keyboard.primaryKeys)
            {
                primaryKey.keyShortcutState = KeyShortcutState.EKeyShortcutState.NO_SHORTCUT;
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
            }
        }
        
        public override ARKeyboardState HandleInput(Key key, ARKeyboard keyboard)
        {
            if (key.KeyName == "command-left" || key.KeyName == "command-right" )
            {
                if (key.keyPressed == EKeyState.KEY_PRESSED)
                {
                    Debug.Log("Returning new state");
                    var state = Instantiate(commandState);
                    return state;
                }
            }
            return null;
        }
    }
}
