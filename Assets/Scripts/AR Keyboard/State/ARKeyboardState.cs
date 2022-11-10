using Desktop;
using UnityEngine;

namespace AR_Keyboard.State
{
    public class ARKeyboardState : MonoBehaviour
    {
        public virtual void Entry(ARKeyboard keyboard){}
        public virtual ARKeyboardState HandleInput(InputKey input, ARKeyboard keyboard)
        {
            return null;
        }
        public virtual void Exit(ARKeyboard keyboard){}
    }
}
