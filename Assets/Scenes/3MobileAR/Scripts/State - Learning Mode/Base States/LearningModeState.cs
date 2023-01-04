using System.Collections;
using System.Collections.Generic;
using AR_Keyboard;
using AR_Keyboard.State;
using UnityEngine;

public class LearningModeState : ARKeyboardState
{
    [SerializeField] protected ARKeyboardState nextState;
    [SerializeField] protected ARKeyboardState previousState;
    [SerializeField] public string shortcutName;
    [SerializeField] protected string requiredModifierKey;
    [SerializeField] protected string requiredModifierKey2;
    [SerializeField] protected string requiredPrimaryKey;
}
