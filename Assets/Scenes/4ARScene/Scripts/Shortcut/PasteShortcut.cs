using Enums;
using UnityEngine;

namespace AR_Keyboard.Shortcuts.Scripts
{
   public class PasteShortcut : Shortcut
   {
      public override void Execute(EKeyState keyState, ARPrimaryKey key)
      {
         Debug.Log("Paste shortcut called");
      }
   }
}
