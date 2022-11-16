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

    public Dictionary<int, InputKey> dict;

    private void Start()
    {
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            _ARKeyboard.AcceptTestInput("A", EKeyState.KEY_PRESSED);
        }
        
        if (Input.GetKeyUp(KeyCode.A))
        {
            _ARKeyboard.AcceptTestInput("A", EKeyState.KEY_UNPRESSED);
        }
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            // _ARKeyboard.AcceptTestInput("S", EKeyState.KEY_PRESSED);
        }
        
        if (Input.GetKeyUp(KeyCode.S))
        {
            // _ARKeyboard.AcceptTestInput("S", EKeyState.KEY_UNPRESSED);
        }
        
        // if (Input.GetKeyDown(KeyCode.D))
        // {
        // }
        //
        // if (Input.GetKeyUp(KeyCode.D))
        // {
        // }
        //
        if (Input.GetKeyDown(KeyCode.LeftCommand))
        {
            _ARKeyboard.AcceptTestInput("command-left", EKeyState.KEY_PRESSED);

        }
        if (Input.GetKeyUp(KeyCode.LeftCommand))
        {
            _ARKeyboard.AcceptTestInput("command-left", EKeyState.KEY_UNPRESSED);
        }
    }
}
