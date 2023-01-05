using System;
using UnityEngine;

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
        Debug.Log("Tooltip activity state - active");
    }
    
    private void Inactive(Tooltip tooltip)
    {
        Debug.Log("Tooltip activity state - inactive");
    }
}
