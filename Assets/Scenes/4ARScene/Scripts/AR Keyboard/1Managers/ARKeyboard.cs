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
        
        //learning mode state 
        private ARKeyboardState _learningModeState;
        public ARKeyboardState learningModeWelcome;
        public ARKeyboardState undoShortcutState;
        
        //welcome mode state
        public ARKeyboardState welcomeModeState;
        
        
        //screen 
        public ARKeyboardScreen ARScreen;

        public List<Key> keys;
        public List<ARModifierKey> modifierKeys;
        public List<ARPrimaryKey> primaryKeys;
        private Dictionary<string, ARPrimaryKey> _primaryKeyDictionary; 
        private Dictionary<string, ARModifierKey> _modifierKeyDictionary;
        
        private KeySyncDictionary _keySyncDictionary;

        public enum EKeyboardMode
        {
            NO_MODE,
            WELCOME_MODE,
            AMBIENT_MODE,
            LEARNING_MODE
        }

        public EKeyboardMode keyboardMode = EKeyboardMode.NO_MODE;
        private EKeyboardMode _prevMode = EKeyboardMode.NO_MODE;

        // public Action<bool> onKeyboardWelcomeModeStateChanged;

        
        
        private void Awake()
        {
            keys = GetComponentsInChildren<Key>().ToList();
            modifierKeys = GetComponentsInChildren<ARModifierKey>().ToList();
            primaryKeys = GetComponentsInChildren<ARPrimaryKey>().ToList();
            keyboardMode = EKeyboardMode.AMBIENT_MODE;

            InitializeDictionary();
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
        
        private void Update()
        {
            if (keyboardMode != _prevMode)
            {
                switch (keyboardMode)
                {
                    case EKeyboardMode.WELCOME_MODE:
                        WelcomeMode();
                        break;
                    case EKeyboardMode.AMBIENT_MODE:
                        AmbientMode();
                        break;
                    case EKeyboardMode.LEARNING_MODE:
                        LearningMode();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                _prevMode = keyboardMode;
            }
        }

        private void WelcomeMode()
        {
            welcomeModeState = Instantiate(welcomeModeState);
            welcomeModeState.Entry(this);
        }

        private void AmbientMode()
        {
            _ambientModeState = Instantiate(typingState, this.transform, true);
            _ambientModeState.Entry(this);
        }

        private void LearningMode()
        {
            _learningModeState = Instantiate(learningModeWelcome, this.transform, true);
            _learningModeState.Entry(this);
        }
        
        
        private void InitializeDictionary()
        {
            _primaryKeyDictionary = new Dictionary<string, ARPrimaryKey>();
            _modifierKeyDictionary = new Dictionary<string, ARModifierKey>();

            foreach (var primaryKey in primaryKeys)
            {
                if (!_primaryKeyDictionary.ContainsKey(primaryKey.KeyName))
                {
                    _primaryKeyDictionary.Add(primaryKey.KeyName, primaryKey);
                }
            }

            foreach (var modifierKey in modifierKeys)
            {
                
                if (!_modifierKeyDictionary.ContainsKey(modifierKey.KeyName))
                {
                    _modifierKeyDictionary.Add(modifierKey.KeyName, modifierKey);
                }
            }
        }

       
        
        public void OnKeyDictionaryReceived(RealtimeDictionary<KeySyncModel> dict)
        {
            
            foreach (var kvp in dict)
            {
                var keyName = kvp.Value.keyName;
                var keyState = kvp.Value.keyState;

                if (_primaryKeyDictionary.ContainsKey(keyName))
                {
                    if (_primaryKeyDictionary[keyName].keyPressed == EKeyState.KEY_UNPRESSED)
                    {
                        if (keyState == EKeyState.KEY_PRESSED)
                        {
                            _primaryKeyDictionary[keyName].keyPressed = keyState;
                        }
                        
                    }
                    HandleInput(_primaryKeyDictionary[keyName]);
                }
                
                if (_modifierKeyDictionary.ContainsKey(keyName))
                {
                    if(_modifierKeyDictionary[keyName].keyPressed != keyState)
                    {
                        _modifierKeyDictionary[keyName].keyPressed = keyState;
                    }
                    HandleInput(_modifierKeyDictionary[keyName]);
                }
            }
        }

        private void HandleInput(Key key)
        {
            switch (keyboardMode)
            {
                case EKeyboardMode.NO_MODE:
                    break;
                case EKeyboardMode.WELCOME_MODE:
                    HandleInputWelcomeMode(key);
                    break;
                case EKeyboardMode.AMBIENT_MODE:
                    AmbientModeHandleInput(key);
                    break;
                case EKeyboardMode.LEARNING_MODE:
                    LearningModeHandleInput(key);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        private void HandleInputWelcomeMode(Key key)
        {
            var state = welcomeModeState.HandleInput(key, this);
            
            //instead just wait for the space to be pressed here..
            if (state.stateName == "Welcome Mode Out")
            {
                keyboardMode = EKeyboardMode.AMBIENT_MODE;
            }
        }

        private void LearningModeHandleInput(Key key)
        {
            
            if (key.KeyName == "Q" && key.keyPressed == EKeyState.KEY_PRESSED)
            {
                _learningModeState.Exit(this);

                var screenSpaceUI = GameObject.Find("ScreenSpaceUI");
                if (screenSpaceUI != null)
                {
                    Destroy(screenSpaceUI.gameObject);
                }
                keyboardMode = EKeyboardMode.AMBIENT_MODE;
            }

            var state = _learningModeState.HandleInput(key, this);
            if (state != null)
            {
                // _learningModeState.Exit(this);
                Destroy(_learningModeState.gameObject);
                _learningModeState = state;
                _learningModeState.transform.SetParent(this.transform);
                _learningModeState.Entry(this);
            }
            
        }

        private void AmbientModeHandleInput(Key key)
        {

            if (key.KeyName == "back-quote" && key.keyPressed == EKeyState.KEY_PRESSED)
            {
                keyboardMode = EKeyboardMode.LEARNING_MODE;
            }
            
            var state = _ambientModeState.HandleInput(key, this);
            //         
            if (state != null)
            {
                _ambientModeState.Exit(this);
                Destroy(_ambientModeState.gameObject);
                _ambientModeState = state;
                _ambientModeState.transform.SetParent(this.transform);
                _ambientModeState.Entry(this);
                StartCoroutine(AmbientStateChangeCoroutine());
            }
        }
        

        private IEnumerator AmbientStateChangeCoroutine()
        {
            //better to wait if returned shortcut t
            yield return new WaitForSeconds(0.4f);
            //this is for subscribers of the shortcut;;;;;take out of coroutine--
            onAmbientStateChanged(_ambientModeState);
        }
    }
}

