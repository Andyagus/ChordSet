using System;
using System.Collections;
using System.Collections.Generic;
using AR_Keyboard;
using UnityEngine;
using DG.Tweening;

public class UIShortcutState : MonoBehaviour
{
   
 
    private Shortcut _currentShortcut;
    public Shortcut learningModeStartShortcut;
    public Shortcut favoriteShortcut;
    public Shortcut previousShortcut;
    public Shortcut nextShortcut;
    public Shortcut loopShortcut;
    public Shortcut quitShortcut;
    
    public enum EuiShortcutState
    {
        NONE,
        LEARNING_MODE_START,
        FAVORITE,
        NEXT_SHORTCUT,
        PREVIOUS_SHORTCUT,
        LOOP,
        QUIT
    }

    public void SetUIState(EuiShortcutState state, ARPrimaryKey key)
    {
        switch (state)
        {
            case EuiShortcutState.LEARNING_MODE_START:
                LearningModeStart(key);
                break;
            case EuiShortcutState.FAVORITE:
                FavoriteIcon(key);
                break;
            case EuiShortcutState.NEXT_SHORTCUT:
                NextShortcutCall(key);
                break;
            case EuiShortcutState.PREVIOUS_SHORTCUT:
                PreviousShortcutCall(key);
                break;
            case  EuiShortcutState.LOOP:
                Loop(key);
                break;
            case EuiShortcutState.NONE:
                None(key);
                break;
            case EuiShortcutState.QUIT:
                Quit(key);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(state), state, null);
        }
    }

    private void Quit(ARPrimaryKey key)
    {
        if (quitShortcut != null)
        {
            key.keyText.DOFade(0, 0.8f);
            _currentShortcut = Instantiate(quitShortcut, key.transform);
            var offset = new Vector3(0f, 0.0007f, 0f);
            _currentShortcut.transform.position = key.transform.position + offset;
        }          
    }

    private void Loop(ARPrimaryKey key)
    {
        if (loopShortcut != null)
        {
            key.keyText.DOFade(0, 0.8f);
            _currentShortcut = Instantiate(loopShortcut, key.transform);
            var offset = new Vector3(0f, 0.0007f, 0f);
            _currentShortcut.transform.position = key.transform.position + offset;
        }      
    }

    private void PreviousShortcutCall(ARPrimaryKey key)
    {
        if (previousShortcut != null)
        {
            key.keyText.DOFade(0, 0.8f);
            _currentShortcut = Instantiate(previousShortcut, key.transform);
            var offset = new Vector3(0f, 0.0007f, 0f);
            _currentShortcut.transform.position = key.transform.position + offset;
        }        
    }

    private void NextShortcutCall(ARPrimaryKey key)
    {
        if (nextShortcut != null)
        {
            key.keyText.DOFade(0, 0.8f);
            _currentShortcut = Instantiate(nextShortcut, key.transform);
            var offset = new Vector3(0f, 0.0007f, 0f);
            _currentShortcut.transform.position = key.transform.position + offset;
        }    
    }

    private void None(ARPrimaryKey key)
    {
        key.keyText.DOFade(1, 0.8f);
        
        if (_currentShortcut)
        {
            Destroy(_currentShortcut.gameObject);
        }
    }

    private void LearningModeStart(ARPrimaryKey key)
    {
        if (favoriteShortcut != null)
        {
            key.keyText.DOFade(0, 0.8f);
            _currentShortcut = Instantiate(learningModeStartShortcut, key.transform);
            var offset = new Vector3(0f, 0.0007f, 0f);
            _currentShortcut.transform.position = key.transform.position + offset;
        }
    }

    private void FavoriteIcon(ARPrimaryKey primaryKey)
    {
        if (favoriteShortcut != null)
        {
            primaryKey.keyText.DOFade(0, 0.8f);
            _currentShortcut = Instantiate(favoriteShortcut, primaryKey.transform);
            var offset = new Vector3(0f, 0.0007f, 0f);
            _currentShortcut.transform.position = primaryKey.transform.position + offset;
        }
        
    }
}
