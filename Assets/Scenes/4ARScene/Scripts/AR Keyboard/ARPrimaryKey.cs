using System;
using AR_Keyboard.State;
using DG.Tweening;
using Effects;
using Enums;
using Interfaces;
using TMPro;
using UnityEngine;

namespace AR_Keyboard
{
    public class ARPrimaryKey : Key
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

        public enum EPrimaryKeyState
        {
            AVAILABLE,
            UNAVAILABLE,
            ANIMATION_PAUSE,
            ANIMATION_PLAY,
            TYPING_ON,
            TYPING_OFF,
            // SELECTED
        }
        
        public EPrimaryKeyState primaryKeyState;
        
        public Shortcut currentShortcut;
        
        private void Awake()
        {
            DOTween.Clear();
            DOTween.SetTweensCapacity(200, 125);
            _textMesh = GetComponentInChildren<TextMeshProUGUI>();
            _arKeyboard = GetComponentInParent<ARKeyboard>();
        }


        
        
        public void SetPrimaryKeyState(EPrimaryKeyState state)
        {
            switch (state)
            {
                // case EPrimaryKeyState.ACTIVE:
                //     primaryKeyState = EPrimaryKeyState.ACTIVE;
                //     break;
                // case EPrimaryKeyState.INACTIVE:
                //     primaryKeyState = EPrimaryKeyState.INACTIVE;
                //     break;
                // case EPrimaryKeyState.TYPING_ON:
                //     TypingOn();
                //     break;
                // case EPrimaryKeyState.TYPING_OFFa:
                //     TypingOff();
                //     break;
            }
        }


        private void TypingOn()
        {
            primaryKeyState = EPrimaryKeyState.TYPING_ON;
            KeyColorManager.ChangeKeyColor(this, Color.white);
        }
        
        private void TypingOff()
        {
            primaryKeyState = EPrimaryKeyState.TYPING_OFF;
            KeyColorManager.ChangeKeyColor(this, Color.black);
        }
         // Debug.Log("Typing shortcut called");
         //    if (keyState == EKeyState.KEY_PRESSED)
         //    {
         //        KeyColorManager.ChangeKeyColor(key, Color.gray);
         //    }else if (keyState == EKeyState.KEY_UNPRESSED)
         //    {
         //        var originalColor = Color.black;
         //        KeyColorManager.ChangeKeyColor(key, originalColor);
         //    }
        
    }
}
