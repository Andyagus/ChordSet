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
            foreach (var modifierKey in keyboard.modifierKeys)
            {
                if (modifierKey.KeyName == "command-left" || modifierKey.KeyName == "command-right")
                {
                    modifierKey.Active();
                }
            }
        }

        public override ARKeyboardState HandleInput(string keyName, EKeyState keyState, ARKeyboard keyboard)
        {

            if (keyName == "command-left" || keyName == "command-right")
            {
                if (keyState == EKeyState.KEY_UNPRESSED)
                {
                    var newState = Instantiate(typingState);
                    return typingState;
                }
            }
            return null;
        }

        public override void Exit(ARKeyboard keyboard)
        {
        }
    }
    
    
}
