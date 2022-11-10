using Desktop;
using Effects;
using UnityEngine;

namespace AR_Keyboard.State
{
    public class State0 : ARKeyboardState
    {
        public override void Entry(ARKeyboard keyboard)
        {
            foreach (var key in keyboard.arKeys)
            {
                if (key.KeyName == "command")
                {
                    KeyColorManager.ChangeKeyColor(key, Color.white);
                }
            }
        }

        public override ARKeyboardState HandleInput(InputKey input, ARKeyboard keyboard)
        {
            
            Debug.Log(input.KeyName + ": " + input.keyState);

            return null;
        }
    }
}
