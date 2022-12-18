using System;
using AR_Keyboard;
using UnityEngine;

public class ShortcutMicroState : MonoBehaviour
{
   public enum EShortcutMicroState
   {
      PRESSED,
      UNPRESSED
   }

   public void SetShortcutMicroState(EShortcutMicroState state, Shortcut shortcut)
   {
      switch (state)
      {
         case EShortcutMicroState.PRESSED:
            Pressed();
            break;
         case EShortcutMicroState.UNPRESSED:
            Unpressed();
            break;
         default:
            throw new ArgumentOutOfRangeException(nameof(state), state, null);
      }
   }
   
   private void Pressed()
   {
      Debug.Log("Pressed");
   }
   
   private void Unpressed()
   {
      Debug.Log("Unpressed");
   }
}
