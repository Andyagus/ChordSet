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
                        primaryKey.currentShortcut.StopSequence(primaryKey);
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
        
        public override ARKeyboardState HandleInput(string keyName, EKeyState keyState, ARKeyboard keyboard)
        {
            HandleInputPrimaryKey(keyName, keyState, keyboard);
            return HandleInputModifierKey(keyName, keyState, keyboard);
        }

        private ARKeyboardState HandleInputModifierKey(string inputKeyName, EKeyState inputKeyState, ARKeyboard keyboard)
        {
            foreach (var modifierKey in keyboard.modifierKeys)
            {
                if (modifierKey.KeyName == "command-left" || modifierKey.KeyName == "command-right")
                {
                    if (modifierKey.keyPressedState == EKeyState.KEY_PRESSED)
                    {
                        var state = Instantiate(commandState);
                        return state;
                    }
                }
            }
            return null;
        }

        private void HandleInputPrimaryKey(string inputKeyName, EKeyState inputKeyState, ARKeyboard keyboard)
        {
            Debug.Log("Handle primary input");
            
            foreach (var primaryKey in keyboard.primaryKeys)
            {
                if (inputKeyName == primaryKey.KeyName)
                {
                    if (primaryKey.currentShortcut != null)
                    {
                        primaryKey.currentShortcut.Execute(inputKeyState, primaryKey);
                    }
                }
            }
        }

        private void MoveToNextState()
        {
            throw new System.NotImplementedException();
        }
    }
}
