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
        [NonSerialized] public List<ARKey> primaryKeys;
        // ReSharper disable once InconsistentNaming
        [NonSerialized] public List<ARKey> modifierKeys;

        private KeySyncDictionary _keySyncDictionary;

        private void Awake()
        {
            primaryKeys = GetComponentsInChildren<ARPrimaryKey>().ToList<ARKey>();
            modifierKeys = GetComponentsInChildren<ARModifierKey>().ToList<ARKey>();
            _state = Instantiate(typingState, this.transform, true);
            _state.Entry(this);
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
                HandleInput(keyName, keyState);
            }
        }

        public void AcceptTestInput(string keyName, EKeyState keyState)
        {
            foreach (var key in primaryKeys)
            {
                if (keyName == key.KeyName)
                {
                    key.HandleInput(_state, keyState);
                }
            }

            foreach (var key in modifierKeys)
            {
                if (keyName == key.KeyName)
                {
                    HandleInput(keyName, keyState);
                }
            }
        }
        
        private void HandleInput(string keyName, EKeyState keyState)
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
