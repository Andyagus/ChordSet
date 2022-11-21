using Interfaces;
using System.Collections.Generic;
using AR_Keyboard.State;
using Enums;
using UnityEngine;

namespace AR_Keyboard
{
    public class ARKey : MonoBehaviour, IKey
    {
        [SerializeField] private string keyName;
        public string KeyName
        {
            get => keyName;
            set => keyName = value;
        }

        [SerializeField] private KeyCode keyCode;
        public KeyCode KeyCode
        {
            get => keyCode;
            set => keyCode = value;
        }

        public Shortcut typingStateShortcut;
        public Shortcut commandStateShortcut;
        //Other shortcuts...
        //public Shortcut commandShiftStateShortcut;
        //public Shortcut commandShiftStateShortcut;

        public Subject onPrimaryKeyHit;
    
        private void Awake()
        {
            onPrimaryKeyHit = new Subject();
        }

        public void HandleInput(ARKeyboardState keyboardState, EKeyState keyState)
        {
            switch (keyboardState.stateName)
            {
                case "Typing":
                    typingStateShortcut.Execute();
                    break;
                case "Command":
                    commandStateShortcut.Execute();
                    break;
            }
        }
    }
}
