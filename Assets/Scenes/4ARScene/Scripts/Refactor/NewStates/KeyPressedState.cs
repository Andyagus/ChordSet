using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Enums;
using UnityEngine;

public class KeyPressedState : MonoBehaviour
{
    public void SetPressedState(EKeyState state, Key key)
    {
        switch (state)
        {
            case EKeyState.KEY_PRESSED:
                Pressed(key);
                break;
            case EKeyState.KEY_UNPRESSED:
                Unpressed(key);
                break;
        }
    }

    private void Pressed(Key key)
    {
        var rend = key.GetComponentInChildren<MeshRenderer>();
        rend.material.DOColor(Color.white, 0.524f);
    }
    
    private void Unpressed(Key key)
    {
        var rend = key.GetComponentInChildren<MeshRenderer>();
        rend.material.DOColor(Color.black, 0.524f);
    }
}
