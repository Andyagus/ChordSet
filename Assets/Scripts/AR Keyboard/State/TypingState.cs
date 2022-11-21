using System.Collections.Generic;
using Effects;
using Enums;
using UnityEngine;

namespace AR_Keyboard.State
{
    public class TypingState : ARKeyboardState
    {
        //TODO Keep original structure and come back to this!  Get to nested looping and your on track..
        /// <summary>
        /// Keep in mind 1) Having the INTERESTED modifier keys in the state itself, because those are
        /// the only modifier keys that actually matter in this state
        /// 2) Interested parralel between the keyboard holding a list of states, and each key itself
        /// holding a list of states - except those states or holding shortcuts, keyboard is holding states.
        /// </summary>
        // public List<ARKey> interestedModifiers;


        //we are passing in a dictionary of every single key on handle input
        public ARKeyboardState nextState;

        //Todo discuss with sunny, make all keys prefabs? Get rid of nested loop - algorithmic..
        public override void Entry(ARKeyboard keyboard)
        {
            foreach (var modifierKey in keyboard.modifierKeys)
            {
                if (modifierKey.KeyName == "command-left" || modifierKey.KeyName == "command-right")
                {
                    KeyColorManager.ChangeKeyColor(modifierKey, Color.white);
                }
            }
        }

        public override ARKeyboardState HandleInput(string keyName, EKeyState keyState, ARKeyboard keyboard)
        {
            if (keyName == "command-left" || keyName == "command-right")
            {
                if (keyState == EKeyState.KEY_PRESSED)
                {
                    var commandState = Instantiate(keyboard.commandState);
                    return commandState;
                }
            }

            return null;
        }
    }
}
