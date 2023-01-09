using Scenes._1Desktop.Scripts;
using Scenes._3MobileAR.Scripts.Keyboard;
using Scenes._3MobileAR.Scripts.Keys;
using Scenes._3MobileAR.Scripts.Keys.Key_States;
using Scenes._3MobileAR.Scripts.Keys.Tooltips;

namespace Scenes._3MobileAR.Scripts.State___Ambient_Mode
{
    /// <summary>
    /// This is the initial state of ambient mode, all primary keys
    /// are active and transitions to next state from Command key input.
    /// Could transition to multiple different states here as outlined
    /// in the state-machine.  Currently only transitioning to command
    /// for testing purposes.  Would like to explore further. 
    /// </summary>
    public class TypingState : ARKeyboardState
    {
        public ARKeyboardState commandState;
        
        /// <summary>
        /// Entry sets up the visual state of the keyboard
        /// </summary>
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
            //TODO: Consistent conditionals throughout, first check KeyPressed then check KeyName
            if (key.KeyName == "command-left" || key.KeyName == "command-right" )
            {
                if (key.keyPressed == EKeyState.KEY_PRESSED)
                {
                    //Setting and transitioning into the new state in ARKeyboard.AmbientModeHandleInput()
                    var instantiatedState = Instantiate(commandState);
                    return instantiatedState;
                }
            }
            //TODO: Design - because command-shift is a state. Should shift also be available here? (Also look at command shift state)  
            return null;
        }
    }
}
