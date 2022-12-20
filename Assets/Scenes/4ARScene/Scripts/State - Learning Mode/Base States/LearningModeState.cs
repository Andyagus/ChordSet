using System.Collections;
using System.Collections.Generic;
using AR_Keyboard.State;
using UnityEngine;

public class LearningModeState : ARKeyboardState
{
    [SerializeField] protected ARKeyboardState nextState;
    [SerializeField] protected ARKeyboardState previousState;

}
