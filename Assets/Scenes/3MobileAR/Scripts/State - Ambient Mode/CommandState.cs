using System.Collections.Generic;
using Scenes._1Desktop.Scripts;
using Scenes._3MobileAR.Scripts.Keyboard;
using Scenes._3MobileAR.Scripts.Keys;
using Scenes._3MobileAR.Scripts.Keys.Key_States;
using Scenes._3MobileAR.Scripts.Keys.Primary_Key;

namespace Scenes._3MobileAR.Scripts.State___Ambient_Mode
{
    /// <summary>
    /// State that is activated in Ambient Mode when command key is held down.
    /// </summary>
    public class CommandState : ARKeyboardState
    {
        //States that can be transitioned to
        public ARKeyboardState typingState;
        public ARKeyboardState commandShiftState;
        
        public override void Entry(ARKeyboard keyboard)
        {
            foreach (var modifierKey in keyboard.modifierKeys)
            {
                //The command-shift state is available from here, so highlighting it.
                if (modifierKey.KeyName == "shift-left")
                {
                    modifierKey.keyAvailability = KeyAvailabilityState.EKeyAvailability.AVAILABLE;
                    modifierKey.keyOutline = KeyOutlineState.EKeyOutline.OUTLINE;
                }
            }
            
            //setting all primary keys to unavailable prior to placing the shortcuts on specific keys.
            foreach (var primaryKey in keyboard.primaryKeys)
            {
                primaryKey.keyShortcutState = KeyShortcutState.EKeyShortcutState.NONE;
                primaryKey.keyAvailability = KeyAvailabilityState.EKeyAvailability.UNAVAILABLE;
            }
            SetShortcutsOnKeys(keyboard.primaryKeyDictionary);
        }

        /// <summary>
        /// After a couple of iterations we are setting shortcuts manually on specific keys.
        /// TODO: Keys should only know about their specific shortcuts. 
        /// </summary>
        private void SetShortcutsOnKeys(Dictionary<string, ARPrimaryKey> keyboardPrimaryKeyDictionary)
        {
            keyboardPrimaryKeyDictionary["Z"].keyShortcutState = KeyShortcutState.EKeyShortcutState.UNDO_SHORTCUT;
            keyboardPrimaryKeyDictionary["X"].keyShortcutState = KeyShortcutState.EKeyShortcutState.CUT_SHORTCUT;
            keyboardPrimaryKeyDictionary["P"].keyShortcutState = KeyShortcutState.EKeyShortcutState.PRINT_SHORTCUT;
            keyboardPrimaryKeyDictionary["R"].keyShortcutState = KeyShortcutState.EKeyShortcutState.RULER_SHORTCUT;
        }

        //TODO: If a key is active or has a shortcut, HandleInput should automatically look for its KeyPress.
        public override ARKeyboardState HandleInput(Key key, ARKeyboard keyboard)
        {
            if (key.KeyName == "command-left" && key.keyPressed == EKeyState.KEY_UNPRESSED)
            {
                return Instantiate(typingState);
            }else if (key.KeyName == "shift-left" && key.keyPressed == EKeyState.KEY_PRESSED)
            {
                var instantiatedState = Instantiate(commandShiftState);
                return instantiatedState;
            }
            else
            {
                //Base Class activates shortcuts.
                return base.HandleInput(key, keyboard);
            }
        }
        
        public override void Exit(ARKeyboard keyboard)
        {
            //TODO: Make system where keys reset on exit and entry handles shortcuts / tooltips.
        }
        
    }
}
