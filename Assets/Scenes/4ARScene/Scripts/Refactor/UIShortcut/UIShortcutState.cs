using System;
using System.Collections;
using System.Collections.Generic;
using AR_Keyboard;
using UnityEngine;
using DG.Tweening;

public class UIShortcutState : MonoBehaviour
{

    private Shortcut _currentShortcut;
    public Shortcut favoriteShortcut;
    
    public enum EuiShortcutState
    {
        NONE,
        ENTER_LEARNING_MODE_ICON,
        FAVORITE,
        NEXT_SHORTCUT,
        PREVIOUS_SHORTCUT
    }

    public void SetUIState(EuiShortcutState state, ARPrimaryKey key)
    {
        switch (state)
        {
            case EuiShortcutState.ENTER_LEARNING_MODE_ICON:
                break;
            case EuiShortcutState.FAVORITE:
                FavoriteIcon(key);
                break;
            case EuiShortcutState.NEXT_SHORTCUT:
                break;
            case EuiShortcutState.PREVIOUS_SHORTCUT:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(state), state, null);
        }
    }

    private void FavoriteIcon(ARPrimaryKey primaryKey)
    {
        if (_currentShortcut)
        {
            Destroy(_currentShortcut.gameObject);
        }
        
        if (favoriteShortcut != null)
        {
            primaryKey.keyText.DOFade(0, 0.8f);
            _currentShortcut = Instantiate(favoriteShortcut, primaryKey.transform);
            var offset = new Vector3(0f, 0.0007f, 0f);
            _currentShortcut.transform.position = primaryKey.transform.position + offset;
        }
        
    }
}
