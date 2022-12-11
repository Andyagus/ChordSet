using System;
using System.Collections;
using System.Collections.Generic;
using AR_Keyboard;
using UnityEngine;

public class KeyShortcutState : MonoBehaviour
{

    public enum EKeyShortcutState
    {
        SHORTCUT,
        NO_SHORTCUT
    }

    public void SetKeyShortcutState(EKeyShortcutState state, ARPrimaryKey primaryKey)
    {
        switch (state)
        {
            case EKeyShortcutState.SHORTCUT:
                Shortcut(primaryKey);
                break;
            case EKeyShortcutState.NO_SHORTCUT:
                NoShortcut(primaryKey);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(state), state, null);
        }
    }

    private void Shortcut(ARPrimaryKey primaryKey)
    {
        Debug.Log(primaryKey.KeyName);
        var shortcut = Instantiate(primaryKey.currentShortcut, primaryKey.transform);
        var offset = new Vector3(0f, 0.0007f, 0f);
        shortcut.transform.position = primaryKey.transform.position + offset;

    }
    
    private void NoShortcut(ARPrimaryKey primaryKey)
    {
        if (primaryKey.currentShortcut)
        {
            primaryKey.currentShortcut.gameObject.SetActive(false);
            Debug.Log("NO shortcut on this primary key");
        }
    }
}
