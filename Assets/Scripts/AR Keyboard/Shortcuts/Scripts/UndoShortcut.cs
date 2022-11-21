using Enums;
using UnityEngine;

namespace AR_Keyboard.Shortcuts.Scripts
{
    public class UndoShortcut : Shortcut
    {
        public override void Execute(EKeyState keyState, ARKey key)
        {
            Debug.Log("Undo Shortcut Called");
        }
    }
}
