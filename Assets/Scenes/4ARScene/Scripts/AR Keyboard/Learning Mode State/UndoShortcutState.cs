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

    private bool enterMode;
    
    // [SerializeField] private GameObject primaryOutline;
    // [SerializeField] private GameObject o;
    
    //display those keys in highlight -
    public override void Entry(ARKeyboard keyboard)
    {

        _showcaseSequence = DOTween.Sequence();

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
            ScreenFade(keyboard);
        });
        
        _showcaseSequence.AppendCallback(() =>
        {
            DisplayVideoPlayer(keyboard);
        });
        
        _showcaseSequence.AppendCallback(() =>
        {
            videoPlayer.GetComponent<VideoPlayer>().Play();
        });
        
        _showcaseSequence.AppendInterval(7f);
        
        _showcaseSequence.AppendCallback(() =>
        {
            ScreenFadeOut(keyboard);
        });
        _showcaseSequence.AppendCallback(() =>
        {
            HideVideoPlayer(keyboard);
        });
        
        
        // _showcaseSequence.AppendCallback(()=>
        // {
        //     // PlaceScreenSpaceUI();
        // });

        // var entrySequence = DOTween.Sequence();
        //
        // entrySequence.AppendCallback(PlaceScreenSpaceUI);
        // entrySequence.AppendInterval(3f);
        // entrySequence.AppendCallback(() =>
        // {
        //     FadeOutAndKeep(keyboard);
        // }); 
        //
        // entrySequence.AppendInterval(1f);
        //
        // entrySequence.AppendCallback(() =>
        // {
        //     ScreenFade(keyboard);
        // });
        //
        // entrySequence.AppendInterval(1f);
        // entrySequence.AppendCallback(() =>
        // {
        //     DisplayVideoPlayer(keyboard);
        // });
        //
        // entrySequence.AppendInterval(3f);
        // entrySequence.AppendCallback(() =>
        // {
        //     videoPlayer.GetComponent<VideoPlayer>().Play();
        // });
        //
        // entrySequence.AppendCallback(() =>
        // {
        //     AnimateDisplaySequence(keyboard);
        // });

        // entrySequence.AppendCallback(() => LearnShortcutButton(keyboard));
    }

    
    private void ScreenFade(ARKeyboard keyboard)
    {
        _fullscreenPanel = keyboard.ARScreen.gameObject.transform.Find("Canvas").gameObject
            .transform.Find("Fullscreen-panel").GetComponent<Image>();
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
                //this probably needs to be a state
                key.displayImage.DOFade(0, 2f);
                key.keyText.DOFade(1, 2);
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


    private void AnimateDisplaySequence(ARKeyboard keyboard)
    {
        // _showcaseSequence = DOTween.Sequence();
        // _showcaseSequence.Pause();
        // _showcaseSequence.AppendInterval(1f);
        // foreach (var modifierKey in keyboard.modifierKeys)
        // {
        //     if (modifierKey.KeyName == "command-left")
        //     {
        //         var rend = modifierKey.GetComponentInChildren<MeshRenderer>();
        //
        //         _showcaseSequence.Append(rend.material.DOColor(Color.white, 1.1f));
        //         _showcaseSequence.AppendInterval(2f);
        //         _showcaseSequence.Append(rend.material.DOColor(Color.black, 1.2f));
        //
        //         //move to key itself
        //     }            
        // }
        
        // foreach (var primaryKey in keyboard.primaryKeys)
        // {
        //     if (primaryKey.KeyName == "Z")
        //     {
        //         var rend = primaryKey.GetComponentInChildren<MeshRenderer>();
        //         _showcaseSequence.Append(rend.material.DOColor(Color.white, 0.2f));
        //         _showcaseSequence.Append(rend.material.DOColor(Color.black, 0.25f));
        //         _showcaseSequence.AppendInterval(1f);
        //         _showcaseSequence.Append(rend.material.DOColor(Color.white, 0.2f));
        //         _showcaseSequence.Append(rend.material.DOColor(Color.black, 0.25f));
        //         _showcaseSequence.AppendInterval(1f);
        //         _showcaseSequence.Append(rend.material.DOColor(Color.white, 0.2f));
        //         _showcaseSequence.Append(rend.material.DOColor(Color.black, 0.25f));
        //         _showcaseSequence.AppendInterval(1f);
        //         _showcaseSequence.Append(rend.material.DOColor(Color.white, 0.2f));
        //         _showcaseSequence.Append(rend.material.DOColor(Color.black, 0.25f));
        //     }
        // }
        //
        // _showcaseSequence.Play();
    }


    
    private void PlaceScreenSpaceUI()
    {
        var sequenceScreenspaceUI = DOTween.Sequence();

        sequenceScreenspaceUI.Pause();
        
        var ui = Instantiate(screenspaceUI, this.transform);
        var uiText = ui.GetComponentInChildren<TextMeshProUGUI>();
        var uiPanel = ui.GetComponentInChildren<Image>();
        uiText.text = undoShortcut.shortcutName;

        sequenceScreenspaceUI.Append(uiText.DOFade(1, 3.234f));
        sequenceScreenspaceUI.Insert(0, uiPanel.DOFade(1, 3.234f));

        sequenceScreenspaceUI.Play();
    }
    

    public override ARKeyboardState HandleInput(Key key)
    {

        
        // foreach (var key in keyboard.primaryKeys)
        // {
        //     if (key.KeyName == "Return" && key.keyPressedState == EKeyState.KEY_PRESSED)
        //     {
        //         enterMode = true;
        //     }
        //
        //     if (enterMode)
        //     {
        //         // key.SetPrimaryKeyState(ARPrimaryKey.EPrimaryKeyState.LEARNING_STATE_ENTER_MODE);
        //         _fullscreenPanel = keyboard.ARScreen.gameObject.transform.Find("Canvas").gameObject
        //             .transform.Find("Fullscreen-panel").GetComponent<Image>();
        //         _fullscreenPanel.DOFade(0.0f, 3f);
        //         keyboard.ARScreen.ChangeScreenState(ARKeyboardScreen.EScreenState.INACTIVE);
        //
        //         
        //         if (key.KeyName == "Z" && key.keyPressedState == EKeyState.KEY_PRESSED)
        //         {
        //             //play sound
        //             // key.SetPrimaryKeyState(ARPrimaryKey.EPrimaryKeyState.LEARNING_ACTIVE_MENU_BUTTON);
        //         } 
        //         if (key.KeyName == "Z" && key.keyPressedState == EKeyState.KEY_UNPRESSED)
        //         {
        //             // key.SetPrimaryKeyState(ARPrimaryKey.EPrimaryKeyState.DEFAULT);
        //         }
        //         
        //         
        //         
        //     }
        //
        // }

        // foreach (var modifierKey in keyboard.modifierKeys)
        // {
        //     if (modifierKey.KeyName == "command-left" && modifierKey.keyPressedState == EKeyState.KEY_PRESSED)
        //     {
        //         // modifierKey.ChangeLocalState(ARModifierKey.EModifierKeyState.ACTIVE);
        //     }  
        //     if (modifierKey.KeyName == "command-left" && modifierKey.keyPressedState == EKeyState.KEY_UNPRESSED)
        //     {
        //         // modifierKey.ChangeLocalState(ARModifierKey.EModifierKeyState.DEFAULT);
        //     }   
        // }
        
        return null;
    }
}
