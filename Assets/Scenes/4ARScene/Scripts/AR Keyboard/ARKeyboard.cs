using System;
using System.Collections;
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
        public Action<ARKeyboardState> onAmbientStateChanged;

        //decision bool
        private bool _ambientModeActive = true;
        private bool _learningModeActive = false;
        // private bool _ambientWasActive = false;
        
        
        //learning mode state 
        private ARKeyboardState _learningModeState;
        public ARKeyboardState learningModeWelcome;
        public ARKeyboardState undoShortcutState;
        
        //screen 
        public ARKeyboardScreen ARScreen;

        public List<Key> keys;
        public List<ARModifierKey> modifierKeys;
        public List<ARPrimaryKey> primaryKeys;
        
        private KeySyncDictionary _keySyncDictionary;

        private void Awake()
        {

            keys = GetComponentsInChildren<Key>().ToList();
            modifierKeys = GetComponentsInChildren<ARModifierKey>().ToList();
            primaryKeys = GetComponentsInChildren<ARPrimaryKey>().ToList();
            

            InstantiateModes();
     
        }

        private void InstantiateModes()
        {
            _ambientModeState = Instantiate(typingState, this.transform, true);
            _ambientModeState.Entry(this);

            // _learningModeState = Instantiate(learningModeWelcome, this.transform, true);
            _learningModeState = Instantiate(learningModeWelcome, this.transform, true);

        }

        private void Start()
        {
            
            DOTween.SetTweensCapacity(500, 125);
            
            if (onAmbientStateChanged != null)
            {
                onAmbientStateChanged(_ambientModeState);
            }
            _keySyncDictionary = FindObjectOfType<KeySyncDictionary>();
        }
        
        public void OnKeyDictionaryReceived(RealtimeDictionary<KeySyncModel> dict)
        {
            //Debug.Log("dictionary count: " + dict.Count);
            foreach (var kvp in dict)
            {
                var keyName = kvp.Value.keyName;
                var keyState = kvp.Value.keyState;
                DelegateInput(keyName, keyState);
            }
        }
        
        
        private void DelegateInput(string inputKeyName, EKeyState inputKeyState)
        {

            foreach (var key in keys)
            {
                if (inputKeyName == key.KeyName)
                {
                    if (key.keyPressed == EKeyState.KEY_UNPRESSED)
                    {
                        if (inputKeyState == EKeyState.KEY_PRESSED)
                        {
                            key.keyPressed = EKeyState.KEY_PRESSED;
                            HandleInput(inputKeyName, inputKeyState, key);
                        }
                    }

                    if (key.keyPressed == EKeyState.KEY_PRESSED)
                    {
                        if (inputKeyState == EKeyState.KEY_UNPRESSED)
                        {
                            key.keyPressed = EKeyState.KEY_UNPRESSED;
                            HandleInput(inputKeyName, inputKeyState, key);

                        }
                    }
                }
            }
            
        }
            
          
        
        private void HandleInput(string keyName, EKeyState keyState, Key key)
        {
            // if (keyName == "F5")
            // {
            //     if (physicalKey.keyPressedState == EKeyState.KEY_PRESSED)
            //     {
            //         _ambientModeActive = false;
            //         Debug.Log(_ambientModeActive);
            //     }
            // }

            // if (keyName == "Escape")
            // {
            //     if (physicalKey.keyPressedState == EKeyState.KEY_PRESSED)
            //     {
            //         _ambientModeActive = true;
            //     }
            // }
            
            if (_ambientModeActive)
            {
                if (_learningModeActive)
                {
                    _ambientModeState.Entry(this);
                    _learningModeActive = false;
                }
                
                var state = _ambientModeState.HandleInput(key);
                
                if (state != null)
                {
                    _ambientModeState.Exit(this);
                    Destroy(_ambientModeState.gameObject);
                    _ambientModeState = state;
                    _ambientModeState.transform.SetParent(this.transform);
                    _ambientModeState.Entry(this);
                    //Coroutine//to fix.
                    StartCoroutine(AmbientStateChangeCoroutine());
                }
            }
            else
            {
                if (_learningModeActive == false)
                {
                    // foreach (var primaryKey in primaryKeys)
                    // {
                    //     // primaryKey.SetPrimaryKeyState(ARPrimaryKey.EPrimaryKeyState.DEFAULT);
                    // }
                    // foreach (var modifierKey in modifierKeys)
                    // {
                    //     // modifierKey.ChangeLocalState(ARModifierKey.EModifierKeyState.DEFAULT);
                    // }
                    
                    _learningModeState.Entry(this);
                    _learningModeActive = true;
                }
                //will need additional bools for switching back and fourth 
                // _learningModeState.Entry(this);

                var state = _learningModeState.HandleInput(key);
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

        private IEnumerator AmbientStateChangeCoroutine()
        {
            //better to wait if returned shortcut 
            yield return new WaitForSeconds(0.4f);
            onAmbientStateChanged(_ambientModeState);
        }
    }
}

