using Scenes._1Desktop.Scripts;
using Scenes._3MobileAR.Scripts.Keyboard;
using UnityEngine;

namespace Scenes._3MobileAR.Scripts.Keys.Key_States
{
    /// <summary>
    /// Keeps track of whether key is pressed or not, mirrors desktop scene input
    /// would like to make state more integral to the overall architecture 
    /// </summary>
    
    public class KeyPressedState : MonoBehaviour
    {
        private ARKeyboard _keyboard;
        private bool _welcomeState;

        //The related enum EKeyState lives in the Desktop scene.  
        
        public void SetPressedState(EKeyState state, Key key)
        {
            switch (state)
            {
                case EKeyState.KEY_PRESSED:
                    Pressed(key);
                    break;
                case EKeyState.KEY_UNPRESSED:
                    Unpressed(key);
                    break;
            }
        }

        //TODO: Refactor - Keypress is driving a lot of parts of this app, but architecturally not happy with it.
        private void Pressed(Key key)
        {
            //Leaving open for future functionality
        }
    
        private void Unpressed(Key key)
        {
            //Leaving open for future functionality
        }
    }
}
