using System;
using System.Collections;
using System.Collections.Generic;
using AR_Keyboard;
using UnityEngine;
using UnityEngine.UI;

public class ShortutActivityState : MonoBehaviour
{

    public Image shortcutIconImage;
    public Sprite spriteInactive;
    public Sprite spriteActive;
    
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
        shortcutIconImage.sprite = spriteActive;
        shortcut.onShortcutExecuted.Notify(shortcut);
    }

    private void Inactive(Shortcut shortcut)
    {
        shortcutIconImage.sprite = spriteInactive;
    }
}
