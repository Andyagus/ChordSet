using System;
using System.Collections;
using System.Collections.Generic;
using AR_Keyboard;
using AR_Keyboard.State;
using DG.Tweening;
using Enums;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Video;

public class UndoShortcutState : ARKeyboardState
{


    private Image _positioningArea;

    [SerializeField] private ARKeyboardState selectAllShortcutState;
    //video
    [SerializeField] private GameObject videoPlayer;
    [SerializeField] private RenderTexture renderTexture;

    [SerializeField] private UndoShortcut undoShortcut;
    private Sequence _showcaseSequence;

    private bool _entryMode;

    private List<ARPrimaryKey> _primaryKeysForChanging;
    private List<ARModifierKey> _modifierKeysForChanging;

    [SerializeField] private GameObject screenspaceUI;

    private Image _fullscreenPanel;
    [SerializeField] private Sprite undoSprite;

    private bool _enterMode;

    private Transform _localCanvas;
    private ShortcutSuccessPanel _shortcutSuccessPanel;

    private bool _zPressed;
    private bool _cmdPressed;
    private bool _shortcutComplete;
    // [SerializeField] private GameObject primaryOutline;
    // [SerializeField] private GameObject o;
    
    //display those keys in highlight -
    public override void Entry(ARKeyboard keyboard)
    {
        _localCanvas = keyboard.ARScreen.gameObject.transform.Find("Canvas");
        _shortcutSuccessPanel = _localCanvas.GetComponentInChildren<ShortcutSuccessPanel>();

        
        _showcaseSequence = DOTween.Sequence();


        _showcaseSequence.AppendCallback(() =>
        {
            var positioningArea = keyboard.GetComponentInChildren<ScreenPositioningArea>();
            _positioningArea = positioningArea.GetComponentInChildren<Image>();

            _positioningArea.DOFade(0, 3f);
        });
        
        _showcaseSequence.AppendCallback(() =>
        {
            ResetKeys(keyboard);
        });
        _showcaseSequence.AppendInterval(3f);
        _showcaseSequence.AppendCallback(() =>
        {
            PlaceScreenSpaceUI();
        });

        _showcaseSequence.AppendInterval(3f);

        
        _showcaseSequence.AppendCallback(() =>
        {
            FadeOutKeysExpectShortcut(keyboard);
        });

        _showcaseSequence.AppendInterval(3f);

        _showcaseSequence.AppendCallback(() =>
        {
            ShowcaseImportantKeys(keyboard);
        });

        _showcaseSequence.AppendInterval(3f);


        _showcaseSequence.AppendCallback(() =>
        {
            ScreenFadeIn(keyboard);
        });
        
        _showcaseSequence.AppendCallback(() =>
        {
            DisplayVideoPlayer(keyboard);
        });
        
        _showcaseSequence.AppendCallback(() =>
        {
            videoPlayer.GetComponent<VideoPlayer>().Play();
        });
        
        // key follow
        _showcaseSequence.AppendCallback(() =>
        {
            KeyFollow(keyboard);
        });
        
        _showcaseSequence.AppendInterval(7f);
        
        _showcaseSequence.AppendCallback(() =>
        {
            ScreenFadeOut(keyboard);
        });
        
        _showcaseSequence.AppendCallback(() =>
        {
            DisplayKeyUIControls(keyboard);
        });
        
        _showcaseSequence.AppendCallback(() =>
        {
            HideVideoPlayer(keyboard);
        });
    }

