using System;
using Interfaces;
using UnityEngine;

namespace AR_Keyboard
{
    public class ARModifierKey : MonoBehaviour, IKey
    {
        [SerializeField] private string keyName;
        public string KeyName { get => keyName; set => keyName = value; }
        [SerializeField] private KeyCode keyCode;
        public KeyCode KeyCode { get => keyCode; set => keyCode = value; }
        
        // modifier state
         public enum EModifierState
         {
             AVAILABLE,
             UNAVAILABLE,
             ACTIVE
         }

         public EModifierState modifierState = EModifierState.ACTIVE;

         private void Update()
         {
             
         }
    }
}
