using System.Collections;
using System.Collections.Generic;
using AR_Keyboard;
using DG.Tweening;
using Effects;
using Enums;
using UnityEngine;

public class KeyPressedState : MonoBehaviour
{
    private ARKeyboard _keyboard;
    private bool _welcomeState;
    
    
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
        var color = Color.white;
        if (_welcomeState)
        {
            color = KeyColorManager.PickRandomColor();
        }
        var rend = key.GetComponentInChildren<MeshRenderer>();
        rend.material.DOColor(color, 0.524f);
    }
    
    private void Unpressed(Key key)
    {
        var rend = key.GetComponentInChildren<MeshRenderer>();
        rend.material.DOColor(Color.black, 0.524f);
    }
}
