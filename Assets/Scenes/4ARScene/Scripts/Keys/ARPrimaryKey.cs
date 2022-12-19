using DG.Tweening;
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
        
        
        
        public override void Awake()
        {
            _keyShortcutState = GetComponent<KeyShortcutState>();
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
            
            base.Update();
        }

        public void ResetCharacter()
        {
            var tmp = GetComponentInChildren<TextMeshProUGUI>();
            tmp.text = KeyName;
        }

        
    }
}
