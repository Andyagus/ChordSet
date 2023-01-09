using DG.Tweening;
using Scenes._3MobileAR.Scripts.Keys.Key_States;
using Scenes._3MobileAR.Scripts.Keys.Shortcuts;
using Scenes._3MobileAR.Scripts.Keys.Tooltips;
using UnityEngine;

namespace Scenes._3MobileAR.Scripts.Keys.Primary_Key
{
    /// <summary>
    /// Primary Key Class (All but modifier keys (cmd, shift, etc)) holds additional states
    /// for shortcuts and tooltips.  GameObjects also hold different outlines, and are different shapes. 
    /// </summary>
    public class ARPrimaryKey : Key
    {
        [Header("Primary Key Shortcut State")]
        //Holds reference to currently active shortcut, this can be called through 
        //the ambient mode state machine
        public Shortcut currentShortcut;
        public KeyShortcutState.EKeyShortcutState keyShortcutState = KeyShortcutState.EKeyShortcutState.NONE;
        private KeyShortcutState.EKeyShortcutState _prevShortcutState = KeyShortcutState.EKeyShortcutState.NONE;
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
            //Accessing local state machines.
            _keyShortcutState = GetComponent<KeyShortcutState>();
            _keyLetterState = GetComponent<KeyLetterState>();
            _tooltipState = GetComponent<TooltipState>();
            
            DOTween.Clear();
            base.Awake();
        }

        public override void Update()
        {
            if (keyShortcutState != _prevShortcutState)
            {
                _keyShortcutState.SetKeyShortcutState(keyShortcutState, this);
                _prevShortcutState = keyShortcutState;
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

        /// <summary>
        /// Resetting primary key back to original state.  Base State handles most states.
        /// Here also removing tooltips and shortcuts.
        /// KeyLetterState is primarily used for WelcomeModeStateIntro. 
        /// </summary>
        public override void ResetAllState()
        {
            tooltipState = TooltipState.ETooltip.NONE;
            keyShortcutState = KeyShortcutState.EKeyShortcutState.NONE;
            keyLetterState = KeyLetterState.EKeyLetter.NONE;
            base.ResetAllState();
        }

        
    }
}
