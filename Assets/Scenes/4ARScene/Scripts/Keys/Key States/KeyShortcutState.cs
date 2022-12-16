using System;
using System.Collections;
using System.Collections.Generic;
using AR_Keyboard;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class KeyShortcutState : MonoBehaviour
{
    
    [Header("Command State Shortcuts")]
    public Shortcut cutShortcut;
    public Shortcut pasteShortcut;
    public Shortcut printShortcut;
    public Shortcut rulerShortcut;
    public Shortcut undoShortcut;
    
    [Header("Command-Shift State Shortcuts")]
    public Shortcut saveAsShortcut;
    public Shortcut screenshotShortcut;
    public Shortcut selectAllShortcut;
    
    public enum EKeyShortcutState
    {
        CUT_SHORTCUT,
        PASTE_SHORTCUT,
        PRINT_SHORTCUT,
        RULER_SHORTCUT,
        UNDO_SHORTCUT,
        SAVE_AS_SHORTCUT,
        SCREENSHOT_SHORTCUT,
        SELECT_ALL_SHORTCUT,
        NONE
    }

    public void SetKeyShortcutState(EKeyShortcutState state, ARPrimaryKey primaryKey)
    {

        switch (state)
        {
            case EKeyShortcutState.CUT_SHORTCUT:
                Cut(primaryKey);
                break;
            case EKeyShortcutState.PASTE_SHORTCUT:
                break;
            case EKeyShortcutState.PRINT_SHORTCUT:
                break;
            case EKeyShortcutState.RULER_SHORTCUT:
                break;
            case EKeyShortcutState.UNDO_SHORTCUT:
                break;
            case EKeyShortcutState.SAVE_AS_SHORTCUT:
                break;
            case EKeyShortcutState.SCREENSHOT_SHORTCUT:
                break;
            case EKeyShortcutState.SELECT_ALL_SHORTCUT:
                break;
            case EKeyShortcutState.NONE:
                None(primaryKey);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(state), state, null);
        }
    }
    

    private void Cut(ARPrimaryKey primaryKey)
    {
        if (cutShortcut != null)
        {
            var shortcut = Instantiate(cutShortcut, primaryKey.transform);
            var offset = new Vector3(0f, 0.0007f, 0f);
            shortcut.transform.position = primaryKey.transform.position + offset;
            primaryKey.currentShortcut = shortcut;
        }

    }

    private void None(ARPrimaryKey primaryKey)
    {
        Destroy(primaryKey.currentShortcut.gameObject);
    }


    // private void NoShortcut(ARPrimaryKey primaryKey)
    // {
    //     // primaryKey.keyText.DOFade(1, 0.8f);
    //     
    //     if (_currentShortcut)
    //     {
    //         Destroy(_currentShortcut.gameObject);
    //     }
    // }
    //
    // private void WelcomeStateShortcut(ARPrimaryKey primaryKey)
    // {
    //     if (_currentShortcut)
    //     {
    //         Destroy(_currentShortcut.gameObject);
    //     }
    //     
    //     if (welcomeStateShortcut != null)
    //     {
    //         // primaryKey.keyText.DOFade(0, 0.8f);
    //         _currentShortcut = Instantiate(welcomeStateShortcut, primaryKey.transform);
    //         var offset = new Vector3(0f, 0.0007f, 0f);
    //         _currentShortcut.transform.position = primaryKey.transform.position + offset;
    //     }    
    // }
    //
    // private void TypingStateShortcut(ARPrimaryKey primaryKey)
    // {
    //
    //     if (_currentShortcut)
    //     {
    //         Destroy(_currentShortcut.gameObject);
    //     }
    //     
    //     if (typingStateShortcut != null)
    //     {
    //         // primaryKey.keyText.DOFade(0, 0.8f);
    //         _currentShortcut = Instantiate(typingStateShortcut, primaryKey.transform);
    //         var offset = new Vector3(0f, 0.0007f, 0f);
    //         _currentShortcut.transform.position = primaryKey.transform.position + offset;
    //     }
    // }
    //
    // private void CommandStateShortcut(ARPrimaryKey primaryKey)
    // {
    //
    //     if (_currentShortcut)
    //     {
    //         Destroy(_currentShortcut.gameObject);
    //     }
    //
    //     if (commandStateShortcut != null)
    //     {
    //         // primaryKey.keyText.DOFade(0, 0.8f);
    //         _currentShortcut = Instantiate(commandStateShortcut, primaryKey.transform);
    //         var offset = new Vector3(0f, 0.0007f, 0f);
    //         _currentShortcut.transform.position = primaryKey.transform.position + offset;
    //         primaryKey.primaryCurrentShortcut = commandShiftStateShortcut;
    //     }
    // }
    //
    // private void CommandShiftStateShortcut(ARPrimaryKey primaryKey)
    // {
    //     if (_currentShortcut)
    //     {
    //         Destroy(_currentShortcut.gameObject);
    //     }
    //
    //     if (commandShiftStateShortcut != null)
    //     {
    //         // primaryKey.keyText.DOFade(0, 0.8f);
    //         _currentShortcut = Instantiate(commandShiftStateShortcut, primaryKey.transform);
    //         var offset = new Vector3(0f, 0.0007f, 0f);
    //         _currentShortcut.transform.position = primaryKey.transform.position + offset;
    //     }
    // }
    
    
}
