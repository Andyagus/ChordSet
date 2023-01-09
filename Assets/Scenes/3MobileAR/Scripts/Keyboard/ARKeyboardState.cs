using Scenes._1Desktop.Scripts;
using Scenes._3MobileAR.Scripts.Keys;
using Scenes._3MobileAR.Scripts.Keys.Primary_Key;
using Scenes._3MobileAR.Scripts.Keys.Shortcuts;
using UnityEngine;

namespace Scenes._3MobileAR.Scripts.Keyboard
{
    /// <summary>
    /// Base class for keyboard states
    /// </summary>
    
    public class ARKeyboardState : MonoBehaviour
    {
        public virtual void Entry(ARKeyboard keyboard){}
     
        /// <summary>
        /// HandleInput is called from each derived state.  If there is a shortcut on the key, sets
        /// the shortcut to active.  This calls the OnShortcutExecutedEvent and informs subscribers  
        /// </summary>
        public virtual ARKeyboardState HandleInput(Key key, ARKeyboard keyboard)
        {
            //TODO: Look into passing primary key to method instead of getting component
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
