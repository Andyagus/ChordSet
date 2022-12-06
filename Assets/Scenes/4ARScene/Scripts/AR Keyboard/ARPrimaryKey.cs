using System;
using System.Net.Mime;
using AR_Keyboard.State;
using DG.Tweening;
using Effects;
using Enums;
using Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
            DEFAULT,
            LEARNING_SHOWCASE,
            LEARNING_AVAILABLE,
            LEARNING_SELECTED,
            LEARNING_HELPER
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
                
                case EPrimaryKeyState.ANIMATION_PAUSE:
                    AnimationPause();
                    break;
                case EPrimaryKeyState.ANIMATION_PLAY:
                    AnimationPlay();
                    break;
                case EPrimaryKeyState.UNAVAILABLE:
                    Unavailable();
                    break;
                case EPrimaryKeyState.TYPING_ON:
                    TypingOn();
                    break;
                case EPrimaryKeyState.TYPING_OFF:
                    TypingOff();
                    break;
                case EPrimaryKeyState.DEFAULT:
                    DefaultState();
                    break;
                case EPrimaryKeyState.LEARNING_SHOWCASE:
                    LearningShowcase();
                    break;
                case EPrimaryKeyState.LEARNING_HELPER:
                    LearningHelper();
                    break;
                case EPrimaryKeyState.LEARNING_AVAILABLE:
                    LearningAvailable();
                    break;
                case EPrimaryKeyState.LEARNING_SELECTED:
                    LearningSelected();
                    break;
            }
        }

        private void LearningSelected()
        {
            primaryKeyState = EPrimaryKeyState.LEARNING_SELECTED;

            var rend = GetComponentInChildren<Renderer>();
            rend.material.DOColor(Color.yellow, 2f);
        }

        private void LearningAvailable()
        {
            primaryKeyState = EPrimaryKeyState.LEARNING_AVAILABLE;

            var rend = GetComponentInChildren<Renderer>();
            rend.material.DOColor(Color.white, 2f);
        }

        private void LearningHelper()
        {
            primaryKeyState = EPrimaryKeyState.LEARNING_HELPER;

            var rend = GetComponentInChildren<Renderer>();
            rend.material.DOColor(Color.red, 2f);
        }

        private void LearningShowcase()
        {
            primaryKeyState = EPrimaryKeyState.LEARNING_SHOWCASE;

            var rend = GetComponentInChildren<Renderer>();
            rend.material.DOColor(Color.cyan, 2f);
            // KeyColorManager.ChangeKeyColor(this, Color.cyan);
        }

        private void DefaultState()
        {
            primaryKeyState = EPrimaryKeyState.DEFAULT;
            KeyColorManager.ChangeKeyColor(this, Color.black);
        }


        private void AnimationPause()
        {
            primaryKeyState = EPrimaryKeyState.ANIMATION_PAUSE;
        }
        
        private void AnimationPlay()
        {
            primaryKeyState = EPrimaryKeyState.ANIMATION_PLAY;
        }

        private void Unavailable()
        {
            primaryKeyState = EPrimaryKeyState.UNAVAILABLE;
            var textGroup = GetComponentsInChildren<TextMeshProUGUI>();
            
            foreach(var text in textGroup)
            {
                text.DOFade(.1f, 1.3f);
            }

            if (GetComponentInChildren<Image>() != null)
            {
                var image = GetComponentInChildren<Image>();
                image.DOFade(.1f, 1.3f);
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
