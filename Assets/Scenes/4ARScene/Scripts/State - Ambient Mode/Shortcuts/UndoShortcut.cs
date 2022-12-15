using AR_Keyboard;
using Enums;


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

