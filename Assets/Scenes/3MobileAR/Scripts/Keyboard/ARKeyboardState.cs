using Enums;
using UnityEngine;

namespace AR_Keyboard.State
{
    public class ARKeyboardState : MonoBehaviour
    {
        public string stateName;
        public virtual void Entry(ARKeyboard keyboard){}
        public virtual ARKeyboardState HandleInput(Key key, ARKeyboard keyboard)
        {
            if (key.GetComponentInChildren<ARPrimaryKey>() != null)
            {
                var primaryKey = key.GetComponentInChildren<ARPrimaryKey>();
                if (primaryKey.currentShortcut != null)
                {
                    if (primaryKey.keyPressed == EKeyState.KEY_PRESSED)
                    {
                        primaryKey.currentShortcut.shortcutActivity = ShortcutActivityState.EShortcutActivity.ACTIVE;
                    }
                    if (primaryKey.keyPressed == EKeyState.KEY_UNPRESSED)
                    {
                        primaryKey.currentShortcut.shortcutActivity = ShortcutActivityState.EShortcutActivity.INACTIVE;
                    }
                }
            }
            return null;
        }
        public virtual void Exit(ARKeyboard keyboard){}
    }
}
