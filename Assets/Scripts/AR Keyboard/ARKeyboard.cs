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
using UnityEngine.Rendering.VirtualTexturing;

namespace AR_Keyboard
{
    public class ARKeyboard : MonoBehaviour, IObserver
    {
        public GameObject debugSphere;
        private ARKeyboardState _state;
    
        //convenience list for instantiation
        public List<ARKeyboardState> states;
    
        [NonSerialized] public List<ARKey> ARPrimaryKeys;
        [NonSerialized] public List<ARKey> ARModifierKeys;
    
        private KeySyncDictionary _keySyncDictionary;

        
        private void Awake()
        {

            ARPrimaryKeys = GetComponentsInChildren<ARPrimaryKey>().ToList<ARKey>();
            ARModifierKeys = GetComponentsInChildren<ARModifierKey>().ToList<ARKey>();
            _state = Instantiate(states[0], this.transform, true);
            _state.Entry(this);
        }

        //TODO Just for dictionary testing
        private void Start()
        {
            _keySyncDictionary = FindObjectOfType<KeySyncDictionary>();
            
        }

        public void OnKeyDictionaryReceived(uint keyCode, RealtimeDictionary<KeySyncModel> dict)
        {
            foreach (var kvp in dict)
            {
                var inputKey = new GameObject().AddComponent<InputKey>();
                inputKey.KeyName = kvp.Value.keyName;
                inputKey.keyState = kvp.Value.keyState;
                
                HandleInput(inputKey);
            }
            // // dict[keyCode].keyName;
            // foreach (var kvp in dict)
            // {
            //     // kvp[keyCode]
            //     // Debug.Log(kvp.Key);
            //     // HandleInput(kvp.Value);    
            // }
        }
        
        public void OnKeyReceived(string keyName, EKeyState keyState)
        {
            
            // var inputKey = new GameObject().AddComponent<InputKey>();
            // inputKey.KeyName = keyName;
            // inputKey.keyState = keyState;
            //
            // HandleInput(inputKey);

        }

        private void HandleInput(InputKey input)
        {
            var state = _state.HandleInput(input, this);
            
            if (state != null)
            {
                _state.Exit(this);
                Destroy(_state.gameObject);
                _state = state;
                _state.transform.SetParent(this.transform);
                _state.Entry(this);
            }
        }
        
        public void OnNotify(object entity)
        {
            var inputKey = (InputKey)entity; 
            // Debug.Log("Update state machine with: " + inputKey);

            //Ask question: how could a state store a value and handle functionality at same time? 
           
        }
    }
}
