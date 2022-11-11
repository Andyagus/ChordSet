using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndoShortcut : Shortcut
{
    public override void Execute()
    {
        Debug.Log("Undo Shortcut Called");
    }
}
