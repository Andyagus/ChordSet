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
            DOTween.Clear();
            DOTween.SetTweensCapacity(200, 125);
            _textMesh = GetComponentInChildren<TextMeshProUGUI>();
            _arKeyboard = GetComponentInParent<ARKeyboard>();
            _arKeyboard.onStateChanged += OnStateChanged;


            // currentShortcut = new GameObject("Shortcut").AddComponent<Shortcut>();
            // currentShortcut.transform.SetParent(this.transform);
        }
        
        private void OnStateChanged(ARKeyboardState state)
        {
            StopSequence();
            
            switch (state.stateName)
            {
               default:
                   break;
            }

            SetGraphics();
        }

        private void StopSequence()
        {
            if (currentShortcut != null)
            {
                currentShortcut.StopSequence();
            }
        }


        private void SetGraphics()
        {
            
            if (currentShortcut != null)
            {
                var offset = new Vector3(0f, 0.00013f, 0f);
                currentShortcut.SetGraphics(key: this);
            }
        }

        public void HandleInput(ARKeyboardState keyboardState, EKeyState keyState)
        {
            if (currentShortcut != null)
            {
                currentShortcut.Execute(keyState, this);
            }
        }
    }
}
