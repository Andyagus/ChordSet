using Desktop;
using Effects;
using Enums;
using Interfaces;
using UnityEngine;

namespace AR_Keyboard.State
{
    public class State0 : ARKeyboardState
    {

        public override void Entry(ARKeyboard keyboard)
        {
            foreach (var key in keyboard.ARModifierKeys)
            {
                if (key.KeyName == "command-left" || key.KeyName == "command-right")
                {
                    KeyColorManager.ChangeKeyColor(key, Color.white);
                }
            }
        }

        public override ARKeyboardState HandleInput(InputKey input, ARKeyboard keyboard)
        {
            
            Debug.Log($"Input:{input.KeyName},  {input.keyState}");
            
            //Not sure if its good to have split up into two separate lists, doesn't really matter
            
            //sooo nested.
            foreach (var modifierKey in keyboard.ARModifierKeys)
            {
                if (input.KeyName != modifierKey.KeyName) continue;
                if (input.keyState != EKeyState.KEY_PRESSED) continue;
                if (modifierKey.KeyName != "command-left" && modifierKey.KeyName != "command-right") continue;
                var state1 = Instantiate(keyboard.states[1]);
                return state1;
            }
            
            //would love to do a direct compare input == key
            foreach (var arKey in keyboard.ARPrimaryKeys)
            {
                if (input.KeyName == arKey.KeyName)
                {
                    if (input.keyState == EKeyState.KEY_PRESSED)
                    {
                        //TODO: Not great to have color here…
                        KeyColorManager.ChangeKeyColor(arKey, Color.grey);    
                    }
                    else if(input.keyState == EKeyState.KEY_UNPRESSED)
                    {
                        //TODO where could I store original color -
                        //makes sense in key color manager wont need to manually define here.
                        var originalColor = new Color
                        {
                            r = .1132075f,
                            g = .1132075f,
                            b = .1132075f
                        };
                        KeyColorManager.ChangeKeyColor(arKey, originalColor);
                    }
                    
                }
            }
            
            return null;
        }
    }
}
