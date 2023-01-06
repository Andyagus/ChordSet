using System;
using UnityEngine;

/// <summary>
/// Handle Tooltip Activity.
/// TODO: Refactor - Similar to Shortcut Class
/// </summary>
public class TooltipActivityState : MonoBehaviour
{
    public enum ETooltipActivity
    {
        ACTIVE,
        INACTIVE
    }

    public void SetTooltipActivity(ETooltipActivity state, Tooltip tooltip)
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
