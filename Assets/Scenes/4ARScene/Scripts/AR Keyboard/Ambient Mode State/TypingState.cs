using System;
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
                if (modifier.KeyName == "command-left")
                {
                    modifier.keyOutline = KeyOutlineState.EKeyOutline.OUTLINE;
                }
                else
                {
                    modifier.keyAvailability = KeyAvailabilityState.EKeyAvailability.UNAVAILABLE;
                }
            }

           Debug.Log("Entered Typing State");
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
        
        public override ARKeyboardState HandleInput(Key key)
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
