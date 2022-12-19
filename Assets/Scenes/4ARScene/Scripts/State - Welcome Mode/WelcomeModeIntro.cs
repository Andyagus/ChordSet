using System;
using System.Collections;
using System.Collections.Generic;
using AR_Keyboard;
using AR_Keyboard.State;
using DG.Tweening;
using Enums;
using UnityEngine;
using Random = UnityEngine.Random;

public class WelcomeModeIntro : ARKeyboardState
{
    private Sequence _sequence;
    private List<Key> _selectedKeys;

    private void Awake()
    {
        _selectedKeys = new List<Key>();
    }

    public override void Entry(ARKeyboard keyboard)
    {
        LightUpKeys(keyboard);
        // OutlineLetters(keyboard);
    }

    private void LightUpKeys(ARKeyboard keyboard)
    {
        var localSequence = DOTween.Sequence();
        localSequence.Pause();
        
        var keyCount = keyboard.keys.Count - 1; 
        var randomKeyIndex = Random.Range(0, keyCount);
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
                localSequence.AppendInterval(0.06743f);
            }   
            index++;
        }

        localSequence.Play();
        localSequence.OnComplete(() =>
        {
            DimKeys(keyboard);
        });
    }

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

    private void OutlineLetters(ARKeyboard keyboard)
    {
        var localSequence = DOTween.Sequence();
        localSequence.Pause();

        //editor hiccups
        localSequence.AppendInterval(1f);
        localSequence.AppendCallback(() => TextSwapSequence(keyboard, "Q", KeyLetterState.EKeyLetter.C));
        localSequence.AppendInterval(1f);
        localSequence.AppendCallback(() => TextSwapSequence(keyboard, "W", KeyLetterState.EKeyLetter.H));
        localSequence.AppendInterval(1f);
        localSequence.AppendCallback(() => TextSwapSequence(keyboard, "E", KeyLetterState.EKeyLetter.O));
        localSequence.AppendInterval(1f);
        localSequence.AppendCallback(() => TextSwapSequence(keyboard, "R", KeyLetterState.EKeyLetter.R));
        localSequence.AppendInterval(1f);
        localSequence.AppendCallback(() => TextSwapSequence(keyboard, "T", KeyLetterState.EKeyLetter.D));
        localSequence.AppendInterval(1f);
        localSequence.AppendCallback(() => TextSwapSequence(keyboard, "A", KeyLetterState.EKeyLetter.S));
        localSequence.AppendInterval(1f);
        localSequence.AppendCallback(() => TextSwapSequence(keyboard, "S", KeyLetterState.EKeyLetter.E));
        localSequence.AppendInterval(1f);
        localSequence.AppendCallback(() => TextSwapSequence(keyboard, "D", KeyLetterState.EKeyLetter.T));
        localSequence.Play();
    }

    private void TextSwapSequence(ARKeyboard keyboard, string letter, KeyLetterState.EKeyLetter state)
    {
        var innerSequence = DOTween.Sequence();
        innerSequence.Pause();
        var innerKey = keyboard.primaryKeyDictionary[letter];
        innerSequence.AppendCallback(() => innerKey.keyAvailability = KeyAvailabilityState.EKeyAvailability.AVAILABLE);
        innerSequence.AppendCallback(() => innerKey.keyPressed = EKeyState.KEY_PRESSED);
        innerSequence.AppendInterval(0.045f);
        innerSequence.AppendCallback(() => innerKey.keyLetterState = state);
        innerSequence.AppendInterval(0.045f);
        innerSequence.AppendCallback(() => innerKey.keyPressed = EKeyState.KEY_UNPRESSED);
        innerSequence.Play();
    }
    
    public override ARKeyboardState HandleInput(Key key, ARKeyboard keyboard)
    {
        return null;
    }
}
