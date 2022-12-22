using System.Collections.Generic;
using Enums;

namespace AR_Keyboard.State
{
    public class CommandState : ARKeyboardState
    {
        public ARKeyboardState typingState;
        public ARKeyboardState commandShiftState;
        
        public override void Entry(ARKeyboard keyboard)
        {

            foreach (var modifierKey in keyboard.modifierKeys)
            {
                if (modifierKey.KeyName == "shift-left")
                {
                    modifierKey.keyAvailability = KeyAvailabilityState.EKeyAvailability.AVAILABLE;
                    modifierKey.keyOutline = KeyOutlineState.EKeyOutline.OUTLINE;
                }
            }
            
            foreach (var primaryKey in keyboard.primaryKeys)
            {
                primaryKey.keyShortcutState = KeyShortcutState.EKeyShortcutState.NONE;
                
                //TODO Move to base state
                if (!primaryKey.isInLearningMode)
                {
                    primaryKey.keyAvailability = KeyAvailabilityState.EKeyAvailability.UNAVAILABLE;
                }
            }
            
            SetShortcutsOnKeys(keyboard.primaryKeyDictionary);
        }

        private void SetShortcutsOnKeys(Dictionary<string, ARPrimaryKey> keyboardPrimaryKeyDictionary)
        {
            keyboardPrimaryKeyDictionary["Z"].keyShortcutState = KeyShortcutState.EKeyShortcutState.UNDO_SHORTCUT;
            keyboardPrimaryKeyDictionary["X"].keyShortcutState = KeyShortcutState.EKeyShortcutState.CUT_SHORTCUT;
            keyboardPrimaryKeyDictionary["P"].keyShortcutState = KeyShortcutState.EKeyShortcutState.PRINT_SHORTCUT;
            keyboardPrimaryKeyDictionary["R"].keyShortcutState = KeyShortcutState.EKeyShortcutState.RULER_SHORTCUT;
        }

        public override ARKeyboardState HandleInput(Key key, ARKeyboard keyboard)
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
            
            if (key.KeyName == "command-left" && key.keyPressed == EKeyState.KEY_UNPRESSED)
            {
                return Instantiate(typingState);
            }else if (key.KeyName == "shift-left" && key.keyPressed == EKeyState.KEY_PRESSED)
            {
                var newState = Instantiate(commandShiftState);
                return newState;
            }
            else
            {
                return base.HandleInput(key, keyboard);
            }
        }
        
        public override void Exit(ARKeyboard keyboard)
        {
        }
        
    }
}
