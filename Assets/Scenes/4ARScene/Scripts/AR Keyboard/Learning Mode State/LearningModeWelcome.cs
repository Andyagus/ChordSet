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
    [SerializeField] private Shortcut goShortcut;
    private Image _positioningArea;
    
    
    public override void Entry(ARKeyboard keyboard)
    {

        var positioningArea = keyboard.GetComponentInChildren<ScreenPositioningArea>();
        _positioningArea = positioningArea.GetComponentInChildren<Image>();
        
        _positioningArea.DOFade(1, 2f);
        
        foreach (var key in keyboard.primaryKeys)
        {
            key.SetPrimaryKeyState(ARPrimaryKey.EPrimaryKeyState.LEARNING_WELCOME);
        }
        foreach (var modifierKey in keyboard.modifierKeys)
        {
            modifierKey.ChangeLocalState(ARModifierKey.EModifierKeyState.LEARNING_WELCOME);
        }
    }

    public override ARKeyboardState HandleInput(string keyName, EKeyState keyState, ARKeyboard keyboard)
    {
        foreach (var primaryKey in keyboard.primaryKeys)
        {
            if (primaryKey.KeyName == "G" && primaryKey.keyPressedState == EKeyState.KEY_PRESSED)
            {
                primaryKey.SetPrimaryKeyState(ARPrimaryKey.EPrimaryKeyState.LEARNING_ACTIVE_MENU_BUTTON);
            }
        }

        return null;
    }
}
