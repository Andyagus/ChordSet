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
        public ARKeyboardState commandState;

        public override void Entry(ARKeyboard keyboard)
        {
            PrimaryKeysEntry(keyboard);
            
            foreach (var modifierKey in keyboard.modifierKeys)
            {
                //this is accessing the modifier keys
                if (modifierKey.KeyName == "command-left" || modifierKey.KeyName == "command-right")
                {
                    modifierKey.ChangeLocalState(ARModifierKey.EModifierKeyState.AVAILABLE);
                }
                else
                {
                    modifierKey.ChangeLocalState(ARModifierKey.EModifierKeyState.UNAVAILABLE);
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
                    primaryKey.currentShortcut = shortcut;
                    var offset = new Vector3(0f, 0.0007f, 0f);
                    primaryKey.currentShortcut.transform.position = primaryKey.transform.position + offset;
                    primaryKey.currentShortcut.SetGraphics(primaryKey);
                    
                    
                }
            }
        }
        
        // var newShortcut = Instantiate(primaryKey.commandStateShortcut, primaryKey.transform);
        // primaryKey.currentShortcut = newShortcut;
        //
        // var offset = new Vector3(0, 0.0007f, 0f);
        // newShortcut.transform.position = primaryKey.transform.position + offset;
        // newShortcut.SetGraphics(primaryKey);

        public override ARKeyboardState HandleInput(string keyName, EKeyState keyState, ARKeyboard keyboard)
        {
            HandleInputPrimaryKey(keyName, keyState, keyboard);
            return HandleInputModifierKey(keyName, keyState, keyboard);
        }

        private ARKeyboardState HandleInputModifierKey(string inputKeyName, EKeyState inputKeyState, ARKeyboard keyboard)
        {
            if (inputKeyName == "command-left" || inputKeyName == "command-right")
            {
                if (inputKeyState == EKeyState.KEY_PRESSED)
                {
                    var state = Instantiate(commandState);
                    return state;
                }
            }
            return null;
        }

        private void HandleInputPrimaryKey(string inputKeyName, EKeyState inputKeyState, ARKeyboard keyboard)
        {
            Debug.Log("Handle input primary key typing state");
        }

        private void MoveToNextState()
        {
            throw new System.NotImplementedException();
        }
    }
}
