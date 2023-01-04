using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            _tooltipActivityState.SetShortcutActivity(tooltipActivityState, this);
            _previousTooltipActivityState = tooltipActivityState;
        }
    }
}
