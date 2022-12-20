using AR_Keyboard;
using AR_Keyboard.State;
using DG.Tweening;
using Enums;
using UnityEngine;
using UnityEngine.UI;

public class LearningModeWelcome : ARKeyboardState
{
    public override void Entry(ARKeyboard keyboard)
    {
        Debug.Log("Entered Learning Mode");
        foreach (var primaryKey in keyboard.primaryKeys)
        {
            primaryKey.keyAvailability = KeyAvailabilityState.EKeyAvailability.UNAVAILABLE;
            primaryKey.tooltipState = TooltipState.ETooltip.NONE;
        }

        foreach (var modifierKey in keyboard.modifierKeys)
        {
            modifierKey.keyAvailability = KeyAvailabilityState.EKeyAvailability.UNAVAILABLE;
            modifierKey.keyOutline = KeyOutlineState.EKeyOutline.NO_OUTLINE;
        }

        keyboard.primaryKeyDictionary["G"].tooltipState = TooltipState.ETooltip.PLAY;
        keyboard.primaryKeyDictionary["space"].tooltipState = TooltipState.ETooltip.LEARNING_MODE_TITLE;
    }


    // private Image _positioningArea;
    // public ARKeyboardState undoShortcutState; 
    //
    // public override void Entry(ARKeyboard keyboard)
    // {
    //
    //     var positioningArea = keyboard.GetComponentInChildren<ScreenPositioningArea>();
    //     _positioningArea = positioningArea.GetComponentInChildren<Image>();
    //     
    //     _positioningArea.DOFade(1, 2f);
    //
    //
    //     foreach (var key in keyboard.primaryKeys)
    //     {
    //         // key.keyShortcutState = KeyShortcutState.EKeyShortcutState.NO_SHORTCUT;
    //
    //         if (key.KeyName == "space")
    //         {
    //             // key.displayText.DOText("Learning Mode", 2.4f);
    //             // key.keyAvailability = KeyAvailabilityState.EKeyAvailability.DISPLAY_TEXT_IMAGE;
    //         }else if (key.KeyName == "G")
    //         {
    //             // key.uiShortcutState = UIShortcutState.EuiShortcutState.LEARNING_MODE_START;
    //             // key.keyAvailability = KeyAvailabilityState.EKeyAvailability.DISPLAY_TEXT_IMAGE;
    //             // key.displayImage.DOFade(1, 2f);
    //             // key.keyText.DOFade(0, 2);
    //             // key.keyShortcutState = KeyShortcutState.EKeyShortcutState.WELCOME_STATE_SHORTCUT;
    //         }
    //         else
    //         {
    //             //Could be learning mode unavailable and have the letter scramble 
    //             key.keyAvailability = KeyAvailabilityState.EKeyAvailability.UNAVAILABLE;
    //             
    //         }
    //         
    //     }
    //     
    //     foreach (var modifierKey in keyboard.modifierKeys)
    //     {
    //         modifierKey.keyAvailability = KeyAvailabilityState.EKeyAvailability.UNAVAILABLE;
    //         modifierKey.keyOutline = KeyOutlineState.EKeyOutline.NO_OUTLINE;
    //     }
    //     
    // }
    //
    // public override ARKeyboardState HandleInput(Key key, ARKeyboard keyboard)
    // {
    //     if (key.KeyName == "G" && key.keyPressed == EKeyState.KEY_PRESSED)
    //     {
    //
    //         var primaryKey = key.GetComponentInChildren<ARPrimaryKey>();
    //         var uiShortcut = primaryKey.GetComponentInChildren<Shortcut>();
    //         // uiShortcut.shortcutActivity = ShortutActivityState.EShortcutActivity.ACTIVE;
    //         
    //         var state = Instantiate(undoShortcutState);
    //         return state;
    //     }
    //     return null;
    // }
}
