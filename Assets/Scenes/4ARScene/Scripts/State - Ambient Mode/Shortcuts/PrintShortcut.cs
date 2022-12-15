using System.Collections;
using System.Collections.Generic;
using AR_Keyboard;
using Enums;
using UnityEngine;

public class PrintShortcut : Shortcut
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
