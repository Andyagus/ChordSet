using System;
using AR_Keyboard;
using AR_Keyboard.State;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ARKeyboardScreen : MonoBehaviour
{

    private ARKeyboard _arKeyboard;
    
    [Header("State")] 
    public BackgroundPanelState.EBackgroundPanel backgroundPanelState;
    private BackgroundPanelState.EBackgroundPanel _previousBackgroundPanel = BackgroundPanelState.EBackgroundPanel.INACTIVE;
    private BackgroundPanelState _backgroundPanelState;

    public PositioningAreaState.EPositioningArea positioningAreaState;
    private PositioningAreaState.EPositioningArea _previousPositioningArea;
    private PositioningAreaState _positioningArea;


    public VideoState.EVideoState videoState;
    private VideoState.EVideoState _previousVideoState;
    private VideoState _videoState;


    public ShortcutSuccessPanelState.EShortcutSuccessPopUp shortcutSuccessPanelState;
    private ShortcutSuccessPanelState.EShortcutSuccessPopUp _previousShortcutSuccessPanelState;
    private ShortcutSuccessPanelState _shortcutSuccessPanelState;
    
    private void Awake()
    {
        _arKeyboard = FindObjectOfType<ARKeyboard>();
        _arKeyboard.onAmbientStateChanged += OnAmbientStateChanged;

        _backgroundPanelState = GetComponent<BackgroundPanelState>();
        _positioningArea = GetComponent<PositioningAreaState>();
        _videoState = GetComponent<VideoState>();
        _shortcutSuccessPanelState = GetComponent<ShortcutSuccessPanelState>();
    }

    private void OnAmbientStateChanged(ARKeyboardState obj)
    {
        foreach (var primaryKey in _arKeyboard.primaryKeys)
        {
            if (primaryKey.currentShortcut != null)
            {
                primaryKey.currentShortcut.onShortcutExecuted += OnShortcutExecuted;
            }
        }
    }

    private void OnShortcutExecuted(Shortcut shortcut)
    {
        _shortcutSuccessPanelState
            .SetShortcutSuccessPopUpState(ShortcutSuccessPanelState.EShortcutSuccessPopUp.AVAILABLE, 
                shortcut.GetComponentInChildren<Image>().sprite, shortcut.shortcutName);
    }


    private void Update()
    {
        if (backgroundPanelState != _previousBackgroundPanel)
        {
            _backgroundPanelState.SetBackgroundPanel(backgroundPanelState);
            _previousBackgroundPanel = backgroundPanelState;
        }

        if (positioningAreaState != _previousPositioningArea)
        {
            _positioningArea.SetPositioningArea(positioningAreaState);
            _previousPositioningArea = positioningAreaState;
        }

        if (videoState != _previousVideoState)
        {
            _videoState.SetVideoState(videoState);
            _previousVideoState = videoState;
        }
    }

    // public enum EScreenState
    // {
    //     INACTIVE,
    //     ACTIVE
    // }
    //
    // public EScreenState screenState;
    //
    // public void ChangeScreenState(EScreenState state)
    // {
    //     switch (state)
    //     {
    //         case EScreenState.ACTIVE:
    //             ActivateScreen();
    //             break;
    //         case EScreenState.INACTIVE:
    //             DeactivateScreen();
    //             break;
    //     }
    // }
    //
    // private void ActivateScreen()
    // {
    //     screenState = EScreenState.ACTIVE;
    //     var rawImage = GetComponentInChildren<RawImage>();
    //     rawImage.DOFade(1, 3f);
    // }
    //
    // private void DeactivateScreen()
    // {
    //     screenState = EScreenState.INACTIVE;
    //     var rawImage = GetComponentInChildren<RawImage>();
    //     rawImage.DOFade(0, 3f);
    // }
}
