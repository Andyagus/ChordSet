using System;
using System.Collections;
using System.Collections.Generic;
using AR_Keyboard;
using UnityEngine;

public class ShortcutAvailabilityState : MonoBehaviour
{
    public enum EShortcutAvailability
    {
        AVAILABLE,
        UNAVAILABLE
    }

    public void SetShortcutAvailability(EShortcutAvailability state, Shortcut shortcut)
    {
        switch (state)
        {
            case EShortcutAvailability.AVAILABLE:
                Available();
                break;
            case EShortcutAvailability.UNAVAILABLE:
                Unavailable();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(state), state, null);
        }
    }

    private void Available()
    {
        Debug.Log("Shortcut Available");
    }
    
    private void Unavailable()
    {
        Debug.Log("Shortcut Unavailable");
    }
}
