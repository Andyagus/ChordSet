using AR_Keyboard;
using AR_Keyboard.State;
using DG.Tweening;
using Enums;
using UnityEngine;
using UnityEngine.UI;

public class LearningModeWelcome : LearningModeState
{
    
    //TODO: make learning mode state hierarchy ARKeyboardState -> LearningModeState -> Specific Modes
    
    public override void Entry(ARKeyboard keyboard)
    {
        foreach (var primaryKey in keyboard.primaryKeys)
        {
            //TODO: Key availability unavailable in reset all state.
            primaryKey.ResetAllState();
            primaryKey.keyAvailability = KeyAvailabilityState.EKeyAvailability.UNAVAILABLE;
        }

        foreach (var modifierKey in keyboard.modifierKeys)
        {
            modifierKey.ResetAllState();
            modifierKey.keyAvailability = KeyAvailabilityState.EKeyAvailability.UNAVAILABLE;
        }

        keyboard.primaryKeyDictionary["G"].tooltipState = TooltipState.ETooltip.PLAY;
        keyboard.primaryKeyDictionary["space"].tooltipState = TooltipState.ETooltip.LEARNING_MODE_TITLE;

        keyboard.ARScreen.backgroundPanelState = BackgroundPanelState.EBackgroundPanel.ACTIVE;
        keyboard.ARScreen.positioningAreaState = PositioningAreaState.EPositioningArea.ACTIVE;
    }


    public override ARKeyboardState HandleInput(Key key, ARKeyboard keyboard)
    {
        if (key.KeyName == "G" && key.keyPressed == EKeyState.KEY_PRESSED)
        {
            var state = Instantiate(nextState);
            return state;
        }
        return null;
    }
    
    
}
