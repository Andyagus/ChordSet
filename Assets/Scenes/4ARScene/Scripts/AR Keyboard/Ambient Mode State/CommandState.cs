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
            ModifierKeyEntry(keyboard);
            PrimaryKeysEntry(keyboard);
           
        }

        private void ModifierKeyEntry(ARKeyboard keyboard)
        {
            foreach (var modifierKey in keyboard.modifierKeys)
            {
                if(modifierKey.KeyName == "command-left")
                {
                    modifierKey.ChangeLocalState(ARModifierKey.EModifierKeyState.ACTIVE);
                }
            }
        }

        private void PrimaryKeysEntry(ARKeyboard keyboard)
        {
            foreach (var primaryKey in keyboard.primaryKeys)
            {
                if (primaryKey.commandStateShortcut != null)
                {
                    InitiateShortcut(primaryKey);
                }
            }
        }

        private void InitiateShortcut(ARPrimaryKey primaryKey)
        {
            if (primaryKey.GetComponentInChildren<Shortcut>() != null)
            {
                primaryKey.currentShortcut.StopSequence(primaryKey);
                Destroy(primaryKey.currentShortcut.gameObject);
            }

            var newShortcut = Instantiate(primaryKey.commandStateShortcut, primaryKey.transform);
            primaryKey.currentShortcut = newShortcut;

            var offset = new Vector3(0, 0.0007f, 0f);
            primaryKey.currentShortcut.transform.position = primaryKey.transform.position + offset;
            primaryKey.currentShortcut.SetGraphics(primaryKey);
            
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
                if (modifierKey.KeyName == "command-left")
                {
                    if (modifierKey.keyPressedState == EKeyState.KEY_UNPRESSED)
                    {
                        var state = Instantiate(typingState);
                        return state;
                    }
                }
            }
            return null;
        }

        private void HandleInputPrimaryKey(string inputKeyName, EKeyState inputKeyState, ARKeyboard keyboard)
        {
            foreach (var primaryKey in keyboard.primaryKeys)
            {
                if (primaryKey.keyPressedState == EKeyState.KEY_PRESSED)
                {
                    primaryKey.currentShortcut.Execute(inputKeyState, primaryKey);
                }
            }
        }
        

        public override void Exit(ARKeyboard keyboard)
        {
        }
    }
}
