using System;
using System.Collections.Generic;
using System.Linq;
using AR_Keyboard.State;
using Desktop;
using Enums;
using Interfaces;
using Normcore;
using UnityEngine;

namespace AR_Keyboard
{
    public class ARKeyboard : MonoBehaviour, IObserver
    {
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
        

        public void OnKeyReceived(string keyName, EKeyState keyState)
        {
            var inputKey = new GameObject().AddComponent<InputKey>();
            inputKey.KeyName = keyName;
            inputKey.keyState = keyState;

            HandleInput(inputKey);

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
