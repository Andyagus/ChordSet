using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AR_Keyboard.State;
using DG.Tweening;
using Enums;
using Normal.Realtime.Serialization;
using UnityEngine;


namespace AR_Keyboard
{
    public class ARKeyboard : MonoBehaviour
    {
        public ARKeyboardScreen ARScreen;
        public EKeyboardMode keyboardMode = EKeyboardMode.NO_MODE;
        private EKeyboardMode _prevMode = EKeyboardMode.NO_MODE;


        [Header("Events")]
        public Action<ARKeyboardState> onAmbientStateChanged;
        public Action<ARKeyboardState> onLearningModeStateChanged;

        [Header("Keyboard States")]
        public ARKeyboardState welcomeModeState;
        private ARKeyboardState _welcomeModeState;
        private ARKeyboardState _ambientModeState;
        public ARKeyboardState ambientModeState;
        [SerializeField] private bool learningModeActive;
        private ARKeyboardState _learningModeState;
        public ARKeyboardState learningModeState;

        [Header("Collections")]
        public List<Key> keys;
        public List<ARModifierKey> modifierKeys;
        public List<ARPrimaryKey> primaryKeys;
        public Dictionary<string, ARPrimaryKey> primaryKeyDictionary; 
        public Dictionary<string, ARModifierKey> modifierKeyDictionary;
        
        public enum EKeyboardMode
        {
            NO_MODE,
            WELCOME_MODE,
            AMBIENT_MODE
        }

        
        private void Awake()
        {
            InitializeCollections();
            keyboardMode = EKeyboardMode.AMBIENT_MODE;
        }
        
        private void InitializeCollections()
        {
            keys = GetComponentsInChildren<Key>().ToList();
            modifierKeys = GetComponentsInChildren<ARModifierKey>().ToList();
            primaryKeys = GetComponentsInChildren<ARPrimaryKey>().ToList();

            
            primaryKeyDictionary = new Dictionary<string, ARPrimaryKey>();
            modifierKeyDictionary = new Dictionary<string, ARModifierKey>();

            foreach (var primaryKey in primaryKeys)
            {
                if (!primaryKeyDictionary.ContainsKey(primaryKey.KeyName))
                {
                    primaryKeyDictionary.Add(primaryKey.KeyName, primaryKey);
                }
            }

            foreach (var modifierKey in modifierKeys)
            {
                
                if (!modifierKeyDictionary.ContainsKey(modifierKey.KeyName))
                {
                    modifierKeyDictionary.Add(modifierKey.KeyName, modifierKey);
                }
            }
        }
        public void OnKeyDictionaryReceived(RealtimeDictionary<KeySyncModel> dict)
        {
            
            foreach (var kvp in dict)
            {
                var keyName = kvp.Value.keyName;
                var keyState = kvp.Value.keyState;

                if (primaryKeyDictionary.ContainsKey(keyName))
                {
                    if (primaryKeyDictionary[keyName].keyPressed == EKeyState.KEY_UNPRESSED)
                    {
                        if (keyState == EKeyState.KEY_PRESSED)
                        {
                            primaryKeyDictionary[keyName].keyPressed = keyState;
                            HandleInput(primaryKeyDictionary[keyName]);
                        }
                    }

                    if (primaryKeyDictionary[keyName].keyPressed == EKeyState.KEY_PRESSED)
                    {
                        if (keyState == EKeyState.KEY_UNPRESSED)
                        {
                            primaryKeyDictionary[keyName].keyPressed = keyState;
                            HandleInput(primaryKeyDictionary[keyName]);
                        }
                    }
                }
                
                if (modifierKeyDictionary.ContainsKey(keyName))
                {
                    
                    if (modifierKeyDictionary[keyName].keyPressed == EKeyState.KEY_UNPRESSED)
                    {
                        if (keyState == EKeyState.KEY_PRESSED)
                        {
                            modifierKeyDictionary[keyName].keyPressed = keyState;
                            HandleInput(modifierKeyDictionary[keyName]);
                        }
                    }
                    
                    if (modifierKeyDictionary[keyName].keyPressed == EKeyState.KEY_PRESSED)
                    {
                        if (keyState == EKeyState.KEY_UNPRESSED)
                        {
                            modifierKeyDictionary[keyName].keyPressed = keyState;
                            HandleInput(modifierKeyDictionary[keyName]);
                        }
                    }

                }
            }
        }
        
        private void Start()
        {
            DOTween.SetTweensCapacity(500, 125);
        }
        
        private void Update()
        {
            if ( keyboardMode != _prevMode)
            {
                switch (keyboardMode)
                {
                    case EKeyboardMode.NO_MODE:
                        break;
                    case EKeyboardMode.WELCOME_MODE:
                        InstantiateWelcomeMode();
                        break;
                    case EKeyboardMode.AMBIENT_MODE:
                        InstantiateAmbientMode();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                _prevMode = keyboardMode;
            }
        }

        private void InstantiateWelcomeMode()
        {
            var state = Instantiate(welcomeModeState);
            _welcomeModeState = state;
            _welcomeModeState.Entry(this);
        }

        private void InstantiateAmbientMode()
        {
            var state = Instantiate(ambientModeState, this.transform, true);
            _ambientModeState = state; 
            _ambientModeState.Entry(this);
        }


        private void HandleInput(Key key)
        {
            switch (keyboardMode)
            {
                case EKeyboardMode.NO_MODE:
                    break;
                case EKeyboardMode.WELCOME_MODE:
                    WelcomeModeHandleInput(key);
                    break;
                case EKeyboardMode.AMBIENT_MODE:
                    AmbientModeHandleInput(key);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }


        private void WelcomeModeHandleInput(Key key)
        {
            //TODO lock until welcome mode animation is complete
            if (key.KeyName == "space")
            {
                keyboardMode = EKeyboardMode.AMBIENT_MODE;
            }
        }

        private void AmbientModeHandleInput(Key key)
        {
            var state = _ambientModeState.HandleInput(key, this);
            if (state != null)
            {
                Destroy(_ambientModeState);
                _ambientModeState = state;
                _ambientModeState.Entry(this);
            }

            if (learningModeActive)
            {
                state = _learningModeState.HandleInput(key, this);
                if (state != null)
                {
                    _learningModeState.Exit(this);
                    Destroy(_learningModeState);
                    _learningModeState = state;
                    _learningModeState.Entry(this);
                }
            }
            
            if (key.KeyName == "back-quote" && key.keyPressed == EKeyState.KEY_PRESSED)
            {

                var dotState = key.GetComponentInChildren<DotState>();
                
                if (!learningModeActive)
                {
                    _learningModeState = Instantiate(learningModeState);       
                    _learningModeState.Entry(this);
                    learningModeActive = true;
                    dotState.dotState = DotState.EDotState.ACTIVE;
                }else if (learningModeActive)
                {
                    _learningModeState.Exit(this);
                    Destroy(_learningModeState);
                    learningModeActive = false;
                    dotState.dotState = DotState.EDotState.INACTIVE;
                }
            }
        }

        private IEnumerator AmbientStateChangeCoroutine()
        {
            //TODO review this portion, maybe make coroutine not time based, and shortcut returned based.
            //Delaying so that shortcuts are instantiated before calling event
            yield return new WaitForSeconds(0.4f);
            onAmbientStateChanged(_ambientModeState);
        }
    }
}

