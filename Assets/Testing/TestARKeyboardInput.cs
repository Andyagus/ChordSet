using System;
using System.Collections;
using System.Collections.Generic;
using AR_Keyboard;
using Desktop;
using Enums;
using UnityEngine;

public class TestARKeyboardInput : MonoBehaviour
{
    private ARKeyboard _ARKeyboard;

    private void Start()
    {
        _ARKeyboard = GetComponentInParent<ARKeyboard>();
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
            _ARKeyboard.AcceptTestInput("S", EKeyState.KEY_PRESSED);
        }
        
        if (Input.GetKeyUp(KeyCode.S))
        {
            _ARKeyboard.AcceptTestInput("S", EKeyState.KEY_UNPRESSED);
        }
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            _ARKeyboard.AcceptTestInput("D", EKeyState.KEY_PRESSED);
        }
        
        if (Input.GetKeyUp(KeyCode.D))
        {
            _ARKeyboard.AcceptTestInput("D", EKeyState.KEY_UNPRESSED);
        }
        
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
