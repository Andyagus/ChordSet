using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyShortcutState : MonoBehaviour
{
    public enum EKeyShortcutState
    {
        SHORTCUT,
        NO_SHORTCUT
    }

    public void SetKeyShortcutState(EKeyShortcutState state, Key key)
    {
        switch (state)
        {
            case EKeyShortcutState.SHORTCUT:
                Shortcut();
                break;
            case EKeyShortcutState.NO_SHORTCUT:
                NoShortcut();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(state), state, null);
        }
    }

    private void Shortcut()
    {
        throw new NotImplementedException();
    }
    
    private void NoShortcut()
    {
        throw new NotImplementedException();
    }
}
