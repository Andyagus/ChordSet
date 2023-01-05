using System;
using Interfaces;
using UnityEngine;

namespace Scenes._1Desktop.Scripts
{
    /// <summary>
    ///InputKey class is instanced in the Unity Scene - and they keep track of the keyboard keys being pressed
    /// and then sends an event most importantly received by the the input manager.
    /// </summary>
    public class InputKey : MonoBehaviour, IKey
    {
        //TODO: CONSISTENCY - remove underscore from _keyName and _keyCode.  Will need to reserialize;
        [SerializeField] private string _keyName;
        public Action<InputKey> onKeyChanged;

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
            onKeyChanged(this);
            _prevState = keyState;
        }
    }
}
