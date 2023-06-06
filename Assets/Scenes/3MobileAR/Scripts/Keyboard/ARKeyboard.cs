using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Normal.Realtime.Serialization;
using Scenes._1Desktop.Scripts;
using Scenes._3MobileAR.Scripts.Keys;
using Scenes._3MobileAR.Scripts.Keys.Modifier_Key;
using Scenes._3MobileAR.Scripts.Keys.Primary_Key;
using Scenes._3MobileAR.Scripts.Screen_Space_UI._1Main;
using Scenes._3MobileAR.Scripts.State___Welcome_Mode;
using UnityEngine;

namespace Scenes._3MobileAR.Scripts.Keyboard
{
    /// <summary>
    /// ARKeyboard handles various state machine of the keyboard and also
    /// delegates Normcore input to appropriate State.HandleInput()
    /// </summary>
    public class ARKeyboard : MonoBehaviour
    {
        
        //Keyboard state machine
        public enum EKeyboardMode
        {
            NO_MODE,
            WELCOME_MODE,
            AMBIENT_MODE,
        }

        public EKeyboardMode keyboardMode = EKeyboardMode.NO_MODE;
        private EKeyboardMode _prevMode = EKeyboardMode.NO_MODE;
        
        //Sub-State machines
        private ARKeyboardState _ambientModeState;
        public ARKeyboardState ambientModeInitialState;
        public Action<ARKeyboardState> onAmbientStateChanged;

        private ARKeyboardState _welcomeModeState;
        public ARKeyboardState welcomeModeInitialState;

        //Shortcut List 
        private ShortcutList _shortcutList;
        private ShortcutListInput _shortcutListInput;
        private bool _shortcutListActive;
        
        //Key Access 
        public List<Key> keys;
        public List<ARModifierKey> modifierKeys;
        public List<ARPrimaryKey> primaryKeys;
        public Dictionary<string, ARPrimaryKey> primaryKeyDictionary; 
        public Dictionary<string, ARModifierKey> modifierKeyDictionary;
        
        private void Awake()
        {
            
            //TODO: Look into - Having an odd issue with DOTween where set capacity needs to be automatically set. 
            //Attempting to set DOTween to 500 Tweens 50 Sequences before moving to welcome mode.
            //It is being automatically set so not effecting performance, but DOTween is logging an error.
            //Tried creating a seperate DOTween Manager Class, which clears all tweens, but not issue.
            //Documentation on Tween Capacity: http://dotween.demigiant.com/documentation.php?api=SetTweensCapacity 
            //limited as far as my current issue. Reached out to Demigiant on issue and will update accordingly. 
            DOTween.SetTweensCapacity(500, 50);
            keyboardMode = EKeyboardMode.AMBIENT_MODE;
            
            keys = GetComponentsInChildren<Key>().ToList();
            modifierKeys = GetComponentsInChildren<ARModifierKey>().ToList();
            primaryKeys = GetComponentsInChildren<ARPrimaryKey>().ToList();
            
            //TODO: Clean up how this is accessed within the awake method, and GO.Find
            _shortcutList = GameObject.Find("Screen Space UI").GetComponentInChildren<ShortcutList>(true);
            _shortcutListInput = _shortcutList.gameObject.GetComponent<ShortcutListInput>();

            InitializeDictionary();
        }
        
