using System.Collections;
using System.Collections.Generic;
using AR_Keyboard;
using UnityEngine;

public class GoForward : Shortcut
{
    public override void Execute(ARPrimaryKey key)
    {
        shortcutActivity = ShortutActivityState.EShortcutActivity.UI_ACTIVE;
    }
}
