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

        //ambient mode state
        private ARKeyboardState _ambientModeState;
        public ARKeyboardState typingState;
        public Action<ARKeyboardState> onStateChanged;

        //decision bool
        private bool _ambientModeActive = true;
        private bool _learningModeActive = false;
        // private bool _ambientWasActive = false;

        //learning mode state 
        private ARKeyboardState _learningModeState;
        public ARKeyboardState undoShortcutState;
        
        
        [NonSerialized] public List<ARPrimaryKey> primaryKeys;
        [NonSerialized] public List<ARModifierKey> modifierKeys;

        private KeySyncDictionary _keySyncDictionary;

        private void Awake()
        {
            primaryKeys = GetComponentsInChildren<ARPrimaryKey>().ToList();
            modifierKeys = GetComponentsInChildren<ARModifierKey>().ToList();

            InstantiateModes();
     
        }

        private void InstantiateModes()
        {
            _ambientModeState = Instantiate(typingState, this.transform, true);
            _ambientModeState.Entry(this);

            _learningModeState = Instantiate(undoShortcutState, this.transform, true);

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
            //setting values of 'physical' keys
            foreach (var primaryKey in primaryKeys)
            {
                if (inputKeyName == primaryKey.KeyName)
                {
                    if (primaryKey.keyPressedState == EKeyState.KEY_UNPRESSED)
                    {
                        if (inputKeyState == EKeyState.KEY_PRESSED)
                        {
                            primaryKey.SetPressedState(EKeyState.KEY_PRESSED);
                            HandleInput(inputKeyName, inputKeyState, primaryKey);
                        }
                    }
                    if (primaryKey.keyPressedState == EKeyState.KEY_PRESSED)
                    {
                        if (inputKeyState == EKeyState.KEY_UNPRESSED)
                        {
                            primaryKey.SetPressedState(EKeyState.KEY_UNPRESSED);
                            HandleInput(inputKeyName, inputKeyState, primaryKey);

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
                            HandleInput(inputKeyName, inputKeyState, modifierKey);
                        }
                    }
                    if (modifierKey.keyPressedState == EKeyState.KEY_PRESSED)
                    {
                        if (inputKeyState == EKeyState.KEY_UNPRESSED)
                        {
                            modifierKey.SetPressedState(EKeyState.KEY_UNPRESSED);
                            HandleInput(inputKeyName, inputKeyState, modifierKey);

                        }
                    }
                }    
            }
            
        }
        
        private void HandleInput(string keyName, EKeyState keyState, Key physicalKey)
        {
            if (keyName == "F5")
            {
                if (physicalKey.keyPressedState == EKeyState.KEY_PRESSED)
                {
                    _ambientModeActive = false;
                    Debug.Log(_ambientModeActive);
                }
            }

            if (keyName == "Escape")
            {
                if (physicalKey.keyPressedState == EKeyState.KEY_PRESSED)
                {
                    _ambientModeActive = true;
                }
            }
            
            if (_ambientModeActive)
            {
                if (_learningModeActive)
                {
                    _ambientModeState.Entry(this);
                    _learningModeActive = false;
                }
                
                var state = _ambientModeState.HandleInput(keyName, keyState, this);
                
                if (state != null)
                {
                    _ambientModeState.Exit(this);
                    Destroy(_ambientModeState.gameObject);
                    _ambientModeState = state;
                    _ambientModeState.transform.SetParent(this.transform);
                    _ambientModeState.Entry(this);
                    onStateChanged(_ambientModeState);
                }
            }
            else
            {
                if (_learningModeActive == false)
                {
                    foreach (var primaryKey in primaryKeys)
                    {
                        primaryKey.SetPrimaryKeyState(ARPrimaryKey.EPrimaryKeyState.DEFAULT);
                    }
                    foreach (var modifierKey in modifierKeys)
                    {
                        modifierKey.ChangeLocalState(ARModifierKey.EModifierKeyState.DEFAULT);
                    }
                    
                    _learningModeState.Entry(this);
                    _learningModeActive = true;
                }
                //will need additional bools for switching back and fourth 
                // _learningModeState.Entry(this);

                var state = _learningModeState.HandleInput(keyName, keyState, this);
                if (state != null)
                {
                    _learningModeState.Exit(this);
                    Destroy(_learningModeState.gameObject);
                    _learningModeState = state;
                    _learningModeState.transform.SetParent(this.transform);
                    _learningModeState.Entry(this);

                }
            }
        }
        
        }
}

