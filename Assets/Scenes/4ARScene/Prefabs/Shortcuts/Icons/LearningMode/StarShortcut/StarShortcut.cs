using System.Collections;
using System.Collections.Generic;
using AR_Keyboard;
using UnityEngine;
using UnityEngine.UI;

public class StarShortcut : Shortcut
{

    [SerializeField] private Image starImage;
    [SerializeField] private Sprite starOutline;
    [SerializeField] private Sprite starFill;
    [SerializeField] private ParticleSystem starSuccess;
    
    public enum eStarState
    {
        PRESSED,
        UNPRESSED
    }
    
    
}
