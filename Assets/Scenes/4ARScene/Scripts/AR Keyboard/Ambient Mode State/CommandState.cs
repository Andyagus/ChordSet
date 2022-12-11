using System.Collections;
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
            foreach (var primaryKey in keyboard.primaryKeys)
            {
                primaryKey.keyShortcutState = KeyShortcutState.EKeyShortcutState.COMMAND_STATE_SHORTCUT;
                // var shortcut = StartCoroutine(ReturnShortcut(primaryKey));
            }
            
            //new shortcut should be here ----- 
            
            Debug.Log("Shortcut Command State");
        }

        // private IEnumerator ReturnShortcut(ARPrimaryKey primaryKey)
        // {
        //
        //     while (primaryKey.GetComponentInChildren<Shortcut>() == null)
        //     {
        //         yield return null;
        //     }
        //
        //     yield return primaryKey.GetComponentInChildren<Shortcut>();
        //
        // }

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

        // private void InitiateShortcut(ARPrimaryKey primaryKey)
        // {
        //     if (primaryKey.GetComponentInChildren<Shortcut>() != null)
        //     {
        //         primaryKey.currentShortcut.StopSequence(primaryKey);
        //         Destroy(primaryKey.currentShortcut.gameObject);
        //     }
        //
        //     var newShortcut = Instantiate(primaryKey.commandStateShortcut, primaryKey.transform);
        //     primaryKey.currentShortcut = newShortcut;
        //
        //     var offset = new Vector3(0, 0.0007f, 0f);
        //     primaryKey.currentShortcut.transform.position = primaryKey.transform.position + offset;
        //     primaryKey.currentShortcut.SetGraphics(primaryKey);
        //     
        // }
        
        public override ARKeyboardState HandleInput(Key key)
        {
            // if(key.)
            
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

            if (key.GetComponentInChildren<ARPrimaryKey>() != null)
            {
                var primaryKey = key.GetComponentInChildren<ARPrimaryKey>();
                    if (primaryKey.GetComponentInChildren<Shortcut>() != null)
                    {
                        var currentShortcut = primaryKey.GetComponentInChildren<Shortcut>();
                        currentShortcut.Execute(primaryKey);
                    }
                // primaryKey.keyShortcutState
            }
            
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
