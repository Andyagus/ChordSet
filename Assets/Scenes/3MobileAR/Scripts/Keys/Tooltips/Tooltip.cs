using Scenes._3MobileAR.Scripts.Keys.Tooltips;
using UnityEngine;

/// <summary>
/// Base tooltip class, all GameObjects currently use this class
/// TODO: Refactor - Similar to Shortcut Class
/// </summary>
public class Tooltip : MonoBehaviour
{
    public TooltipActivityState.ETooltipActivity tooltipActivityState;
    private TooltipActivityState.ETooltipActivity _previousTooltipActivityState = TooltipActivityState.ETooltipActivity.INACTIVE;
    private TooltipActivityState _tooltipActivityState;

    private void Awake()
    {
        _tooltipActivityState = GetComponent<TooltipActivityState>();
    }

    private void Update()
    {
        if (tooltipActivityState != _previousTooltipActivityState)
        {
            _tooltipActivityState.SetTooltipActivity(tooltipActivityState, this);
            _previousTooltipActivityState = tooltipActivityState;
        }
    }
}
