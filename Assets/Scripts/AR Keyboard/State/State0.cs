using Desktop;
using UnityEngine;

namespace AR_Keyboard.State
{
    public class State0 : ARKeyboardState
    {
        public override void Entry(ARKeyboard keyboard)
        {
            Debug.Log("State 0 Entry Method Called");
        }

        public override ARKeyboardState HandleInput(InputKey input, ARKeyboard keyboard)
        {
            Debug.Log(input.KeyName + ": " + input.keyState);

            return null;
        }
    }
}
