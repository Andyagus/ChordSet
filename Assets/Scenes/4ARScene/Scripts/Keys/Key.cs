using Enums;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    public string KeyName;
    public TextMeshProUGUI letterText;
    public TextMeshProUGUI secondaryText;
    public Image letterImage;
    [SerializeField] private KeyOutline keyOutlineObject;
    
    [Header("Parent Key States")]
    public EKeyState keyPressed = EKeyState.KEY_UNPRESSED;
    private EKeyState _prevPressed = EKeyState.KEY_UNPRESSED;
    private KeyPressedState _keyPressedState;
    
    private KeyAvailabilityState _keyAvailabilityState;
    public KeyAvailabilityState.EKeyAvailability keyAvailability;
    private KeyAvailabilityState.EKeyAvailability _prevAvailability = KeyAvailabilityState.EKeyAvailability.NONE;
    private KeyOutlineState _keyOutlineState;
    public KeyOutlineState.EKeyOutline keyOutline = KeyOutlineState.EKeyOutline.NO_OUTLINE;
    private KeyOutlineState.EKeyOutline _prevOutline = KeyOutlineState.EKeyOutline.NO_OUTLINE;

    [Header("Key Color State")] 
    public KeyColorState.EKeyColorState keyColorState;
    private KeyColorState.EKeyColorState _previousKeyColorState = KeyColorState.EKeyColorState.BLACK;
    private KeyColorState _keyColorState;
    
    public virtual void Awake()
    {
        _keyPressedState = GetComponent<KeyPressedState>();
        _keyOutlineState = GetComponent<KeyOutlineState>();
        _keyAvailabilityState = GetComponent<KeyAvailabilityState>();
        _keyColorState = GetComponent<KeyColorState>();
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


        if (keyColorState != _previousKeyColorState)
        {
            _keyColorState.SetKeyColorState(keyColorState, this);
            _previousKeyColorState = keyColorState;
        }
        
        //Setting the key color to change when key pressed changes 
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
}
