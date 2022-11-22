using Enums;
using UnityEngine;

namespace AR_Keyboard.Shortcuts.Scripts
{
    public class CutShortcut : Shortcut
    {
        public override void Execute(EKeyState keyState, ARPrimaryKey key)
        {
            Debug.Log("Cut Shortcut Called");
            var primaryKey = GetComponentInParent<ARPrimaryKey>();
            // primaryKey.onPrimaryKeyHit.Notify(this);
        }
    }
}
