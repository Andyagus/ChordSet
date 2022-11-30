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
            Debug.Log("Back in Typing State");
            PrimaryKeysEntry(keyboard);
            
            foreach (var modifierKey in keyboard.modifierKeys)
            {
                //this is accessing the modifier keys
                if (modifierKey.KeyName == "command-left" || modifierKey.KeyName == "command-right")
                {
                    modifierKey.Available();
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
                        Destroy(primaryKey.GetComponentInChildren<Shortcut>().gameObject);
                        primaryKey.currentShortcut.StopSequence();
                    }
                    
                    var shortcut = Instantiate(primaryKey.typingStateShortcut, primaryKey.transform);
                    
                    primaryKey.currentShortcut = shortcut;
                    
                    var offset = new Vector3(0f, 0.0007f, 0f);
                    shortcut.transform.position = primaryKey.transform.position + offset;

                    shortcut.SetGraphics(primaryKey);
                }
            }
        }

        public override ARKeyboardState HandleInput(string keyName, EKeyState keyState, ARKeyboard keyboard)
        {
            //this is checking the modifier keys input
            
            HandleInputPrimaryKey(keyboard, keyName, keyState);
            
            if (keyName == "command-left" || keyName == "command-right")
            {
            
                if (keyState == EKeyState.KEY_PRESSED)
                {
                    var state = Instantiate(commandState);
                    return state;
                    // Debug.Log("next state");
                }
            }
        
            return null;
        }

        private void HandleInputPrimaryKey(ARKeyboard keyboard, string keyName, EKeyState keyState)
        {
            foreach (var primaryKey in keyboard.primaryKeys)
            {
                if (primaryKey.name == keyName)
                {
                    
                    primaryKey.currentShortcut.Execute(keyState, primaryKey);
                    // Debug.Log(primaryKey.name);
                }   
            }
        }

        private void MoveToNextState()
        {
            throw new System.NotImplementedException();
        }
    }
}
