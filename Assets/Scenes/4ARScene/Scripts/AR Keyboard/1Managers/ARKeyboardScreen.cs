using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ARKeyboardScreen : MonoBehaviour
{
    public enum EScreenState
    {
        INACTIVE,
        ACTIVE
    }

    public EScreenState screenState;

    public void ChangeScreenState(EScreenState state)
    {
        switch (state)
        {
            case EScreenState.ACTIVE:
                ActivateScreen();
                break;
            case EScreenState.INACTIVE:
                DeactivateScreen();
                break;
        }
    }

    private void ActivateScreen()
    {
        screenState = EScreenState.ACTIVE;
        var rawImage = GetComponentInChildren<RawImage>();
        rawImage.DOFade(1, 3f);
    }
    
    private void DeactivateScreen()
    {
        screenState = EScreenState.INACTIVE;
        var rawImage = GetComponentInChildren<RawImage>();
        rawImage.DOFade(0, 3f);

    }
}
