using Scenes._1Desktop.Scripts;
using Scenes._3MobileAR.Scripts.Keys.Key_States;
using TMPro;
using UnityEngine;

namespace Scenes._3MobileAR.Scripts.Keys
{
    /// <summary>
    /// Base class for all keys on the AR Keyboard
    /// </summary>
    public class Key : MonoBehaviour
    {
        public string KeyName;
        public TextMeshProUGUI letterText;
        
        /// <summary>
        /// The state machines control the various visualization states of the key, 
        /// all can be controlled through the inspector.
        /// Primary Key implements more visual states including shortcut and tooltip.
        /// </summary>
    
        [Header("Parent Key States")]
        //TODO: Refactor - This state machine was originally defined in Desktop Scene Input, enum is not located with others here 
        //setting up states so they can be controlled in the inspector, and call appropriate method when changed. 
        public EKeyState keyPressed = EKeyState.KEY_UNPRESSED;
        private KeyPressedState _keyPressedState;
        private EKeyState _prevPressed = EKeyState.KEY_UNPRESSED;
    
        private KeyAvailabilityState _keyAvailabilityState;
        public KeyAvailabilityState.EKeyAvailability keyAvailability;
        private KeyAvailabilityState.EKeyAvailability _prevAvailability = KeyAvailabilityState.EKeyAvailability.NONE;
    
        private KeyOutlineState _keyOutlineState;
        public KeyOutlineState.EKeyOutline keyOutline = KeyOutlineState.EKeyOutline.NO_OUTLINE;
        private KeyOutlineState.EKeyOutline _prevOutline = KeyOutlineState.EKeyOutline.NO_OUTLINE;

        private KeyColorState _keyColorState;
        public KeyColorState.EKeyColorState keyColorState;
        private KeyColorState.EKeyColorState _previousKeyColorState = KeyColorState.EKeyColorState.BLACK;
    
        public virtual void Awake()
        {
            //accessing all of the state machines on the Key instance.
            _keyPressedState = GetComponent<KeyPressedState>();
            _keyOutlineState = GetComponent<KeyOutlineState>();
            _keyAvailabilityState = GetComponent<KeyAvailabilityState>();
            _keyColorState = GetComponent<KeyColorState>();
        }

        public virtual void Update()
        {
            //When the state changes, call SetState Method. 
            //TODO: Put the set state method on a base class.
            if (_prevPressed != keyPressed)
            {
                _keyPressedState.SetPressedState(keyPressed, this);
                _prevPressed = keyPressed;
            }

            if (keyOutline != _prevOutline)
            {
                _keyOutlineState.SetOutlineState(keyOutline);
                _prevOutline = keyOutline;
            }

            if (keyAvailability != _prevAvailability)
            {
                _keyAvailabilityState.SetKeyAvailabilityState(keyAvailability);
                _prevAvailability = keyAvailability;
            }


            if (keyColorState != _previousKeyColorState)
            {
                _keyColorState.SetKeyColorState(keyColorState, this);
                _previousKeyColorState = keyColorState;
            }
        
            //Setting the key color to change when key pressed changes.
            //TODO: Too tightly coupled 
            if (keyPressed == EKeyState.KEY_PRESSED)
            {
                keyColorState = KeyColorState.EKeyColorState.WHITE;
                if (keyColorState != _previousKeyColorState)
                {
                    _keyColorState.SetKeyColorState(keyColorState, this);
                    _previousKeyColorState = keyColorState;
                }
            
            }else if (keyPressed == EKeyState.KEY_UNPRESSED)
            {
                keyColorState = KeyColorState.EKeyColorState.BLACK;
            
                if (keyColorState != _previousKeyColorState)
                {
                    _keyColorState.SetKeyColorState(keyColorState, this);
                    _previousKeyColorState = keyColorState;
                }
            
            }
        }
    
        //Brings back the key to original state.
        public virtual void ResetAllState()
        {
            keyOutline = KeyOutlineState.EKeyOutline.NO_OUTLINE;
            keyAvailability = KeyAvailabilityState.EKeyAvailability.AVAILABLE;
            keyColorState = KeyColorState.EKeyColorState.BLACK;
        }
    }
}
