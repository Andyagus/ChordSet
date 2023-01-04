using System;
using System.Collections;
using System.Collections.Generic;
using AR_Keyboard;
using DG.Tweening;
using UnityEngine;

public class KeyLetterState : MonoBehaviour
{
    private string _originalLetter;

    public enum EKeyLetter
    {
        NONE,
        C,
        H,
        O,
        R,
        D,
        S,
        E,
        T
    }

    public void SetKeyLetterState(EKeyLetter state, ARPrimaryKey primaryKey)
    {
        switch (state)
        {
            case EKeyLetter.NONE:
                RestoreLetter(primaryKey);
                break;
            case EKeyLetter.C:
                ChangeLetter("C", primaryKey);
                break;
            case EKeyLetter.H:
                ChangeLetter("H", primaryKey);
                break;
            case EKeyLetter.O:
                ChangeLetter("O", primaryKey);                
                break;
            case EKeyLetter.R:
                ChangeLetter("R", primaryKey);                
                break;
            case EKeyLetter.D:
                ChangeLetter("D", primaryKey);
                break;
            case EKeyLetter.S:
                ChangeLetter("S", primaryKey);
                break;
            case EKeyLetter.E:
                ChangeLetter("E", primaryKey);
                break;
            case EKeyLetter.T:
                ChangeLetter("T", primaryKey);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(state), state, null);
        }
    }


    private void ChangeLetter(string text, ARPrimaryKey primaryKey)
    {
        _originalLetter = primaryKey.letterText.text;
        primaryKey.letterText.DOText(text, 0f);
    }
    
    private void RestoreLetter(ARPrimaryKey primaryKey)
    {
        primaryKey.letterText.DOText(_originalLetter, 0f);
    }
}
