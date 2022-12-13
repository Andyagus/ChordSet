using System;
using System.Collections.Generic;
using AR_Keyboard;
using DG.Tweening;
using Enums;
using Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UndoShortcut : Shortcut
{

    public override void Execute(ARPrimaryKey key)
    {
        shortcutActivity = ShortutActivityState.EShortcutActivity.ACTIVE;
        
        if (key.keyPressed == EKeyState.KEY_UNPRESSED)
        {
            shortcutActivity = ShortutActivityState.EShortcutActivity.INACTIVE;
        }
        
    }
}

