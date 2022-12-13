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
                primaryKey.keyAvailability = KeyAvailabilityState.EKeyAvailability.RESTORE;
                primaryKey.keyAvailability = KeyAvailabilityState.EKeyAvailability.AVAILABLE;
                primaryKey.keyShortcutState = KeyShortcutState.EKeyShortcutState.NO_SHORTCUT;
                // if (primaryKey.GetComponentInChildren<Shortcut>() != null)
                // {
                // primaryKey.keyShortcutState = KeyShortcutState.EKeyShortcutState.REMOVE_SHORTCUT;
                // }
                if (primaryKey.KeyName == "space")
                {
                    primaryKey.keyAvailability = KeyAvailabilityState.EKeyAvailability.DISABLE_DISPLAY_TEXT_IMAGE;
                }

                if (primaryKey.KeyName == "Q" || primaryKey.KeyName == "W" || primaryKey.KeyName == "E" || primaryKey.KeyName == "R" 
                    || primaryKey.KeyName == "T" || primaryKey.KeyName == "A" || primaryKey.KeyName == "S" || primaryKey.KeyName == "D" )
                {
                    primaryKey.keyAvailability = KeyAvailabilityState.EKeyAvailability.RESTORE;
                }
            }

        }

        private IEnumerator FadeOutOtherModifierKeys(ARModifierKey arModifierKey)
        {
            throw new NotImplementedException();
        }

        private void PrimaryKeysEntry(ARKeyboard keyboard)
        {
            // foreach (var primaryKey in keyboard.primaryKeys)
            // {
            //     if (primaryKey.typingStateShortcut != null)
            //     {
            //         
            //         if (primaryKey.GetComponentInChildren<Shortcut>() != null)
            //         {
            //             primaryKey.currentShortcut.StopSequence(primaryKey);
            //             Destroy(primaryKey.currentShortcut.gameObject);
            //         }
            //         
            //         var shortcut = Instantiate(primaryKey.typingStateShortcut, primaryKey.transform);
            //         primaryKey.currentShortcut = shortcut;
            //         var offset = new Vector3(0f, 0.0007f, 0f);
            //         primaryKey.currentShortcut.transform.position = primaryKey.transform.position + offset;
            //         primaryKey.currentShortcut.SetGraphics(primaryKey);
            //     }
            // }
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
            
            //TODO BAD NEWS BEARS
            // if(key.GetComponent<ARPrimaryKey>()!=null)
            // {
            //     var primaryKey = key.GetComponent<ARPrimaryKey>();
            //     if (primaryKey.typingStateShortcut != null)
            //     {
            //         primaryKey.currentShortcut = Instantiate(primaryKey.typingStateShortcut, primaryKey.transform);
            //         primaryKey.currentShortcut.Execute(primaryKey);
            //     }
            //     
            // }
            
            return null;
            
        }
        
        
        private void MoveToNextState()
        {
            throw new System.NotImplementedException();
        }
    }
}
