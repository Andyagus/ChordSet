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

        protected void ResetKeys(ARKeyboard keyboard)
        {
            foreach (var kvp in keyboard.modifierKeyDictionary)
            {
                var modifierKey = kvp.Value;
                if (modifierKey.isInLearningMode)
                {
                    return;
                }
                modifierKey.ResetStateModifierKey();
            }
            
            foreach (var kvp in keyboard.primaryKeyDictionary)
            {
                
                var primaryKey = kvp.Value;
                if (primaryKey.isInLearningMode)
                {
                    return;
                }
                primaryKey.ResetStatePrimaryKey(KeyAvailabilityState.EKeyAvailability.UNAVAILABLE);
            }
        }
    }
}