        //TODO: Work with both primary key and modifier keys at same time. 
        private void InitializeDictionary()
        {
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
        
        /// <summary>
        /// If keyboard mode changes, call the instantiation method on the new mode.
        /// </summary>
        private void Update()
        {
            if (keyboardMode != _prevMode)
            {
                switch (keyboardMode)
                {
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

        //TODO: Refactor - Welcome mode does not need to be a state.
        /// <summary>
        /// Initially welcome mode accepted input and transitioned between various phases,
        /// so I set it up as a concurrent state machine.
        /// However I simplified the design of the screen so now it switches
        /// to ambient mode on a callback and is not required to be a state.
        /// Not switching around the architecture yet, may be part of larger
        /// refactor.  And could add flexibility if want to expand the welcome mode
        /// in the future.
        /// </summary>
        private void InstantiateWelcomeMode()
        {
            _welcomeModeState = Instantiate(welcomeModeInitialState);
            var welcomeModeIntro = _welcomeModeState.GetComponent<WelcomeModeIntro>();
            welcomeModeIntro.onWelcomeSequenceComplete += OnWelcomeSequenceComplete;
            _welcomeModeState.Entry(this);
        }

        private void OnWelcomeSequenceComplete()
        {
            keyboardMode = EKeyboardMode.AMBIENT_MODE;
            Destroy(_welcomeModeState.gameObject);
        }
        
        private void InstantiateAmbientMode()
        {
            _ambientModeState = Instantiate(ambientModeInitialState, this.transform, true);
            _ambientModeState.Entry(this);
        }
        
        /// <summary>
        /// OnKeyDictionaryReceived, takes the dictionary from Normcore,
        /// checks if any values have changed.  If they did, pass the
        /// specific key to HandleInput.  This will send the key to the
        /// current state on the state machine. 
        /// </summary>
        public void OnKeyDictionaryReceived(RealtimeDictionary<KeySyncModel> dict)
        {
            foreach (var kvp in dict)
            {
                var keyName = kvp.Value.keyName;
                var keyState = kvp.Value.keyState;

                if (primaryKeyDictionary.ContainsKey(keyName))
                {
                    //if the key was unpressed and now is pressed
                    if (primaryKeyDictionary[keyName].keyPressed == EKeyState.KEY_UNPRESSED)
                    {
                        if (keyState == EKeyState.KEY_PRESSED)
                        {
                            primaryKeyDictionary[keyName].keyPressed = keyState;
                            HandleInput(primaryKeyDictionary[keyName]);
                        }
                    }

                    //if the key was pressed and now is unpressed
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

        /// <summary>
        /// This handle input can pass the key to multiple different states depending on the mode of the keyboard.
        /// This is not required at the current moment, but if wanted to add states in the future could be helpful. 
        /// </summary>
        private void HandleInput(Key key)
        {
            switch (keyboardMode)
            {
                case EKeyboardMode.NO_MODE:
                    break;
                case EKeyboardMode.WELCOME_MODE:
                    break;
                case EKeyboardMode.AMBIENT_MODE:
                    AmbientModeHandleInput(key);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void AmbientModeHandleInput(Key key)
        {
            var state = _ambientModeState.HandleInput(key, this);
            
            if (state != null)
            {
                _ambientModeState.Exit(this);
                Destroy(_ambientModeState.gameObject);
                _ambientModeState = state;
                _ambientModeState.transform.SetParent(this.transform);
                _ambientModeState.Entry(this);
                StartCoroutine(AmbientStateChangeCoroutine());
            }
            
            //Activate and Deactivate shortcut list for quickly finding required shortcut
            //TODO: Consider other ways to architect the UI List (own state machine?)
            if (key.KeyName == "back-quote" && key.keyPressed == EKeyState.KEY_PRESSED)
            {
                ToggleShortcutList();
            }

            if (_shortcutListActive)
            {
                if (key.KeyName != "back-quote")
                {
                    //Sending keyboard input to search or navigate through list of shortcuts. 
                    _shortcutListInput.HandleInput(key);
                }
            }
            
        }

        private void ToggleShortcutList()
        {
            switch (_shortcutList.gameObject.activeSelf)
            {
                case true:
                    _shortcutListActive = false;
                    _shortcutList.gameObject.SetActive(false);
                    break;
                case false:
                    _shortcutListActive = true;
                    _shortcutList.gameObject.SetActive(true);
                    break;
            }
        }

        /// <summary>
        /// TODO: Would like to remove this coroutine, but requires larger app refactor
        /// This coroutine, allows other classes, to subscribe to the Shortcuts
        /// that are made available when AmbientMode State Changes.
        /// </summary>
        private IEnumerator AmbientStateChangeCoroutine()
        {
            yield return new WaitForSeconds(0.4f);
            onAmbientStateChanged(_ambientModeState);
        }
    }
}

