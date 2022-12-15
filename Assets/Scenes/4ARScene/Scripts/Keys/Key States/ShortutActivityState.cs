using System;
using System.Collections;
using System.Collections.Generic;
using AR_Keyboard;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ShortutActivityState : MonoBehaviour
{

    public Image shortcutIconImage;
    public Sprite spriteInactive;
    public Sprite spriteActive;
    private Transform _localCanvas;
    private ShortcutSuccessPanel _shortcutSuccessPanel;

    public enum EShortcutActivity
    {
        ACTIVE,
        INACTIVE,
        UI_ACTIVE,
        UI_INACTIVE
    }

    private void Awake()
    {
        var keyboard = GameObject.Find("AR_Keyboard").GetComponent<ARKeyboard>();
        _localCanvas = keyboard.ARScreen.gameObject.transform.Find("Canvas");
        _shortcutSuccessPanel = _localCanvas.GetComponentInChildren<ShortcutSuccessPanel>();

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

        var sequence = DOTween.Sequence();
        sequence.AppendCallback(() =>
        {
            _shortcutSuccessPanel.SetShortcutSuccessPopUpState(ShortcutSuccessPanel.EShortcutSuccessPopUp.AVAILABLE,
                spriteInactive, shortcut.shortcutName);
        });
        sequence.AppendInterval(0.8f);
        sequence.AppendCallback(() =>
        {
            _shortcutSuccessPanel.SetShortcutSuccessPopUpState(ShortcutSuccessPanel.EShortcutSuccessPopUp.UNAVAILABLE,
                spriteInactive, shortcut.shortcutName);
        });
        // var spriteToUse = spriteInactive ? spriteInactive : shortcutIconImage.sprite;

    }

    private void Inactive(Shortcut shortcut)
    {
        if (spriteInactive != null)
        {
            shortcutIconImage.sprite = spriteInactive;
        }
    }
}
