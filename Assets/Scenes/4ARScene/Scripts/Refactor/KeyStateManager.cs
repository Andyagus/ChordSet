using System;
using System.Collections;
using System.Collections.Generic;
using AR_Keyboard;
using AR_Keyboard.State;
using UnityEngine;

public class KeyStateManager : MonoBehaviour
{
    [SerializeField] private ARKeyboard keyboard;

    private void Awake()
    {
        keyboard.onAmbientStateChanged += OnAmbientStateChanged;
    }

    private void OnAmbientStateChanged(ARKeyboardState state)
    {
        
    }
}
