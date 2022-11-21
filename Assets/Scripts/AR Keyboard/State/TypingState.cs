using System.Collections.Generic;
using Effects;
using Enums;
using UnityEngine;

namespace AR_Keyboard.State
{
    public class TypingState : ARKeyboardState
    {
        // public ARKeyboardState nextState;

        // public List<ARModifierKey> activeModifiers;
        public List<ARModifierKey> availableModifiers;
        // public List<ARModifierKey> unavailableModifiers;

        public ARKeyboardState nextState;
        public ARKeyboardState previousState;
        
        public override void Entry(ARKeyboard keyboard)
        {
            Debug.Log("Entry called on typing state");
        }

        public override ARKeyboardState HandleInput(string keyName, EKeyState keyState, ARKeyboard keyboard)
        {
            Debug.Log("Handle Input");
            //communciate the availablity with the modifiers…
            // foreach (var modifier in availableModifiers)
            // {
            //     if (keyName == modifier.KeyName && keyState == EKeyState.KEY_PRESSED) 
            //     {   
            //         Debug.Log("Move to next state");
            //     }
            // }
            // if (keyName == "command-left" || keyName == "command-right")
            // {
            //     if (keyState == EKeyState.KEY_PRESSED)
            //     {
            //         var commandState = Instantiate(keyboard.commandState);
            //         return commandState;
            //     }
            // }

            return null;
        }

        private void MoveToNextState()
        {
            throw new System.NotImplementedException();
        }
    }
}
