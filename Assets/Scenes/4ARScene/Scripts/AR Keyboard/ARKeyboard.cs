using System;
using System.Collections.Generic;
using System.Linq;
using AR_Keyboard.State;
using Desktop;
using DG.Tweening;
using Enums;
using Interfaces;
using Normal.Realtime.Serialization;
using Normcore;
using UnityEngine;


namespace AR_Keyboard
{
    public class ARKeyboard : MonoBehaviour
    {
        private ARKeyboardState _ambientModeState;
        public ARKeyboardState typingState;
        public ARKeyboardState commandState;
        public Action<ARKeyboardState> onStateChanged;

        [NonSerialized] public List<ARPrimaryKey> primaryKeys;
        [NonSerialized] public List<ARModifierKey> modifierKeys;

        private KeySyncDictionary _keySyncDictionary;

        private void Awake()
        {
            primaryKeys = GetComponentsInChildren<ARPrimaryKey>().ToList();
            modifierKeys = GetComponentsInChildren<ARModifierKey>().ToList();
            _ambientModeState = Instantiate(typingState, this.transform, true);
            _ambientModeState.Entry(this);
     
        }

        private void Start()
        {
            if (onStateChanged != null)
            {
                onStateChanged(_ambientModeState);
            }
            _keySyncDictionary = FindObjectOfType<KeySyncDictionary>();
        }

        private void Update()
        {

            foreach (var key in primaryKeys)
            {
                if (key.keyPressedState == EKeyState.KEY_PRESSED)
                {
                    Debug.Log(key.KeyName);
                }
                
            }   
        }

        public void OnKeyDictionaryReceived(RealtimeDictionary<KeySyncModel> dict)
        {
            Debug.Log("dictionary count: " + dict.Count);
            foreach (var kvp in dict)
            {
                var keyName = kvp.Value.keyName;
                var keyState = kvp.Value.keyState;
                DelegateInput(keyName, keyState);
            }
        }
        
        
        private void DelegateInput(string inputKeyName, EKeyState inputKeyState)
        {
            foreach (var primaryKey in primaryKeys)
            {
                if (inputKeyName == primaryKey.KeyName)
                {
                    if (primaryKey.keyPressedState == EKeyState.KEY_UNPRESSED)
                    {
                        if (inputKeyState == EKeyState.KEY_PRESSED)
                        {
                            primaryKey.SetPressedState(EKeyState.KEY_PRESSED);
                            HandleInput(inputKeyName, inputKeyState);
                        }
                    }
                    if (primaryKey.keyPressedState == EKeyState.KEY_PRESSED)
                    {
                        if (inputKeyState == EKeyState.KEY_UNPRESSED)
                        {
                            primaryKey.SetPressedState(EKeyState.KEY_UNPRESSED);
                            HandleInput(inputKeyName, inputKeyState);

                        }
                    }
                }    
            }
            
            foreach (var modifierKey in modifierKeys)
            {
                if (inputKeyName == modifierKey.KeyName)
                {
                    if (modifierKey.keyPressedState == EKeyState.KEY_UNPRESSED)
                    {
                        if (inputKeyState == EKeyState.KEY_PRESSED)
                        {
                            modifierKey.SetPressedState(EKeyState.KEY_PRESSED);
                            HandleInput(inputKeyName, inputKeyState);
                        }
                    }
                    if (modifierKey.keyPressedState == EKeyState.KEY_PRESSED)
                    {
                        if (inputKeyState == EKeyState.KEY_UNPRESSED)
                        {
                            modifierKey.SetPressedState(EKeyState.KEY_UNPRESSED);
                            HandleInput(inputKeyName, inputKeyState);

                        }
                    }
                }    
            }
            
        }

        public void AcceptTestInput(string keyName, EKeyState keyState)
        {
            if (keyName == "A")
            {
                DelegateInput(keyName, keyState);
            }
        }
        

        private void HandleInput(string keyName, EKeyState keyState)
        {
            
            var state = _ambientModeState.HandleInput(keyName, keyState, this);
            
            if (state != null)
            {
                _ambientModeState.Exit(this);
                Destroy(_ambientModeState.gameObject);
                _ambientModeState = state;
                _ambientModeState.transform.SetParent(this.transform);
                _ambientModeState.Entry(this);
                onStateChanged(_ambientModeState);
                // StateChanged();
            }
        }
        
        }
}

