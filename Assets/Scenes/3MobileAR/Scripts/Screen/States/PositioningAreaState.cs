using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PositioningAreaState : MonoBehaviour
{
    [SerializeField] private Image positioningArea;
    
    public enum EPositioningArea
    {
        ACTIVE,
        INACTIVE
    }

    public void SetPositioningArea(EPositioningArea state)
    {
        switch (state)
        {
            case EPositioningArea.ACTIVE:
                Active();
                break;
            case EPositioningArea.INACTIVE:
                Inactive();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(state), state, null);
        }
    }
    
    private void Active()
    {
        positioningArea.DOFade(1, 1f);
    }
    
    private void Inactive()
    {
        positioningArea.DOFade(0, 1f);
    }
}
