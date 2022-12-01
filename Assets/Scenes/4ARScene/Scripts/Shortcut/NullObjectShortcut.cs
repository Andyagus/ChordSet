using System.Collections;
using System.Collections.Generic;
using AR_Keyboard;
using DG.Tweening;
using Enums;
using TMPro;
using UnityEngine;

public class NullObjectShortcut : Shortcut
{
    public override void SetGraphics(ARPrimaryKey key)
    {
        
        
        var text = key.GetComponentInChildren<TextMeshProUGUI>();
        text.DOFade(.1f, 1.3f);
    }

    public override void Execute(EKeyState keyState, ARPrimaryKey key) {}
}
