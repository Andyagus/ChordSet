using DG.Tweening;
using Scenes._1Desktop.Scripts;
using UnityEngine;

namespace AR_Keyboard.State
{
    public class TypingState : ARKeyboardState
    {
        public ARKeyboardState commandState;
        
        public override void Entry(ARKeyboard keyboard)
        {
        
            Debug.Log("In Ambient Mode: Typing State");
            
            foreach (var kvp in keyboard.modifierKeyDictionary)
            {
                var modifierKey = kvp.Value;
                modifierKey.ResetAllState();
                
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
