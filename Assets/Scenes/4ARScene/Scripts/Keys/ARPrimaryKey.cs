using DG.Tweening;
using Enums;
using TMPro;
using UnityEngine;

namespace AR_Keyboard
{
    public class ARPrimaryKey : Key
    {
        
        [Header("Primary Key Shortcut State")]
        public Shortcut currentShortcut;
        public KeyShortcutState.EKeyShortcutState keyShortcutState = KeyShortcutState.EKeyShortcutState.NONE;
        private KeyShortcutState.EKeyShortcutState _prevShortcut = KeyShortcutState.EKeyShortcutState.NONE;
        private KeyShortcutState _keyShortcutState;

        [Header("Primary Key Tooltip State")] 
        public Tooltip currentTooltip;
        public TooltipState.ETooltip tooltipState;
        private TooltipState.ETooltip _prevTooltipState;
        private TooltipState _tooltipState;

        [Header("Primary Key Letter State")] 
        public KeyLetterState.EKeyLetter keyLetterState;
        private KeyLetterState.EKeyLetter _previousKeyLetterState;
        private KeyLetterState _keyLetterState;
        
        public override void Awake()
        {
            _keyShortcutState = GetComponent<KeyShortcutState>();
            _keyLetterState = GetComponent<KeyLetterState>();
            _tooltipState = GetComponent<TooltipState>();
            
            DOTween.Clear();
            base.Awake();
        }

        public override void Update()
        {
            if (keyShortcutState != _prevShortcut)
            {
                _keyShortcutState.SetKeyShortcutState(keyShortcutState, this);
                _prevShortcut = keyShortcutState;
            }
            
            if (tooltipState != _prevTooltipState)
            {
                _tooltipState.SetTooltipState(tooltipState, this);
                _prevTooltipState = tooltipState;
            }

            if (keyLetterState != _previousKeyLetterState)
            {
                _keyLetterState.SetKeyLetterState(keyLetterState, this);
                _previousKeyLetterState = keyLetterState;
            }
            
            base.Update();
        }


        public void ResetStatePrimaryKey(KeyAvailabilityState.EKeyAvailability availability)
        {
            // tooltipState = TooltipState.ETooltip.NONE;
            keyShortcutState = KeyShortcutState.EKeyShortcutState.NONE;
            keyAvailability = availability;
            keyOutline = KeyOutlineState.EKeyOutline.NO_OUTLINE;
            keyPressed = EKeyState.KEY_UNPRESSED;

        }

        public void PrimaryKeyAvailable()
        {
            keyAvailability = KeyAvailabilityState.EKeyAvailability.AVAILABLE;
        }

        public void PrimaryKeyUnavailable()
        {
            keyAvailability = KeyAvailabilityState.EKeyAvailability.UNAVAILABLE;
        }

        public void LearningModeAvailable()
        {
            isInLearningMode = true;
            keyOutline = KeyOutlineState.EKeyOutline.OUTLINE;
            keyAvailability = KeyAvailabilityState.EKeyAvailability.AVAILABLE;

        }

        
    }
}
