using Scenes._1Desktop.Scripts;
using Scenes._3MobileAR.Scripts.Keyboard;
using Scenes._3MobileAR.Scripts.Keys;
using Scenes._3MobileAR.Scripts.Keys.Key_States;
using Scenes._3MobileAR.Scripts.Keys.Tooltips;

namespace Scenes._3MobileAR.Scripts.State___Ambient_Mode
{
    /// <summary>
    /// This is the initial state of ambient mode, where all primary keys
    /// are active and transitions to next state based on input based in.
    /// </summary>
    public class TypingState : ARKeyboardState
    {
        public ARKeyboardState commandState;
        
        public override void Entry(ARKeyboard keyboard)
        {
            foreach (var kvp in keyboard.modifierKeyDictionary)
            {
                var modifierKey = kvp.Value;
                modifierKey.ResetAllState();
                
                //TODO: Make command right also active.
                
                //Highlighting the Command-Left key (via outline) because it is the key required
                //to transition to the next state.

                if (modifierKey.KeyName == "command-left")
                {
                    modifierKey.keyOutline = KeyOutlineState.EKeyOutline.OUTLINE;
                }
                else
                {
                    modifierKey.keyAvailability = KeyAvailabilityState.EKeyAvailability.UNAVAILABLE;
                }
            }

            foreach (var kvp in keyboard.primaryKeyDictionary)
            {
                var primaryKey = kvp.Value;
                primaryKey.ResetAllState();
            }

            //TODO: This is not related to typing state, as it persists across states. Should be with shortcut list
            var backQuote = keyboard.primaryKeyDictionary["back-quote"];
            backQuote.tooltipState = TooltipState.ETooltip.GO_TO_LEARNING_MODE;
        }
        
        public override ARKeyboardState HandleInput(Key key, ARKeyboard keyboard)
        {
            if (key.KeyName == "command-left" || key.KeyName == "command-right" )
            {
                if (key.keyPressed == EKeyState.KEY_PRESSED)
                {
                    var state = Instantiate(commandState);
                    return state;
                }
            }
            return null;
        }
    }
}
