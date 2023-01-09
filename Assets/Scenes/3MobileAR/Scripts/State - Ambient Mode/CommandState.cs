using System.Collections.Generic;
using Scenes._1Desktop.Scripts;
using Scenes._3MobileAR.Scripts.Keyboard;
using Scenes._3MobileAR.Scripts.Keys;
using Scenes._3MobileAR.Scripts.Keys.Key_States;
using Scenes._3MobileAR.Scripts.Keys.Primary_Key;
using Scenes._3MobileAR.Scripts.Keys.Shortcuts;

namespace Scenes._3MobileAR.Scripts.State___Ambient_Mode
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
                primaryKey.keyAvailability = KeyAvailabilityState.EKeyAvailability.UNAVAILABLE;
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
                //Base Class sets available shortcut state to active
                return base.HandleInput(key, keyboard);
            }
        }
        
        public override void Exit(ARKeyboard keyboard)
        {
        }
        
    }
}
