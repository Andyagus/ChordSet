using System.Collections;
using System.Collections.Generic;
using AR_Keyboard;
using AR_Keyboard.State;
using UnityEngine;

public class SelectAllShortcutState : ARKeyboardState
{
   public override void Entry(ARKeyboard keyboard)
   {
      Debug.Log("In select all shortcut state");
   }
}
