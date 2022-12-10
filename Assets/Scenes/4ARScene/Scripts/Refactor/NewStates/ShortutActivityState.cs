using System;
using System.Collections;
using System.Collections.Generic;
using AR_Keyboard;
using UnityEngine;

public class ShortutActivityState : MonoBehaviour
{
    public enum EShortcutActivity
    {
        ACTIVE,
        INACTIVE
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
        Debug.Log("Shortcut Active");
    }

    private void Inactive(Shortcut shortcut)
    {
        Debug.Log("Shortcut Active");
    }
}
