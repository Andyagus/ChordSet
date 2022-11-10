using UnityEngine;

namespace AR_Keyboard.State
{
    public class ARKeyboardState : MonoBehaviour
    {
        public virtual void Entry(ARKeyboard keyboard){}
        public virtual ARKeyboardState HandleInput(ARKeyboard keyboard)
        {
            return null;
        }
    }
}
