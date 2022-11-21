using System.Collections;
using System.Collections.Generic;
using AR_Keyboard;
using Enums;
using UnityEngine;

public class CopyShortcut : Shortcut
{
    public override void Execute(EKeyState keyState, ARPrimaryKey key)
    {
        Debug.Log("Copy Shortcut Called");
    }
}
