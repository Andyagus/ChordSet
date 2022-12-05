using System;
using System.Collections;
using DG.Tweening;
using Interfaces;
using TMPro;
using UnityEngine;

namespace AR_Keyboard
{
    public class ARModifierKey : Key
    {
        [SerializeField] private string keyName;
        public string KeyName { get => keyName; set => keyName = value; }
        [SerializeField] private KeyCode keyCode;
        public KeyCode KeyCode { get => keyCode; set => keyCode = value; }

        private MeshRenderer _meshRenderer;
        private Color _originalColor;

        private Sequence _unavailableSequence;
        // public TextMeshProUGUI modifierText;

        public TextMeshProUGUI[] modifierTexts;

        public enum EModifierKeyState
        {
            AVAILABLE,
            ACTIVE,
            UNAVAILABLE,
            DEFAULT
        }

        public EModifierKeyState modifierState;
        
        private void Awake()
        {
            modifierTexts = GetComponentsInChildren<TextMeshProUGUI>();
            _meshRenderer = GetComponentInChildren<MeshRenderer>();
            _originalColor = _meshRenderer.material.color;
        }
        
         public GameObject activeGlowGameObject;


         public void ChangeLocalState(EModifierKeyState state)
         {
             switch (state)
             {
                 case EModifierKeyState.AVAILABLE:
                     Available();
                     break;
                 case EModifierKeyState.ACTIVE:
                     Active();
                     break;
                 case EModifierKeyState.UNAVAILABLE:
                     Unavailable();
                     break;
                 case EModifierKeyState.DEFAULT:
                     DefaultState();
                     break;
                 default:
                     break;
             }
         }

         private void DefaultState()
         {
             modifierState = EModifierKeyState.DEFAULT;
             var rend = GetComponentInChildren<MeshRenderer>();
             rend.material.DOColor(Color.black, 0.34f);
         }

         private void Available()
         {
             modifierState = EModifierKeyState.AVAILABLE;
             var rend = GetComponentInChildren<MeshRenderer>();
             rend.material.DOColor(Color.yellow, 0.34f);
             // var glow = Instantiate(activeGlowGameObject, transform);
             // glow.transform.position = transform.position;
         }

         private void Unavailable()
         {
             modifierState = EModifierKeyState.UNAVAILABLE;
             StartCoroutine(FadeOutKeys());
         }
         
         private void Active()
         {
             modifierState = EModifierKeyState.ACTIVE;
             var rend = GetComponentInChildren<MeshRenderer>();
             rend.material.DOColor(Color.white, 0.74652f);
         }

         private IEnumerator FadeOutKeys()
         {
             //for editor hiccups
             yield return new WaitForSeconds(0.1f);
             _unavailableSequence = DOTween.Sequence();

             foreach (var text in modifierTexts)
             {
                _unavailableSequence.Insert(0, text.DOFade(0.1f, 1f));
             }
             _unavailableSequence.SetAutoKill(false);
         }
         
        

    }
}
