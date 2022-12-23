using System.Collections.Generic;
using AR_Keyboard;
using AR_Keyboard.State;
using DG.Tweening;
using Enums;
using UnityEngine;
using UnityEngine.UI;

public class CommandShiftState : ARKeyboardState
{
    public ARKeyboardState commandState;
    
    public override void Entry(ARKeyboard keyboard)
    {
        foreach (var primaryKey in keyboard.primaryKeys)
        {
            if (!primaryKey.isInLearningMode)
            {
                primaryKey.keyShortcutState = KeyShortcutState.EKeyShortcutState.NONE;
            }
            else
            {
                //TODO Implement Shortcut fading and unfading in learning mode
                // primaryKey.currentShortcut.GetComponentInChildren<Image>().DOFade(0.5f, 0f);
            }
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
        //TODO: add command-left shortcut, requires regular shift state
        //if(key.KeyName=="command-left" && key.keyPressed == EKeyState.UNPRESSED){}
        if (key.KeyName == "shift-left" && key.keyPressed == EKeyState.KEY_UNPRESSED)
        {
            var newState = Instantiate(this.commandState);
            return newState;
        }

        return base.HandleInput(key, keyboard);

    }
}
