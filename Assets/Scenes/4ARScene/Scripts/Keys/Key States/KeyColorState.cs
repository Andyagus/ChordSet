using System;
using System.Collections;
using System.Collections.Generic;
using AR_Keyboard;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UIElements;

public class KeyColorState : MonoBehaviour
{
    public enum EKeyColorState
    {
        BLACK,
        WHITE
    }

    public void SetKeyColorState(EKeyColorState state, Key key)
    {
        switch (state)
        {
            case EKeyColorState.BLACK:
                Black(key);
                break;
            case EKeyColorState.WHITE:
                White(key);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(state), state, null);
        }
    }


    private void White(Key key)
    {
        var color = Color.white;
        var rend = key.GetComponentInChildren<MeshRenderer>();
        rend.material.DOColor(color, 0.524f);
    }
    
    private void Black(Key key)
    {
        var color = Color.black;
        var rend = key.GetComponentInChildren<MeshRenderer>();
        rend.material.DOColor(color, 0.524f);
    }
    
}
