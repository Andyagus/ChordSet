using Effects;
using Enums;
using UnityEngine;

namespace AR_Keyboard.Shortcuts.Scripts
{
    public class TypingStateShortcut : Shortcut
    {

        public override void Execute(EKeyState keyState, ARKey key)
        {
            if (keyState == EKeyState.KEY_PRESSED)
            {
                KeyColorManager.ChangeKeyColor(key, Color.grey);
            }else if (keyState == EKeyState.KEY_UNPRESSED)
            {
                var originalColor = new Color 
                {
                     r = .1132075f,
                     g = .1132075f,
                     b = .1132075f 
                }; 
                KeyColorManager.ChangeKeyColor(key, originalColor);
            }
        }
    }
}