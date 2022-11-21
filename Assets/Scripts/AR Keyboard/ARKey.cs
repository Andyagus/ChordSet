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


        public Shortcut currentState;
        
        public Shortcut typingStateShortcut;
        public Shortcut commandStateShortcut;

        public Subject onPrimaryKeyHit;
        
        private ARKeyboard _arKeyboard;
        
        private void Awake()
        {
            _arKeyboard = GameObject.Find("AR Keyboard").GetComponent<ARKeyboard>();
            _arKeyboard.onStateChanged += OnStateChanged;
            onPrimaryKeyHit = new Subject();
        }

        private void OnStateChanged(ARKeyboardState state)
        {
            switch (state.stateName)
            {
                case "Typing":
                    currentState = typingStateShortcut;
                    break;
                case "Command":
                    currentState = commandStateShortcut;
                    break;
            }
            DisplayGraphic();
        }

        private void DisplayGraphic()
        {
            if (currentState != null)
            {
                Debug.Log("Displaying State Graphics");    
            }
            else
            {
                //null object pattern....
                Debug.Log("No state here");
            }
            
            // if (currentState.name != "Empty State")
            // {
            //     Debug.Log("Displaying graphics of: " + currentState.name);
            // }
        }

        public void HandleInput(ARKeyboardState keyboardState, EKeyState keyState)
        {
            currentState.Execute(keyState, this);
        }
    }
}
