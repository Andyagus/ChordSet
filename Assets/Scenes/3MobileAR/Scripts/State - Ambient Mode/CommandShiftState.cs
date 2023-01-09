using System.Collections.Generic;
using Scenes._1Desktop.Scripts;
using Scenes._3MobileAR.Scripts.Keyboard;
using Scenes._3MobileAR.Scripts.Keys;
using Scenes._3MobileAR.Scripts.Keys.Key_States;
using Scenes._3MobileAR.Scripts.Keys.Primary_Key;

namespace Scenes._3MobileAR.Scripts.State___Ambient_Mode
{
    /// <summary>
    /// State in Ambient Mode that is transitioned to when both command
    /// and shift are held down.
    /// </summary>
    public class CommandShiftState : ARKeyboardState
    {
        //TODO: Move to base class - next state, previous state, other 
        public ARKeyboardState typingState;
        public ARKeyboardState commandState;
    
        public override void Entry(ARKeyboard keyboard)
        {
            //Resetting Keys and setting shortcuts.  Discussed further in CommandState
            foreach (var primaryKey in keyboard.primaryKeys)
            {
                primaryKey.keyShortcutState = KeyShortcutState.EKeyShortcutState.NONE;
                SetShortcutsOnKeys(keyboard.primaryKeyDictionary);
            }
        }

        private void SetShortcutsOnKeys(Dictionary<string, ARPrimaryKey> keyboardPrimaryKeyDictionary)
        {
            keyboardPrimaryKeyDictionary["A"].keyShortcutState = KeyShortcutState.EKeyShortcutState.SELECT_ALL_SHORTCUT;
            keyboardPrimaryKeyDictionary["H"].keyShortcutState = KeyShortcutState.EKeyShortcutState.SAVE_AS_SHORTCUT;
            keyboardPrimaryKeyDictionary["4"].keyShortcutState = KeyShortcutState.EKeyShortcutState.SCREENSHOT_SHORTCUT;
        }

        public override ARKeyboardState HandleInput(Key key, ARKeyboard keyboard)
        {
            if (key.keyPressed == EKeyState.KEY_UNPRESSED)
            {
                ARKeyboardState instantiatedState = null;
                
                if (key.KeyName == "shift-left")
                {
                    instantiatedState = Instantiate(commandState);
                }

                if (key.KeyName == "command-left")
                {
                    //TODO: Design - Since shift doesn't have its own state.  When CMD is lifted transition to TypingState.
                    instantiatedState = Instantiate(typingState);
                }
                
                return instantiatedState;
            }

            //Handles activating shortcuts
            return base.HandleInput(key, keyboard);

        }
    }
}
