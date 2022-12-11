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
            Debug.Log("Entered Command State");

        }

        private void PrimaryKeysEntry(ARKeyboard keyboard)
        {
            // foreach (var primaryKey in keyboard.primaryKeys)
            // {
            //     if (primaryKey.commandStateShortcut != null)
             //     {
            //         InitiateShortcut(primaryKey);
            //     }
            // }
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
        
        public override ARKeyboardState HandleInput(Key key)
        {
            if (key.KeyName == "command-left" && key.keyPressed == EKeyState.KEY_UNPRESSED)
            {
                return Instantiate(typingState);
            }
            else
            {
                return null;
            }
        }

        private ARKeyboardState HandleInputModifierKey(string inputKeyName, EKeyState inputKeyState, ARKeyboard keyboard)
        {
            
            // foreach (var modifierKey in keyboard.modifierKeys)
            // {
            //     if (modifierKey.KeyName == "command-left")
            //     {
            //         // if (modifierKey.keyPressedState == EKeyState.KEY_UNPRESSED)
            //         // {
            //         //     var state = Instantiate(typingState);
            //         //     return state;
            //         // }
            //     }
            // }
            return null;
        }

        private void HandleInputPrimaryKey(string inputKeyName, EKeyState inputKeyState, ARKeyboard keyboard)
        {
            // foreach (var primaryKey in keyboard.primaryKeys)
            // {
            //     // if (primaryKey.keyPressedState == EKeyState.KEY_PRESSED)
            //     // {
            //     //     primaryKey.currentShortcut.Execute(inputKeyState, primaryKey);
            //     // }
            // }
        }
        

        public override void Exit(ARKeyboard keyboard)
        {
        }
    }
}
