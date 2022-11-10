using System;
using Enums;
using Interfaces;
using UnityEngine;

namespace Desktop
{
    public class InputKey : MonoBehaviour, IKey
    {
        [SerializeField] private string _keyName;
        public Subject onKeyChanged;

        public string KeyName
        {
            get => _keyName;
            set => _keyName = value;
        }

        [SerializeField] private KeyCode _keyCode;

        public KeyCode KeyCode
        {
            get => _keyCode;
            set => _keyCode = value;
        }

        [SerializeField] public EKeyState keyState; 
        private EKeyState _prevState;

        private void Awake()
        {
            onKeyChanged = new Subject();
            _prevState = keyState;
        }

        private void Update()
        {
            if (Input.GetKeyDown(_keyCode))
            {
                keyState = EKeyState.KEY_PRESSED;
            }

            if (Input.GetKeyUp(_keyCode))
            {
                keyState = EKeyState.KEY_UNPRESSED;
            }

            if (_prevState == keyState) return;
            onKeyChanged.Notify(this);
            _prevState = keyState;
        }
    }
}
