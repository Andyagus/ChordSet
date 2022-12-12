using System;
using System.Collections;
using System.Collections.Generic;
using Enums;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{

    [Header("Inherited")]
    // public EKeyStatusState keyStatusState = EKeyStatusState.AMBIENT_INACTIVE;

    // public enum EKeyStatusState
    // {
    //     // AMBIENT_ACTIVE,
    //     // AMBIENT_INACTIVE
    //     // AVAILABLE,
    //     // UNAVAILABLE,
    //     // ANIMATION_PAUSE,
    //     // ANIMATION_PLAY,
    //     // TYPING_ON,
    //     // TYPING_OFF,
    //     // DEFAULT,
    //     // LEARNING_WELCOME,
    //     // LEARNING_SHOWCASE,
    //     // LEARNING_STATE_ENTRY,
    //     // LEARNING_AVAILABLE,
    //     // LEARNING_SELECTED,
    //     // LEARNING_HELPER,
    //     // LEARNING_ACTIVE_MENU_BUTTON,
    //     // LEARNING_STATE_ENTER_MODE
    // }
    
    // public EKeyState keyPressedState = EKeyState.KEY_UNPRESSED;
    
    [Header("Attributes")]
    public string KeyName;
    public KeyCode KeyCode;
    [SerializeField] public Image secondaryImage;
    [SerializeField] public Image additionalImage;
    [SerializeField] public TextMeshProUGUI secondaryText;
    
    
    [Tooltip("Key Pressed State")]
    private KeyPressedState _keyPressedState;
    public EKeyState keyPressed = EKeyState.KEY_UNPRESSED;
    private EKeyState _prevPressed = EKeyState.KEY_UNPRESSED;

    [Tooltip("Key Availability State")] 
    private KeyAvailabilityState _keyAvailabilityState;
    public KeyAvailabilityState.EKeyAvailability keyAvailability;
    private KeyAvailabilityState.EKeyAvailability _prevAvailability = KeyAvailabilityState.EKeyAvailability.AVAILABLE;
    
    [Tooltip("Key Outline State")]
    [SerializeField] private KeyOutline keyOutlineObject;
    private KeyOutlineState _keyOutlineState;
    public KeyOutlineState.EKeyOutline keyOutline = KeyOutlineState.EKeyOutline.NO_OUTLINE;
    private KeyOutlineState.EKeyOutline _prevOutline = KeyOutlineState.EKeyOutline.NO_OUTLINE;
    
   
    public virtual void Awake()
    {
        _keyPressedState = GetComponent<KeyPressedState>();
        _keyOutlineState = GetComponent<KeyOutlineState>();
        _keyAvailabilityState = GetComponent<KeyAvailabilityState>();
    }

    public virtual void Update()
    {
        if (_prevPressed != keyPressed)
        {
               _keyPressedState.SetPressedState(keyPressed, this);
               _prevPressed = keyPressed;
        }

        if (keyOutline != _prevOutline)
        {
            _keyOutlineState.SetOutlineState(keyOutline, keyOutlineObject);
            _prevOutline = keyOutline;
        }

        if (keyAvailability != _prevAvailability)
        {
            _keyAvailabilityState.SetKeyAvailability(keyAvailability, this);
            _prevAvailability = keyAvailability;
        }

      
    }
}
