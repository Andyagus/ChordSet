using System;
using System.Collections.Generic;
using AR_Keyboard.State;
using Interfaces;
using TMPro;
using UnityEngine;
using Enums;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UI;

namespace AR_Keyboard
{
    //maybe implement subscriber observer here
    public class Shortcut : MonoBehaviour
    {
        
        public Subject onShortcutExecuted;
        public EShortcuts eShortcut;
        public string shortcutName;

        public virtual void Awake()
        {
            onShortcutExecuted = new Subject();
        }
        

        public virtual void Execute(EKeyState keyState, ARPrimaryKey key) {}

        public virtual void SetGraphics(ARPrimaryKey key){}

        public virtual void StopSequence() {}
    }
}
