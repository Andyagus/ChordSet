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

                // if (modifierKey.KeyName == "command-right")
                // {
                //     modifierKey.ChangeLocalState(ARModifierKey.EModifierKeyState.ACTIVE);
                // }
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
                primaryKey.currentShortcut.StopSequence();
                Destroy(primaryKey.currentShortcut.gameObject); 
                // Destroy(primaryKey.GetComponentInChildren<Shortcut>().gameObject);
                
                //instantiate new shortcut now
                var newShortcut = Instantiate(primaryKey.commandStateShortcut, primaryKey.transform);
                primaryKey.currentShortcut = newShortcut;

                var offset = new Vector3(0, 0.0007f, 0f);
                newShortcut.transform.position = primaryKey.transform.position + offset;
                newShortcut.SetGraphics(primaryKey);
            }
        }
        
        public override ARKeyboardState HandleInput(string keyName, EKeyState keyState, ARKeyboard keyboard)
        {
            HandleInputPrimaryKey(keyName, keyState, keyboard);
            return HandleInputModifierKey(keyName, keyState, keyboard);
            return null;
        }

        private ARKeyboardState HandleInputModifierKey(string inputKeyName, EKeyState inputKeyState, ARKeyboard keyboard)
        {

            foreach (var modifierKey in keyboard.modifierKeys)
            {
                if (modifierKey.KeyName == inputKeyName)
                {
                    if (modifierKey.modifierState == ARModifierKey.EModifierKeyState.ACTIVE)
                    {
                        if (inputKeyState == EKeyState.KEY_UNPRESSED)
                        {
                            Debug.Log("Called modifier state");
                            var state = Instantiate(typingState);
                            return state;
                        }
                    }
                }
            }
            return null;
        }

        private void HandleInputPrimaryKey(string inputKeyName, EKeyState inputKeyState, ARKeyboard keyboard)
        {
            foreach (var primaryKey in keyboard.primaryKeys)
            {
                if (primaryKey.KeyName == inputKeyName)
                {
                    if (inputKeyState == EKeyState.KEY_PRESSED)
                    {
                        primaryKey.currentShortcut.Execute(inputKeyState, primaryKey);
                    }
                }
            }
        }
        

        public override void Exit(ARKeyboard keyboard)
        {
        }
    }
}
