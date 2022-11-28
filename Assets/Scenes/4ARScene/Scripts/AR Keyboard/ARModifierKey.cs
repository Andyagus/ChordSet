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

        private MeshRenderer _meshRenderer;


        private void Awake()
        {
            _meshRenderer = GetComponentInChildren<MeshRenderer>();
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
                     _meshRenderer.material.color = Color.blue;
                     break;
                 case EModifierState.UNAVAILABLE:
                     _meshRenderer.material.color = Color.grey;
                     break;
                 case EModifierState.ACTIVE:
                     _meshRenderer.material.color = Color.yellow;
                     break;
             }
         }

    }
}
