using System;
using System.Collections.Generic;
using System.Linq;
using AR_Keyboard.State;
using Desktop;
using Enums;
using Interfaces;
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
            // var inputKey1 = new GameObject().AddComponent<InputKey>();
            // inputKey1.KeyName = "A";
            // inputKey1.keyState = EKeyState.KEY_PRESSED;
            //
            // var inputKey2 = new GameObject().AddComponent<InputKey>();
            // inputKey2.KeyName = "S";
            // inputKey2.keyState = EKeyState.KEY_PRESSED;
            //
            // var inputKey3 = new GameObject().AddComponent<InputKey>();
            // inputKey3.KeyName = "D";
            // inputKey3.keyState = EKeyState.KEY_PRESSED;
            //
            // var inputKey4 = new GameObject().AddComponent<InputKey>();
            // inputKey4.KeyName = "A";
            // inputKey4.keyState = EKeyState.KEY_UNPRESSED;
            //

            
            // var localDict = new Dictionary<int, InputKey>()
            // {
            //     {1, inputKey1},
            //     {2, inputKey2},
            //     {3, inputKey3},
            //     {4, inputKey4}
            //
            // };

            // foreach (var kvp in localDict)
            // {
            //     HandleInput(kvp.Value);    
            // }

        }


        public void OnKeyDictionaryReceived(Dictionary<int, InputKey> dict)
        {
            foreach (var kvp in dict)
            {
                HandleInput(kvp.Value);    
            }
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
                Debug.Log("New State received");
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
