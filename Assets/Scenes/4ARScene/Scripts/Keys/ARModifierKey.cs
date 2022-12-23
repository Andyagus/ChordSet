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


         public void ModifierKeyAvailable()
         {
             keyOutline = KeyOutlineState.EKeyOutline.OUTLINE;
             keyAvailability = KeyAvailabilityState.EKeyAvailability.AVAILABLE;
         }

         public void ModifierKeyUnavailable()
         {
             if (!isInLearningMode)
             {
                 keyOutline = KeyOutlineState.EKeyOutline.NO_OUTLINE;
                 keyAvailability = KeyAvailabilityState.EKeyAvailability.UNAVAILABLE;
             }
         }
         

         public void ResetStateModifierKey()
         {
             keyAvailability = KeyAvailabilityState.EKeyAvailability.AVAILABLE;
             keyOutline = KeyOutlineState.EKeyOutline.NO_OUTLINE;
             
         }

         public void LearningModeAvailable()
         {
             isInLearningMode = true;
             keyAvailability = KeyAvailabilityState.EKeyAvailability.AVAILABLE;
             keyOutline = KeyOutlineState.EKeyOutline.OUTLINE;

         }
         
         // public void ResetStateAvailable()
         // {
         //     keyAvailability = KeyAvailabilityState.EKeyAvailability.AVAILABLE;
         //     keyColorState = KeyColorState.EKeyColorState.BLACK;
         //     keyOutline = KeyOutlineState.EKeyOutline.NO_OUTLINE;
         // }
         
         // public override void ResetAllState()
         // {
         //     base.ResetAllState();
         // }
 
    }
}
