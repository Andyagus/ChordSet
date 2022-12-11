using System;
using System.Collections;
using System.Collections.Generic;
using AR_Keyboard;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class KeyShortcutState : MonoBehaviour
{
    private Shortcut _shortcut;
    
    public enum EKeyShortcutState
    {
        SHORTCUT,
        REMOVE_SHORTCUT
    }

    public void SetKeyShortcutState(EKeyShortcutState state, ARPrimaryKey primaryKey)
    {
        switch (state)
        {
            case EKeyShortcutState.SHORTCUT:
                Shortcut(primaryKey);
                break;
            case EKeyShortcutState.REMOVE_SHORTCUT:
                RemoveShortcut(primaryKey);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(state), state, null);
        }
    }

    private void Shortcut(ARPrimaryKey primaryKey)
    {
       
        
        foreach (var texts in primaryKey.GetComponentsInChildren<TextMeshProUGUI>())
        {
            texts.DOFade(0, 0.5f);
        }
        _shortcut = Instantiate(primaryKey.currentShortcut, primaryKey.transform);
        var offset = new Vector3(0f, 0.0007f, 0f);
        _shortcut.transform.position = primaryKey.transform.position + offset;

    }
    
    private void RemoveShortcut(ARPrimaryKey primaryKey)
    {
        if (primaryKey.GetComponentInChildren<Shortcut>())
        {
            foreach (var texts in primaryKey.GetComponentsInChildren<TextMeshProUGUI>())
            {
                texts.DOFade(1, 0.5f);
            }
            
            Destroy(_shortcut.gameObject);
        }
    }
}
