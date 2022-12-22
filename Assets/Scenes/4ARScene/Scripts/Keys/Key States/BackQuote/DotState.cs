using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class DotState : MonoBehaviour
{

    public Image dot;
    
    public enum EDotState
    {
        NONE,
        INACTIVE,
        ACTIVE
    }

    public EDotState dotState;
    private EDotState _prevDotState;
    

    private void Update()
    {
        if (dotState != _prevDotState)
        {
            SetDotState(dotState);
            _prevDotState = dotState;
        }
    }

    private void SetDotState(EDotState state)
    {
        switch (state)
        {
            case EDotState.NONE:
                None();
                break;
            case EDotState.INACTIVE:
                Inactive();
                break;
            case EDotState.ACTIVE:
                Active();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(state), state, null);
        }
    }

    private void None()
    {
        dot.DOFade(0, 0f); 
    }
    
    private void Active()
    {
        dot.DOFade(1, 0f);
        dot.DOColor(Color.green, 0.3f);
    }
    
    private void Inactive()
    {
        dot.DOFade(1, 0f);
        dot.DOColor(Color.white, 0.3f);
    }
}

