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
        [Header("Primary Key State")]
        public Shortcut currentShortcut;
        private KeyShortcutState _keyShortcutState;
        public KeyShortcutState.EKeyShortcutState keyShortcutState = KeyShortcutState.EKeyShortcutState.NONE;
        private KeyShortcutState.EKeyShortcutState _prevShortcut = KeyShortcutState.EKeyShortcutState.NONE;
        
        public override void Awake()
        {
            _keyShortcutState = GetComponent<KeyShortcutState>();
            
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
            base.Update();
        }

        public void ResetCharacter()
        {
            var tmp = GetComponentInChildren<TextMeshProUGUI>();
            tmp.text = KeyName;
        }

        
    }
}
