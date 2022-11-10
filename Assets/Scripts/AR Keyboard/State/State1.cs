using System.Collections;
using System.Collections.Generic;
using AR_Keyboard.State;
using Desktop;
using UnityEngine;

public class State1 : ARKeyboardState
{
    public override void Entry(ARKeyboard keyboard)
    {
        base.Entry(keyboard);
    }

    public override ARKeyboardState HandleInput(InputKey input, ARKeyboard keyboard)
    {
        return base.HandleInput(input, keyboard);
    }
}
