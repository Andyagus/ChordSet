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

    public Dictionary<int, InputKey> dict = new Dictionary<int, InputKey>();

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            // _ARKeyboard.OnKeyReceived("A", EKeyState.KEY_PRESSED);
        }
        
        if (Input.GetKeyUp(KeyCode.A))
        {
            // _ARKeyboard.OnKeyReceived("A", EKeyState.KEY_UNPRESSED);
        }
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            // _ARKeyboard.OnKeyReceived("S", EKeyState.KEY_PRESSED);
        }
        
        if (Input.GetKeyUp(KeyCode.S))
        {
            // _ARKeyboard.OnKeyReceived("S", EKeyState.KEY_UNPRESSED);
        }
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            // _ARKeyboard.OnKeyReceived("D", EKeyState.KEY_PRESSED);
        }
        
        if (Input.GetKeyUp(KeyCode.D))
        {
            // _ARKeyboard.OnKeyReceived("D", EKeyState.KEY_UNPRESSED);
        }

        if (Input.GetKeyDown(KeyCode.LeftCommand))
        {
            // _ARKeyboard.OnKeyReceived("command-left", EKeyState.KEY_PRESSED);
        }
        if (Input.GetKeyUp(KeyCode.LeftCommand))
        {
            // _ARKeyboard.OnKeyReceived("command-left", EKeyState.KEY_UNPRESSED);
        }
    }
}
