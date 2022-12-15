using System;
using System.Net.Mime;
using AR_Keyboard.State;
using DG.Tweening;
using Effects;
using Enums;
using Interfaces;
using Scenes._4ARScene.Scripts.AR_Keyboard;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AR_Keyboard
{
    public class ARPrimaryKey : Key
    {
        private ARKeyboard _arKeyboard;
        
        
        public TextMeshProUGUI keyText;
        
        
        private TextMeshProUGUI _textMesh;

        public Shortcut primaryCurrentShortcut;
        [Tooltip("Primary Key Shortcut State")]
        private KeyShortcutState _keyShortcutState;
        public KeyShortcutState.EKeyShortcutState keyShortcutState = KeyShortcutState.EKeyShortcutState.NO_SHORTCUT;
        private KeyShortcutState.EKeyShortcutState _prevShortcut = KeyShortcutState.EKeyShortcutState.NO_SHORTCUT;

        [Header("UI Shortcut State")] 
        private UIShortcutState _uiShortcutState;

        public UIShortcutState.EuiShortcutState uiShortcutState = UIShortcutState.EuiShortcutState.NONE;
        private UIShortcutState.EuiShortcutState _prevUiShortcutState = UIShortcutState.EuiShortcutState.NONE;

        public override void Awake()
        {
            _keyShortcutState = GetComponent<KeyShortcutState>();
            _uiShortcutState = GetComponent<UIShortcutState>();
            
            DOTween.Clear();
            _textMesh = GetComponentInChildren<TextMeshProUGUI>();
            _arKeyboard = GetComponentInParent<ARKeyboard>();
            base.Awake();
        }

        public override void Update()
        {
            if (keyShortcutState != _prevShortcut)
            {
                _keyShortcutState.SetKeyShortcutState(keyShortcutState, this);
                _prevShortcut = keyShortcutState;
            }

            if (uiShortcutState != _prevUiShortcutState)
            {
                _uiShortcutState.SetUIState(uiShortcutState, this);
                _prevUiShortcutState = uiShortcutState;
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
