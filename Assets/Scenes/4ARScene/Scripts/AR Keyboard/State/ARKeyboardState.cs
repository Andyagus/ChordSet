using Desktop;
using Enums;
using UnityEngine;
using System.Collections.Generic;

namespace AR_Keyboard.State
{
    public class ARKeyboardState : MonoBehaviour
    {
        public string stateName;
        
        public ARModifierKey keyToActivate;

        
        public virtual void Entry(ARKeyboard keyboard){}
        //TODO intentionally keeping ARKeyboard ('this reference) - discuss with sunny
        public virtual ARKeyboardState HandleInput(string keyName, EKeyState keyState, ARKeyboard keyboard)
        {
            return null;
        }
        public virtual void Exit(ARKeyboard keyboard){}
    }
}
