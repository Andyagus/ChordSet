using System;
using System.Collections.Generic;
using DG.Tweening;
using Scenes._1Desktop.Scripts;
using Scenes._3MobileAR.Scripts.Keyboard;
using Scenes._3MobileAR.Scripts.Keys;
using Scenes._3MobileAR.Scripts.Keys.Key_States;
using UnityEngine;

namespace Scenes._3MobileAR.Scripts.State___Welcome_Mode
{
    /// <summary>
    /// Welcome Animation, activated when app starts.
    /// TODO: WelcomeMode does not need to be state machine.
    /// TODO: Improve animation to be quicker.  Less than 0.5f 
    /// </summary>
    public class WelcomeModeIntro : ARKeyboardState
    {
        private List<Key> _selectedKeys;
        [SerializeField] private float selectedKeyInterval = 0.06743f;
        [SerializeField] private float outlineLetterInterval = 0.35f;
        [SerializeField] private float textSwapInterval = 0.045f;
        public Action onWelcomeSequenceComplete;
    
        private void Awake()
        {
            _selectedKeys = new List<Key>();
        }

        /// <summary>
        /// Sequentially calling sequences.  When one sequence is complete, OnComplete calls next local sequence.  
        /// </summary>
        public override void Entry(ARKeyboard keyboard)
        {
            LightUpKeys(keyboard);
        }
        
        /// <summary>
        ///Setting all keys to pressed (highlighted) with a small interval
        /// between each highlight and adds to list. 
        /// </summary>
        private void LightUpKeys(ARKeyboard keyboard)
        {
            var localSequence = DOTween.Sequence();
            localSequence.Pause();
        
            var keyCount = keyboard.keys.Count - 1; 
            var index = 0;

            while (index <= keyCount)
            {
                var selectedKey = keyboard.keys[index];
                if (selectedKey.keyPressed != EKeyState.KEY_PRESSED)
                {
                    localSequence.AppendCallback(() =>
                    {
                        selectedKey.keyPressed = EKeyState.KEY_PRESSED;
                        _selectedKeys.Add(selectedKey);
                    });
                    localSequence.AppendInterval(selectedKeyInterval);
                }   
                index++;
            }

            localSequence.Play();
            //Move to next local DOTween Sequence.
            localSequence.OnComplete(() =>
            {
                DimKeys(keyboard);
            });
        }

        /// <summary>
        /// Unhighlight all keys in the list and set to inactive. 
        /// </summary>
        private void DimKeys(ARKeyboard keyboard)
        {
            var localSequence = DOTween.Sequence();
            localSequence.Pause();
        
            foreach (var key in _selectedKeys)
            {
                localSequence.AppendCallback(() =>
                {
                
                    key.keyPressed = EKeyState.KEY_UNPRESSED;
                    key.keyAvailability = KeyAvailabilityState.EKeyAvailability.UNAVAILABLE;
                });
            }
        
            localSequence.Play();
            localSequence.OnComplete(() =>
            {
                OutlineLetters(keyboard);
            });
        }

        /// <summary>
        /// Using the KeyLetterState to swap the Keyboard letters out to say app name "ChordSet"
        /// </summary>
        private void OutlineLetters(ARKeyboard keyboard)
        {
            var localSequence = DOTween.Sequence();
            localSequence.Pause();
            localSequence.AppendInterval(outlineLetterInterval);
            localSequence.AppendCallback(() => TextSwapSequence(keyboard, "Q", KeyLetterState.EKeyLetter.C));
            localSequence.AppendInterval(outlineLetterInterval);
            localSequence.AppendCallback(() => TextSwapSequence(keyboard, "W", KeyLetterState.EKeyLetter.H));
            localSequence.AppendInterval(outlineLetterInterval);
            localSequence.AppendCallback(() => TextSwapSequence(keyboard, "E", KeyLetterState.EKeyLetter.O));
            localSequence.AppendInterval(outlineLetterInterval);
            localSequence.AppendCallback(() => TextSwapSequence(keyboard, "R", KeyLetterState.EKeyLetter.R));
            localSequence.AppendInterval(outlineLetterInterval);
            localSequence.AppendCallback(() => TextSwapSequence(keyboard, "T", KeyLetterState.EKeyLetter.D));
            localSequence.AppendInterval(outlineLetterInterval);
            localSequence.AppendCallback(() => TextSwapSequence(keyboard, "A", KeyLetterState.EKeyLetter.S));
            localSequence.AppendInterval(outlineLetterInterval);
            localSequence.AppendCallback(() => TextSwapSequence(keyboard, "S", KeyLetterState.EKeyLetter.E));
            localSequence.AppendInterval(outlineLetterInterval);
            localSequence.AppendCallback(() => TextSwapSequence(keyboard, "D", KeyLetterState.EKeyLetter.T));
            localSequence.AppendInterval(outlineLetterInterval);
            localSequence.Play();
            localSequence.OnComplete(() =>
            {
                onWelcomeSequenceComplete();
            });
        }
        
        //Nested sequence for setting a new KeyLetterState on a particular key, called from OutlineLetters().        
        private void TextSwapSequence(ARKeyboard keyboard, string letter, KeyLetterState.EKeyLetter keyLetterState)
        {
            var nestedSequence = DOTween.Sequence();
            nestedSequence.Pause();
            var innerKey = keyboard.primaryKeyDictionary[letter];
            nestedSequence.AppendCallback(() => innerKey.keyAvailability = KeyAvailabilityState.EKeyAvailability.AVAILABLE);
            nestedSequence.AppendCallback(() => innerKey.keyPressed = EKeyState.KEY_PRESSED);
            nestedSequence.AppendInterval(textSwapInterval);
            nestedSequence.AppendCallback(() => innerKey.keyLetterState = keyLetterState);
            nestedSequence.AppendInterval(textSwapInterval);
            nestedSequence.AppendCallback(() => innerKey.keyPressed = EKeyState.KEY_UNPRESSED);
            nestedSequence.Play();
        }
        
    }
}
