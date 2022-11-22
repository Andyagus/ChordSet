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

        private MeshRenderer rend;


        private void Awake()
        {
            rend = GetComponent<MeshRenderer>();
        }

        // modifier state
         public enum EModifierState
         {
             AVAILABLE,
             UNAVAILABLE,
             ACTIVE
         }

         public EModifierState modifierState;

         public void Available()
         {
             modifierState = EModifierState.AVAILABLE;
         }
         
         public void Active()
         {
             modifierState = EModifierState.ACTIVE;
         }

         private void Update()
         {
             switch (modifierState)
             {
                 case EModifierState.AVAILABLE:
                     rend.material.color = Color.blue;
                     break;
                 case EModifierState.UNAVAILABLE:
                     rend.material.color = Color.grey;
                     break;
                 case EModifierState.ACTIVE:
                     rend.material.color = Color.yellow;
                     break;
             }
         }

    }
}
