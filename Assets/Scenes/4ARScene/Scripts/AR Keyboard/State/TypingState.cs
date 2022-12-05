using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Effects;
using Enums;
using UnityEngine;

namespace AR_Keyboard.State
{
    public class TypingState : ARKeyboardState
    {
        // [SerializeField] private List<ARKeyboardState> nextStates;
        
        //possible states we could transition too...
        //each state has required modifier keyyy then we check here in the state machine for it
        public ARKeyboardState commandState;
        public ARKeyboardState otherState;

        //TODO:: i want to have a list here of the keys required to be in this state.. and it would be null
        //and it would be all connected………… 
        // private List<ARModifierKey> requiredKeys;

        public override void Entry(ARKeyboard keyboard)
        {
            PrimaryKeysEntry(keyboard);
            
            foreach (var modifierKey in keyboard.modifierKeys)
            {
                //this is accessing the modifier keys
                if (modifierKey.KeyName == "command-left" || modifierKey.KeyName == "command-right")
                {
                    modifierKey.Available();
                }
                else
                {
                    modifierKey.Unavailable();
                }
            }
        }

        private void PrimaryKeysEntry(ARKeyboard keyboard)
        {
            foreach (var primaryKey in keyboard.primaryKeys)
            {
                if (primaryKey.typingStateShortcut != null)
                {
                    if (primaryKey.GetComponentInChildren<Shortcut>() != null)
                    {
                        primaryKey.currentShortcut.StopSequence();
                        Destroy(primaryKey.currentShortcut.gameObject);
                    }
                    
                    var shortcut = Instantiate(primaryKey.typingStateShortcut, primaryKey.transform);
                    var offset = new Vector3(0f, 0.0007f, 0f);
                    shortcut.transform.position = primaryKey.transform.position + offset;
                    shortcut.SetGraphics(primaryKey);
                    
                    primaryKey.currentShortcut = shortcut;
                    
                }
            }
        }

        public override ARKeyboardState HandleInput(string keyName, EKeyState keyState, ARKeyboard keyboard)
        {
            //this is checking the modifier keys input

            Debug.Log("Handle input called");
            // HandleInputPrimaryKey(keyboard, keyName, keyState);
            if (keyName == "A")
            {
                Debug.Log("A key called");
            }

        
            return null;
        }

        private void HandleInputPrimaryKey(ARKeyboard keyboard, string keyName, EKeyState keyState)
        {
            // Debug.Log("Handle input primary key");
        }

        private void MoveToNextState()
        {
            throw new System.NotImplementedException();
        }
    }
}
