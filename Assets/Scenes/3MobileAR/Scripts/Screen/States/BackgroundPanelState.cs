using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundPanelState : MonoBehaviour
{
    [SerializeField] private Image backgroundPanel;
    
    public enum EBackgroundPanel
    {
        INACTIVE,
        ACTIVE
    }

    public void SetBackgroundPanel(EBackgroundPanel state)
    {
        switch (state)
        {
            case EBackgroundPanel.INACTIVE:
                Inactive();
                break;
            case EBackgroundPanel.ACTIVE:
                Active();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(state), state, null);
        }
    }
    
    private void Active()
    {
        backgroundPanel.DOFade(0.4f, 1f);
    }
    
    private void Inactive()
    {
        backgroundPanel.DOFade(0, 1f);
    }
}