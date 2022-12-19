using System;
using AR_Keyboard;
using UnityEngine;

public class ShortcutActivityState : MonoBehaviour
{
    public enum EShortcutActivity
    {
        ACTIVE,
        INACTIVE,
    }
    
    public void SetShortcutActivity(EShortcutActivity state, Shortcut shortcut)
    {
        switch (state)
        {
            case EShortcutActivity.ACTIVE:
                Active(shortcut);
                break;
            case EShortcutActivity.INACTIVE:
                Inactive(shortcut);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(state), state, null);
        }
    }
    

    private void Active(Shortcut shortcut)
    {
        //TODO: Set icon to filled and unfilled respectively. removed this functionality for simplicity
        if (shortcut.onShortcutExecuted != null)
        {
            shortcut.onShortcutExecuted(shortcut);
        }
    }

    private void Inactive(Shortcut shortcut)
    {
    }
}
