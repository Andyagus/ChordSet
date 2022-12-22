using System;
using System.Collections;
using System.Collections.Generic;
using AR_Keyboard;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class TooltipActivityState : MonoBehaviour
{
    public enum ETooltipActivity
    {
        ACTIVE,
        INACTIVE
    }

    public void SetShortcutActivity(ETooltipActivity state, Tooltip tooltip)
    {
        switch (state)
        {
            case ETooltipActivity.ACTIVE:
                Active(tooltip);
                break;
            case ETooltipActivity.INACTIVE:
                Inactive(tooltip);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(state), state, null);
        }
    }
    
    private void Active(Tooltip tooltip)
    {
    
    }
    
    private void Inactive(Tooltip tooltip)
    {
    
    }
}
