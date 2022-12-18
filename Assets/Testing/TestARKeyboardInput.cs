using AR_Keyboard;
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
        // if (Input.GetKeyDown(KeyCode.A))
        // {
        //     _ARKeyboard.AcceptTestInput("A", EKeyState.KEY_PRESSED);
        // }
        //
        // if (Input.GetKeyUp(KeyCode.A))
        // {
        //     _ARKeyboard.AcceptTestInput("A", EKeyState.KEY_UNPRESSED);
        // }
        //
        // if (Input.GetKeyDown(KeyCode.S))
        // {
        //     _ARKeyboard.AcceptTestInput("S", EKeyState.KEY_PRESSED);
        // }
        //
        // if (Input.GetKeyUp(KeyCode.S))
        // {
        //     _ARKeyboard.AcceptTestInput("S", EKeyState.KEY_UNPRESSED);
        // }
        //
        // if (Input.GetKeyDown(KeyCode.D))
        // {
        //     _ARKeyboard.AcceptTestInput("D", EKeyState.KEY_PRESSED);
        // }
        //
        // if (Input.GetKeyUp(KeyCode.D))
        // {
        //     _ARKeyboard.AcceptTestInput("D", EKeyState.KEY_UNPRESSED);
        // }
        //
        // if (Input.GetKeyDown(KeyCode.Z))
        // {
        //     _ARKeyboard.AcceptTestInput("Z", EKeyState.KEY_PRESSED);
        // }
        //
        // if (Input.GetKeyUp(KeyCode.Z))
        // {
        //     _ARKeyboard.AcceptTestInput("Z", EKeyState.KEY_UNPRESSED);
        // }
        //
        // if (Input.GetKeyDown(KeyCode.X))
        // {
        //     _ARKeyboard.AcceptTestInput("X", EKeyState.KEY_PRESSED);
        // }
        //
        // if (Input.GetKeyUp(KeyCode.X))
        // {
        //     _ARKeyboard.AcceptTestInput("X", EKeyState.KEY_UNPRESSED);
        // }
        //
        // if (Input.GetKeyDown(KeyCode.C))
        // {
        //     _ARKeyboard.AcceptTestInput("C", EKeyState.KEY_PRESSED);
        // }
        //
        // if (Input.GetKeyUp(KeyCode.C))
        // {
        //     _ARKeyboard.AcceptTestInput("C", EKeyState.KEY_UNPRESSED);
        // }
        //
        //
        // if (Input.GetKeyDown(KeyCode.V))
        // {
        //     _ARKeyboard.AcceptTestInput("V", EKeyState.KEY_PRESSED);
        // }
        //
        // if (Input.GetKeyUp(KeyCode.V))
        // {
        //     _ARKeyboard.AcceptTestInput("V", EKeyState.KEY_UNPRESSED);
        // }
        //
        // if (Input.GetKeyDown(KeyCode.LeftCommand))
        // {
        //     _ARKeyboard.AcceptTestInput("command-left", EKeyState.KEY_PRESSED);
        //
        // }
        // if (Input.GetKeyUp(KeyCode.LeftCommand))
        // {
        //     _ARKeyboard.AcceptTestInput("command-left", EKeyState.KEY_UNPRESSED);
        // }
    }
}
