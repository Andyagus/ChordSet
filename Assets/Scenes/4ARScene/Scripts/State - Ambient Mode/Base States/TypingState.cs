using DG.Tweening;
using Enums;
using UnityEngine;

namespace AR_Keyboard.State
{
    public class TypingState : ARKeyboardState
    {
        public ARKeyboardState commandState;
        
        public override void Entry(ARKeyboard keyboard)
        {
            foreach (var kvp in keyboard.modifierKeyDictionary)
            {
                
                var modifierKey = kvp.Value;

                if (modifierKey.isInLearningMode)
                {
                    
                }
                else
                {
                    if (modifierKey.KeyName == "command-left")
                    {
                        modifierKey.keyOutline = KeyOutlineState.EKeyOutline.OUTLINE;
                    }
                    else
                    {
                        modifierKey.keyAvailability = KeyAvailabilityState.EKeyAvailability.UNAVAILABLE;
                    }
                }
                
            }

            foreach (var kvp in keyboard.primaryKeyDictionary)
            {
                var primaryKey = kvp.Value;
                if (primaryKey.isInLearningMode)
                {
                    
                }
                else
                {
                    primaryKey.keyAvailability = KeyAvailabilityState.EKeyAvailability.AVAILABLE;
                }
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

        public override void Exit(ARKeyboard keyboard)
        {
            // if()
            ResetKeys(keyboard);
        }
    }
}
