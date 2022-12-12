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
        INACTIVE,
        UI_ACTIVE,
        UI_INACTIVE
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
            case EShortcutActivity.UI_ACTIVE:
                UIActive(shortcut);
                break;
            case EShortcutActivity.UI_INACTIVE:
                UIInactive(shortcut);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(state), state, null);
        }
    }

    
    private void UIActive(Shortcut shortcut)
    {
        Debug.Log(shortcut.shortcutName + " is active");
        throw new NotImplementedException();
    }
    
    private void UIInactive(Shortcut shortcut)
    {
        throw new NotImplementedException();
    }

    private void Active(Shortcut shortcut)
    {
        if (spriteActive != null)
        {
            shortcutIconImage.sprite = spriteActive;
        }
        shortcut.onShortcutExecuted.Notify(shortcut);
    }

    private void Inactive(Shortcut shortcut)
    {
        if (spriteInactive != null)
        {
            shortcutIconImage.sprite = spriteInactive;
        }
    }
}
