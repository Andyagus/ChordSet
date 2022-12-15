using System;
using System.Collections;
using System.Collections.Generic;
using AR_Keyboard;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class KeyShortcutState : MonoBehaviour
{
    [Header("Key Shortcut State Shortcuts: ")]
    private Shortcut _currentShortcut;
    public Shortcut welcomeStateShortcut;
    public Shortcut typingStateShortcut;
    public Shortcut commandStateShortcut;
    public Shortcut commandShiftStateShortcut;
    
    
    public Action OnNewShortcutActive;
    
    
    public enum EKeyShortcutState
    {
        
        NO_SHORTCUT,
        WELCOME_STATE_SHORTCUT,
        TYPING_STATE_SHORTCUT,
        COMMAND_STATE_SHORTCUT,
        COMMAND_SHIFT_STATE_SHORTCUT
        // SHORTCUT,
        // REMOVE_SHORTCUT
    }

    public void SetKeyShortcutState(EKeyShortcutState state, ARPrimaryKey primaryKey)
    {
        switch (state)
        {
            case EKeyShortcutState.NO_SHORTCUT:
                NoShortcut(primaryKey);
                break;
            case EKeyShortcutState.WELCOME_STATE_SHORTCUT:
                // WelcomeStateShortcut(primaryKey);
                break;
            case EKeyShortcutState.TYPING_STATE_SHORTCUT:
                TypingStateShortcut(primaryKey);
                break;
            case EKeyShortcutState.COMMAND_STATE_SHORTCUT:
                CommandStateShortcut(primaryKey);
                break;
            case EKeyShortcutState.COMMAND_SHIFT_STATE_SHORTCUT:
                CommandShiftStateShortcut(primaryKey);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(state), state, null);
        }
    }

 


    private void NoShortcut(ARPrimaryKey primaryKey)
    {
        // primaryKey.keyText.DOFade(1, 0.8f);
        
        if (_currentShortcut)
        {
            Destroy(_currentShortcut.gameObject);
        }
    }

    private void WelcomeStateShortcut(ARPrimaryKey primaryKey)
    {
        if (_currentShortcut)
        {
            Destroy(_currentShortcut.gameObject);
        }
        
        if (welcomeStateShortcut != null)
        {
            primaryKey.keyText.DOFade(0, 0.8f);
            _currentShortcut = Instantiate(welcomeStateShortcut, primaryKey.transform);
            var offset = new Vector3(0f, 0.0007f, 0f);
            _currentShortcut.transform.position = primaryKey.transform.position + offset;
        }    
    }
    
    private void TypingStateShortcut(ARPrimaryKey primaryKey)
    {

        if (_currentShortcut)
        {
            Destroy(_currentShortcut.gameObject);
        }
        
        if (typingStateShortcut != null)
        {
            primaryKey.keyText.DOFade(0, 0.8f);
            _currentShortcut = Instantiate(typingStateShortcut, primaryKey.transform);
            var offset = new Vector3(0f, 0.0007f, 0f);
            _currentShortcut.transform.position = primaryKey.transform.position + offset;
        }
    }

    private void CommandStateShortcut(ARPrimaryKey primaryKey)
    {

        if (_currentShortcut)
        {
            Destroy(_currentShortcut.gameObject);
        }

        if (commandStateShortcut != null)
        {
            primaryKey.keyText.DOFade(0, 0.8f);
            _currentShortcut = Instantiate(commandStateShortcut, primaryKey.transform);
            var offset = new Vector3(0f, 0.0007f, 0f);
            _currentShortcut.transform.position = primaryKey.transform.position + offset;
            primaryKey.primaryCurrentShortcut = commandShiftStateShortcut;
        }
    }

    private void CommandShiftStateShortcut(ARPrimaryKey primaryKey)
    {
        if (_currentShortcut)
        {
            Destroy(_currentShortcut.gameObject);
        }

        if (commandShiftStateShortcut != null)
        {
            primaryKey.keyText.DOFade(0, 0.8f);
            _currentShortcut = Instantiate(commandShiftStateShortcut, primaryKey.transform);
            var offset = new Vector3(0f, 0.0007f, 0f);
            _currentShortcut.transform.position = primaryKey.transform.position + offset;
        }
    }
    
    
}