    private void KeyFollow(ARKeyboard keyboard)
    {
        
        var localSequence = DOTween.Sequence();
        localSequence.Pause();
        localSequence.AppendInterval(1f);

        foreach (var modifierKey in keyboard.modifierKeys )
        {
            if (modifierKey.KeyName == "command-left")
            {
                localSequence.AppendCallback(() => modifierKey.keyPressed = EKeyState.KEY_PRESSED);
                // localSequence.AppendInterval(5f);
                // localSequence.AppendCallback(() => modifierKey.keyPressed = EKeyState.KEY_UNPRESSED);
            }
        }

        foreach (var primaryKey in keyboard.primaryKeys)
        {
            if (primaryKey.KeyName == "Z")
            {
                localSequence.AppendInterval(3f);
                localSequence.AppendCallback(() => primaryKey.keyPressed = EKeyState.KEY_PRESSED);
                localSequence.AppendInterval(1f);
                localSequence.AppendCallback(() => primaryKey.keyPressed = EKeyState.KEY_UNPRESSED);
                localSequence.AppendInterval(0.5f);
                localSequence.AppendCallback(() => primaryKey.keyPressed = EKeyState.KEY_PRESSED);
                localSequence.AppendInterval(0.5f);
                localSequence.AppendCallback(() => primaryKey.keyPressed = EKeyState.KEY_UNPRESSED);
                localSequence.AppendInterval(0.5f);
                localSequence.AppendCallback(() => primaryKey.keyPressed = EKeyState.KEY_PRESSED);
                localSequence.AppendInterval(0.5f);
                localSequence.AppendCallback(() => primaryKey.keyPressed = EKeyState.KEY_UNPRESSED);
            }
        }
        foreach (var modifierKey in keyboard.modifierKeys )
        {
            if (modifierKey.KeyName == "command-left")
            {
                localSequence.AppendCallback(() => modifierKey.keyPressed = EKeyState.KEY_UNPRESSED);
                // localSequence.AppendInterval(5f);
                // localSequence.AppendCallback(() => modifierKey.keyPressed = EKeyState.KEY_UNPRESSED);
            }
        }
        localSequence.Play();
    }
    
    private void DisplayKeyUIControls(ARKeyboard keyboard)
    {
        foreach (var key in keyboard.primaryKeys)
        {
            if (key.KeyName == "N")
            {
                // key.keyAvailability = KeyAvailabilityState.EKeyAvailability.AVAILABLE;
                key.uiShortcutState = UIShortcutState.EuiShortcutState.PREVIOUS_SHORTCUT;
            }else if (key.KeyName == "M")
            {
                // key.keyAvailability = KeyAvailabilityState.EKeyAvailability.AVAILABLE;
                key.uiShortcutState = UIShortcutState.EuiShortcutState.NEXT_SHORTCUT;
            }else if (key.KeyName == "U")
            {
                // key.keyAvailability = KeyAvailabilityState.EKeyAvailability.AVAILABLE;
                key.uiShortcutState = UIShortcutState.EuiShortcutState.LOOP;
            }
            else if (key.KeyName == "W")
            {
                // key.keyAvailability = KeyAvailabilityState.EKeyAvailability.AVAILABLE;
                key.uiShortcutState = UIShortcutState.EuiShortcutState.QUIT;
            }
        }
    }


    private void ScreenFadeIn(ARKeyboard keyboard)
    {
        _fullscreenPanel = _localCanvas.gameObject.transform.Find("Fullscreen-panel").GetComponent<Image>();
        _fullscreenPanel.DOFade(0.5f, 3f);
    }
    
    private void ScreenFadeOut(ARKeyboard keyboard)
    {
        _fullscreenPanel = keyboard.ARScreen.gameObject.transform.Find("Canvas").gameObject
            .transform.Find("Fullscreen-panel").GetComponent<Image>();
        _fullscreenPanel.DOFade(0f, 3f);
    }
    
    private void DisplayVideoPlayer(ARKeyboard keyboard)
    {
        keyboard.ARScreen.ChangeScreenState(ARKeyboardScreen.EScreenState.ACTIVE);

        videoPlayer = Instantiate(videoPlayer, this.transform);
        videoPlayer.transform.position = Vector3.zero;
        var rawImage = keyboard.ARScreen.GetComponentInChildren<RawImage>();
        rawImage.texture = renderTexture;
    }
    
    private void HideVideoPlayer(ARKeyboard keyboard)
    {
        keyboard.ARScreen.ChangeScreenState(ARKeyboardScreen.EScreenState.INACTIVE);

        videoPlayer = Instantiate(videoPlayer, this.transform);
        videoPlayer.transform.position = Vector3.zero;
        var rawImage = keyboard.ARScreen.GetComponentInChildren<RawImage>();
        rawImage.texture = renderTexture;
    }

