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
    
    [Header("UI Shortcut State")] 
    private UIShortcutState _uiShortcutState;
    public UIShortcutState.EuiShortcutState uiShortcutState = UIShortcutState.EuiShortcutState.NONE;
    private UIShortcutState.EuiShortcutState _prevUiShortcutState = UIShortcutState.EuiShortcutState.NONE;

   
    public virtual void Awake()
    {
        _keyPressedState = GetComponent<KeyPressedState>();
        _keyOutlineState = GetComponent<KeyOutlineState>();
        _keyAvailabilityState = GetComponent<KeyAvailabilityState>();
        _uiShortcutState = GetComponent<UIShortcutState>();

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

        if (uiShortcutState != _prevUiShortcutState)
        {
            _uiShortcutState.SetUIState(uiShortcutState, this);
        }
      
    }
}
