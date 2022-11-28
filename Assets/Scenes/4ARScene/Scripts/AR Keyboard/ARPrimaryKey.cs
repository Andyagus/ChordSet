using System;
using AR_Keyboard.State;
using DG.Tweening;
using Enums;
using Interfaces;
using TMPro;
using UnityEngine;

namespace AR_Keyboard
{
    public class ARPrimaryKey : MonoBehaviour, IKey
    {
        private ARKeyboard _arKeyboard;
        
        [SerializeField] private string keyName;
        [SerializeField] private KeyCode keycode;

        [SerializeField] public Shortcut typingStateShortcut;
        [SerializeField] public Shortcut commandStateShortcut;

        private TextMeshProUGUI _textMesh;
        
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
            _textMesh = GetComponentInChildren<TextMeshProUGUI>();
            _arKeyboard = GetComponentInParent<ARKeyboard>();
            _arKeyboard.onStateChanged += OnStateChanged;
            // currentShortcut = typingStateShortcut;
        }

        private void Start()
        {
            if (_textMesh != null)
            {
                _textMesh.text = KeyName;
            }
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
            // if (_textMesh != null)
            // {
            //     // Debug.Log("TEXT MESH):");
            //     _textMesh.DOText("hello", 1);
            // }

            //don't like how I am breaking command pattern by adding an additional method here.
            //Command pattern typically only has execute function 
            //But setgraphics is ' required ' because serves different function 
            //is this becoming too much like a seperate state machine? (Entry Method?) - -can improve
            // in the future get the graphics working
            
            currentShortcut.SetGraphics();  
        }

        public void HandleInput(ARKeyboardState keyboardState, EKeyState keyState)
        {
            currentShortcut.Execute(keyState, this);
        }
    }
}