    private void ShowcaseImportantKeys(ARKeyboard arKeyboard)
    {
        foreach (var primaryKey in arKeyboard.primaryKeys)
        {
            if (primaryKey.KeyName == "Z")
            {
                primaryKey.keyAvailability = KeyAvailabilityState.EKeyAvailability.AVAILABLE;
                primaryKey.keyOutline = KeyOutlineState.EKeyOutline.OUTLINE;
            }
        }
        
        foreach (var modifierKey in arKeyboard.modifierKeys)
        {
            if (modifierKey.KeyName == "command-left")
            {
                modifierKey.keyAvailability = KeyAvailabilityState.EKeyAvailability.AVAILABLE;
                modifierKey.keyOutline = KeyOutlineState.EKeyOutline.OUTLINE;
            }
        }
        
    }

    private void FadeOutKeysExpectShortcut(ARKeyboard keyboard)
    {
        foreach (var key in keyboard.keys)
        {

            if (key.KeyName != "Z" || key.KeyName != "command-left")
            {
                key.keyAvailability = KeyAvailabilityState.EKeyAvailability.UNAVAILABLE;
            }
        }
    }

    private void ResetKeys(ARKeyboard keyboard)
    {
        foreach (var key in keyboard.primaryKeys)
        {
            key.keyAvailability = KeyAvailabilityState.EKeyAvailability.AVAILABLE;

            if (key.KeyName == "G")
            {
                key.uiShortcutState = UIShortcutState.EuiShortcutState.NONE;
            }

            if (key.KeyName == "space")
            {
                key.keyAvailability = KeyAvailabilityState.EKeyAvailability.DISABLE_DISPLAY_TEXT_IMAGE;
            }
        }

        foreach (var modifierKey in keyboard.modifierKeys)
        {
            modifierKey.keyAvailability = KeyAvailabilityState.EKeyAvailability.AVAILABLE;
        }

    }

    private void PlaceScreenSpaceUI()
    {
        var sequenceScreenspaceUI = DOTween.Sequence();

        sequenceScreenspaceUI.Pause();
        
        var ui = Instantiate(screenspaceUI);
        ui.name = "ScreenSpaceUI";
        var uiText = ui.GetComponentInChildren<TextMeshProUGUI>();
        var uiPanel = ui.GetComponentInChildren<Image>();
        uiText.text = undoShortcut.shortcutName;

        sequenceScreenspaceUI.Append(uiText.DOFade(1, 3.234f));
        sequenceScreenspaceUI.Insert(0, uiPanel.DOFade(1, 3.234f));

        sequenceScreenspaceUI.Play();
    }
    

    public override ARKeyboardState HandleInput(Key key, ARKeyboard keyboard)
    {
        if (key.KeyName == "Z" && key.keyPressed == EKeyState.KEY_PRESSED)
        {
            _zPressed = true;
        }
        if (key.KeyName == "command-left" && key.keyPressed == EKeyState.KEY_PRESSED)
        {
            _cmdPressed = true;
        }

        if (_zPressed && _cmdPressed)
        {
            if (!_shortcutComplete)
            {
                var completionSequence = DOTween.Sequence();
                completionSequence.Pause();
                completionSequence.AppendCallback(() =>
                {
                    _shortcutSuccessPanel.SetShortcutSuccessPopUpState(ShortcutSuccessPanel.EShortcutSuccessPopUp.AVAILABLE,
                        undoSprite, "UNDO");
                });
                completionSequence.AppendInterval(2f);
                completionSequence.AppendCallback(() =>
                {
                    _shortcutSuccessPanel.SetShortcutSuccessPopUpState(ShortcutSuccessPanel.EShortcutSuccessPopUp.UNAVAILABLE, null, null);
                });
            
                completionSequence.Play();            }
        }

        if (key.KeyName == "M" && key.keyPressed == EKeyState.KEY_PRESSED)
        {
            var nextState = Instantiate(selectAllShortcutState);
            return nextState;
        }
        
        return null;
    }
}
