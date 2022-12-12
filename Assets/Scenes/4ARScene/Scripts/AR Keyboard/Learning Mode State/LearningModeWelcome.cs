using System.Collections;
using System.Collections.Generic;
using AR_Keyboard;
using AR_Keyboard.State;
using DG.Tweening;
using Effects;
using Enums;
using UnityEngine;
using UnityEngine.UI;

public class LearningModeWelcome : ARKeyboardState
{
    private Image _positioningArea;
    public ARKeyboardState undoShortcutState; 
    
    public override void Entry(ARKeyboard keyboard)
    {

        var positioningArea = keyboard.GetComponentInChildren<ScreenPositioningArea>();
        _positioningArea = positioningArea.GetComponentInChildren<Image>();
        
        _positioningArea.DOFade(1, 2f);


        foreach (var key in keyboard.primaryKeys)
        {
            if (key.KeyName == "space")
            {
                key.displayText.DOText("Learning Mode", 2.4f);
                key.keyAvailability = KeyAvailabilityState.EKeyAvailability.DISPLAY_TEXT_IMAGE;
            }else if (key.KeyName == "G")
            {
                key.keyAvailability = KeyAvailabilityState.EKeyAvailability.DISPLAY_TEXT_IMAGE;
                key.displayImage.DOFade(1, 2f);
                key.keyText.DOFade(0, 2);
                // key.keyShortcutState = KeyShortcutState.EKeyShortcutState.WELCOME_STATE_SHORTCUT;
            }
            else
            {
                //Could be learning mode unavailable and have the letter scramble 
                key.keyAvailability = KeyAvailabilityState.EKeyAvailability.UNAVAILABLE;
            }
            
        }
        
        foreach (var modifierKey in keyboard.modifierKeys)
        {
            modifierKey.keyAvailability = KeyAvailabilityState.EKeyAvailability.UNAVAILABLE;
        }
        
    }

    public override ARKeyboardState HandleInput(Key key)
    {
        if (key.KeyName == "G" && key.keyPressed == EKeyState.KEY_PRESSED)
        {
            var state = Instantiate(undoShortcutState);
            return state;
        }
        return null;
    }
}
