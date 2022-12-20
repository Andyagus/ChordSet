using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PanelState : MonoBehaviour
{

    [SerializeField] private Image panelBackground;
    [SerializeField] private TextMeshProUGUI panelText;
    
    public enum EPanelState
    {
        ACTIVE,
        INACTIVE
    }

    public void SetPanelState(EPanelState state)
    {
        switch (state)
        {
            case EPanelState.ACTIVE:
                Active();
                break;
            case EPanelState.INACTIVE:
                Inactive();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(state), state, null);
        }
    }
    
    private void Active()
    {
        panelBackground.DOFade(0.354f, 1f);
        panelText.DOFade(1, 1f);
    }
    
    private void Inactive()
    {
        panelBackground.DOFade(0, 1f);
        panelText.DOFade(0, 1f);
    }
}