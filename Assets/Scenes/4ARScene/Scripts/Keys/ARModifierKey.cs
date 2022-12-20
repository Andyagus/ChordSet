using DG.Tweening;
using TMPro;
using UnityEngine;

namespace AR_Keyboard
{
    public class ARModifierKey : Key
    {

        private MeshRenderer _meshRenderer;
        private Color _originalColor;

        private Sequence _unavailableSequence;
        // public TextMeshProUGUI modifierText;

        public TextMeshProUGUI[] modifierTexts;
        
        public override void Awake()
        {
            modifierTexts = GetComponentsInChildren<TextMeshProUGUI>();
            _meshRenderer = GetComponentInChildren<MeshRenderer>();
            _originalColor = _meshRenderer.material.color;
            base.Awake();
        }
        
         public GameObject activeGlowGameObject;
        
         public override void ResetAllState()
         {
             base.ResetAllState();
         }
 
    }
}
