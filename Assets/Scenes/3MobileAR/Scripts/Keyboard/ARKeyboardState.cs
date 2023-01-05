using Scenes._3MobileAR.Scripts.Keys;
using UnityEngine;

namespace Scenes._3MobileAR.Scripts.Keyboard
{
    /// <summary>
    /// Base class for keyboard states
    /// </summary>
    
    public class ARKeyboardState : MonoBehaviour
    {
        public virtual void Entry(ARKeyboard keyboard){}
        public virtual ARKeyboardState HandleInput(Key key, ARKeyboard keyboard)
        {
            return null;
        }
        public virtual void Exit(ARKeyboard keyboard){}
    }
}
