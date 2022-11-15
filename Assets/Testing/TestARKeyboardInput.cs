using System;
using System.Collections;
using System.Collections.Generic;
using AR_Keyboard;
using Desktop;
using Enums;
using UnityEngine;

public class TestARKeyboardInput : MonoBehaviour
{
    public ARKeyboard _ARKeyboard;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftCommand))
        {
            _ARKeyboard.OnKeyReceived("command-left", EKeyState.KEY_PRESSED);
        }
        if (Input.GetKeyUp(KeyCode.LeftCommand))
        {
            _ARKeyboard.OnKeyReceived("command-left", EKeyState.KEY_UNPRESSED);
        }
    }
}
