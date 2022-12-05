using System.Collections;
using System.Collections.Generic;
using Enums;
using UnityEngine;

public class Key : MonoBehaviour
{
    public EKeyState keyPressedState = EKeyState.KEY_UNPRESSED;
    
    public void SetPressedState(EKeyState state)
    {
        switch (state)
        {
            case EKeyState.KEY_PRESSED:
                keyPressedState = EKeyState.KEY_PRESSED;
                break;
            case EKeyState.KEY_UNPRESSED:
                keyPressedState = EKeyState.KEY_UNPRESSED;
                break;
        }
    }
}
