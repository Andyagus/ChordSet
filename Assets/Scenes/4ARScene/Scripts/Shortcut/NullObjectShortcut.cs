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
        key.SetPrimaryKeyState(ARPrimaryKey.EPrimaryKeyState.UNAVAILABLE);
    }

    public override void Execute(EKeyState keyState, ARPrimaryKey key) {}
}
