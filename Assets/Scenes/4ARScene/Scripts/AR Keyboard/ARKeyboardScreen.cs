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

    private EScreenState _screenState;

    public void ChangeScreenState(EScreenState state)
    {
        switch (state)
        {
            case EScreenState.ACTIVE:
                ActivateScreen();
                break;
        }
    }

    private void ActivateScreen()
    {
        _screenState = EScreenState.ACTIVE;
        var rawImage = GetComponentInChildren<RawImage>();
        rawImage.DOFade(1, 3f);
    }
}
