using System;
using AR_Keyboard.State;
using Enums;
using Interfaces;
using UnityEngine;

namespace AR_Keyboard
{
    public class ARPrimaryKey : MonoBehaviour, IKey
    {
        private ARKeyboard _arKeyboard;
        
        [SerializeField] private string keyName;
        [SerializeField] private KeyCode keycode;

        [SerializeField] public Shortcut typingStateShortcut;
        [SerializeField] private Shortcut commandStateShortcut;
        
        public string KeyName
        {
            get => keyName;
            set => keyName = value;
        }
        public KeyCode KeyCode
        {
            get => keycode;
            set => keycode = value;
        }

        public Shortcut currentShortcut;
        
        private void Awake()
        {
            _arKeyboard = GetComponentInParent<ARKeyboard>();
            _arKeyboard.onStateChanged += OnStateChanged;
            // currentShortcut = typingStateShortcut;
        }

        private void OnStateChanged(ARKeyboardState state)
        {
            switch (state.stateName)
            {
                case "Typing":
                    currentShortcut = typingStateShortcut;
                    break;
                case "Command": 
                    currentShortcut = commandStateShortcut;
                    break;
            }

            SetGraphics();
        }

        private void SetGraphics()
        {
            
        }

        public void HandleInput(ARKeyboardState keyboardState, EKeyState keyState)
        {
            currentShortcut.Execute(keyState, this);
        }
    }
}
