using System;
using System.Collections.Generic;
using System.Linq;
using AR_Keyboard.State;
using Desktop;
using Enums;
using Interfaces;
using Normal.Realtime.Serialization;
using Normcore;
using UnityEngine;
using UnityEngine.UIElements;

namespace AR_Keyboard
{
    public class ARKeyboard : MonoBehaviour
    {
        public GameObject debugSphere;
        private ARKeyboardState _state;

        public ARKeyboardState typingState;
        public ARKeyboardState commandState;


        public Action<ARKeyboardState> onStateChanged;
        
        // public List<ARKeyboardState> states;
        // public ARKeyboardState initialState;
        
        // ReSharper disable once InconsistentNaming
        [NonSerialized] public List<ARPrimaryKey> primaryKeys;
        // ReSharper disable once InconsistentNaming
        [NonSerialized] public List<ARModifierKey> modifierKeys;

        private KeySyncDictionary _keySyncDictionary;

        private void Awake()
        {
            
            primaryKeys = GetComponentsInChildren<ARPrimaryKey>().ToList();
            modifierKeys = GetComponentsInChildren<ARModifierKey>().ToList();
            _state = Instantiate(typingState, this.transform, true);
            _state.Entry(this);
            onStateChanged(_state);
        }

        //TODO Just for dictionary testing
        private void Start()
        {
            _keySyncDictionary = FindObjectOfType<KeySyncDictionary>();
        }

        public void OnKeyDictionaryReceived(RealtimeDictionary<KeySyncModel> dict)
        {
            foreach (var kvp in dict)
            {
                var keyName = kvp.Value.keyName;
                var keyState = kvp.Value.keyState;
                HandleModifierInput(keyName, keyState);
            }
        }
        
        public void DelegateInput(string keyName, EKeyState keyState)
        {
            // foreach (var primaryKey in primaryKeys)
            // {
            //     if (primaryKey.KeyName == keyName)
            //     {
            //         HandlePrimaryInput(primaryKey, keyName, keyState);
            //     }
            // }
            
            
            foreach (var primaryKey in primaryKeys)
            {
                if (primaryKey.KeyName == keyName)
                {
                    if (primaryKey.typingStateShortcut != null)
                    {
                        Debug.Log("Has typing state");
                    }
                    // HandlePrimaryInput(primaryKey, keyName, keyState);
                }
            }

            foreach (var modifierKey in modifierKeys)
            {
                if (modifierKey.KeyName == keyName)
                {
                    HandleModifierInput(keyName, keyState);
                }
            }
        }
        
        public void AcceptTestInput(string keyName, EKeyState keyState)
        {
             
            DelegateInput(keyName, keyState);
            //TODO: use inheritance to put both primary and modifiers in one list, and then delegate to different handle inputs based on type 
            
            // foreach (var key in primaryKeys)
            // {
            //     if (keyName == key.KeyName)
            //     {
            //         HandlePrimaryInput(key, keyName, keyState);
            //     }
            // }
            //
            // foreach (var key in modifierKeys)
            // {
            //     if (keyName == key.KeyName)
            //     {
            //         HandleModifierInput(keyName, keyState);
            //     }
            // }
        }

        private void HandlePrimaryInput(ARPrimaryKey primaryKey, string keyName, EKeyState keyState)
        {
            primaryKey.HandleInput(_state, keyState);
        }
        
        
        private void HandleModifierInput(string keyName, EKeyState keyState)
        {
            
            var state = _state.HandleInput(keyName, keyState, this);
            
            if (state != null)
            {
                _state.Exit(this);
                Destroy(_state.gameObject);
                _state = state;
                _state.transform.SetParent(this.transform);
                _state.Entry(this);
                onStateChanged(_state);
            }
        }
   
    }
}
