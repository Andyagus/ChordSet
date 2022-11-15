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
        var inputKey1 = new GameObject().AddComponent<InputKey>();
        inputKey1.KeyName = "A";
        inputKey1.keyState = EKeyState.KEY_UNPRESSED;
        
        var inputKey2 = new GameObject().AddComponent<InputKey>();
        inputKey2.KeyName = "S";
        inputKey2.keyState = EKeyState.KEY_UNPRESSED;
        
        
        dict = new Dictionary<int, InputKey>()
        {
            { 1, inputKey1},
            { 2, inputKey2}

        };
    }

    private void Update()
    {
        
        //
     
        // var inputKey3 = new GameObject().AddComponent<InputKey>();
        // inputKey3.KeyName = "D";
        // inputKey3.keyState = EKeyState.KEY_PRESSED;
        //
        // var inputKey4 = new GameObject().AddComponent<InputKey>();
        // inputKey4.KeyName = "A";
        // inputKey4.keyState = EKeyState.KEY_UNPRESSED;
        //
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            dict[1].keyState = EKeyState.KEY_PRESSED;
            // _ARKeyboard.OnKeyDictionaryReceived(dict);

            // var inputKey1 = new GameObject().AddComponent<InputKey>();
            // inputKey1.KeyName = "A";
            // inputKey1.keyState = EKeyState.KEY_PRESSED;
            // dict.Add(1, inputKey1);
            // // _ARKeyboard.OnKeyReceived("A", EKeyState.KEY_PRESSED);
        }
        
        if (Input.GetKeyUp(KeyCode.A))
        {
            if (dict[1])
            {
                dict[1].keyState = EKeyState.KEY_UNPRESSED;
                // _ARKeyboard.OnKeyDictionaryReceived(dict);
            }
            // var inputKey1 = new GameObject().AddComponent<InputKey>();
            // inputKey1.KeyName = "A";
            // inputKey1.keyState = EKeyState.KEY_UNPRESSED;
            // dict.Add(2, inputKey1);
            // _ARKeyboard.OnKeyReceived("A", EKeyState.KEY_UNPRESSED);
        }
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (dict[2])
            {
                dict[2].keyState = EKeyState.KEY_PRESSED;
                // _ARKeyboard.OnKeyDictionaryReceived(dict);
            }
            // _ARKeyboard.OnKeyReceived("S", EKeyState.KEY_PRESSED);
        }
        
        if (Input.GetKeyUp(KeyCode.S))
        {
            if (dict[2])
            {
                dict[2].keyState = EKeyState.KEY_UNPRESSED;
                // _ARKeyboard.OnKeyDictionaryReceived(dict);
            }
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
