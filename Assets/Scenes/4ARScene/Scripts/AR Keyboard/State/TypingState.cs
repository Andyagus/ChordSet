using System;
using System.Collections.Generic;
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
            foreach (var modifierKey in keyboard.modifierKeys)
            {
                //this is accessing the modifier keys
                if (modifierKey.KeyName == "command-left" || modifierKey.KeyName == "command-right")
                {
                    modifierKey.Available();
                }
            }
        }

        public override ARKeyboardState HandleInput(string keyName, EKeyState keyState, ARKeyboard keyboard)
        {
            //this is checking the modifier keys input
            
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
        
        private void MoveToNextState()
        {
            throw new System.NotImplementedException();
        }
    }
}
