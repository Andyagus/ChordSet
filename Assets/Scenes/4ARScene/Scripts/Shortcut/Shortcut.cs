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
        //
        public Subject onShortcutExecuted;
        public EShortcuts eShortcut;
        
        // public ARKeyboardState requiredState;

        // public ARModifierKey modifierKey;
        
        public string shortcutName;
        // public Image shortcutImage;
        // public TextMeshProUGUI textMeshPro;

        
        public virtual void Awake()
        {
            onShortcutExecuted = new Subject();
            
            
            
            
            // onShortcutExecuted.GetInstanceID();
            // textMeshPro.text = shortcutName;
        }
        

        public virtual void Execute(EKeyState keyState, ARPrimaryKey key) {}

        public virtual void SetGraphics(ARPrimaryKey key){}

        public virtual void StopSequence() {}
    }
}