using System;
using System.Collections;
using System.Collections.Generic;
using AR_Keyboard;
using AR_Keyboard.State;
using DG.Tweening;
using Enums;
using TMPro;
using UnityEngine;
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
    
    // [SerializeField] private GameObject primaryOutline;
    // [SerializeField] private GameObject o;
    
    //display those keys in highlight -
    public override void Entry(ARKeyboard keyboard)
    {

        var entrySequence = DOTween.Sequence();
        
        entrySequence.AppendCallback(PlaceScreenSpaceUI);
        entrySequence.AppendInterval(3f);
        entrySequence.AppendCallback(() =>
        {
            FadeOutAndKeep(keyboard);
        }); 
       
        entrySequence.AppendInterval(1f);
        
        entrySequence.AppendCallback(() =>
        {
            ScreenFade(keyboard);
        });

        entrySequence.AppendInterval(1f);
        entrySequence.AppendCallback(() =>
        {
            DisplayVideoPlayer(keyboard);
        });
        
        entrySequence.AppendInterval(3f);
        entrySequence.AppendCallback(() =>
        {
            videoPlayer.GetComponent<VideoPlayer>().Play();
        });
        
        entrySequence.AppendCallback(() =>
        {
            AnimateDisplaySequence(keyboard);
        });

        // entrySequence.AppendCallback(() => LearnShortcutButton(keyboard));
    }

    
    
    private void AnimateDisplaySequence(ARKeyboard keyboard)
    {
        _showcaseSequence = DOTween.Sequence();
        _showcaseSequence.Pause();
        _showcaseSequence.AppendInterval(1f);
        foreach (var modifierKey in keyboard.modifierKeys)
        {
            if (modifierKey.KeyName == "command-left")
            {
                var rend = modifierKey.GetComponentInChildren<MeshRenderer>();
        
                _showcaseSequence.Append(rend.material.DOColor(Color.white, 1.1f));
                //move to key itself
            }            
        }
        
        foreach (var primaryKey in keyboard.primaryKeys)
        {
            if (primaryKey.KeyName == "Z")
            {
                var rend = primaryKey.GetComponentInChildren<MeshRenderer>();
                _showcaseSequence.Append(rend.material.DOColor(Color.white, 0.2f));
                _showcaseSequence.Append(rend.material.DOColor(Color.black, 0.25f));
                _showcaseSequence.AppendInterval(1f);
                _showcaseSequence.Append(rend.material.DOColor(Color.white, 0.2f));
                _showcaseSequence.Append(rend.material.DOColor(Color.black, 0.25f));
                _showcaseSequence.AppendInterval(1f);
                _showcaseSequence.Append(rend.material.DOColor(Color.white, 0.2f));
                _showcaseSequence.Append(rend.material.DOColor(Color.black, 0.25f));
                _showcaseSequence.AppendInterval(1f);
                _showcaseSequence.Append(rend.material.DOColor(Color.white, 0.2f));
                _showcaseSequence.Append(rend.material.DOColor(Color.black, 0.25f));
            }
        }
        
        _showcaseSequence.Play();
    }

    private void DisplayVideoPlayer(ARKeyboard keyboard)
    {
        keyboard.ARScreen.ChangeScreenState(ARKeyboardScreen.EScreenState.ACTIVE);

        videoPlayer = Instantiate(videoPlayer, this.transform);
        videoPlayer.transform.position = Vector3.zero;
        var rawImage = keyboard.ARScreen.GetComponentInChildren<RawImage>();
        rawImage.texture = renderTexture;
    }

    private void ScreenFade(ARKeyboard keyboard)
    {
        _fullscreenPanel = keyboard.ARScreen.gameObject.transform.Find("Canvas").gameObject
            .transform.Find("Fullscreen-panel").GetComponent<Image>();
        _fullscreenPanel.DOFade(0.5f, 3f);
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

    private void FadeOutAndKeep(ARKeyboard keyboard)
    {
        foreach (var modifierKey in keyboard.modifierKeys)
        {
            modifierKey.ChangeLocalState(ARModifierKey.EModifierKeyState.LEARNING_STATE_ENTRY);
            
        }
        foreach (var primaryKey in keyboard.primaryKeys)
        {

            primaryKey.SetPrimaryKeyState(ARPrimaryKey.EPrimaryKeyState.LEARNING_STATE_ENTRY);
        }    
    }
    

    

    public override ARKeyboardState HandleInput(string keyName, EKeyState keyState, ARKeyboard keyboard)
    {
        
        
        // // List<string> namesToKeep = new List<string>
        // // {
        // //     "Q",
        // //     "W",
        // //     "S",
        // //     "<",
        // //     ">"
        // // };
        // //
        //
        // foreach (var primaryKey in keyboard.primaryKeys)
        // {
        //
        //     if (primaryKey.KeyName == "S" && primaryKey.keyPressedState == EKeyState.KEY_PRESSED)
        //     {
        //         var star = primaryKey.GetComponentInChildren<StarShortcut>();
        //         star.SetStarState(StarShortcut.eStarState.PRESSED);
        //     }
        //     // foreach (var nameKeep in namesToKeep)
        //     // {
        //     //     if (primaryKey.KeyName == nameKeep)
        //     //     {
        //     //         
        //     //     }
        //     // }
        //
        //     // if (primaryKey.KeyName == "Return" && primaryKey.keyPressedState == EKeyState.KEY_PRESSED)
        //     // {
        //     //     _entryMode = true;
        //     // }
        // }
        //
        // if (_entryMode)
        // {
        //     
        //     //both need to be pressed at same time
        //     foreach (var key in _modifierKeysForChanging)
        //     {
        //         if (key.modifierState == ARModifierKey.EModifierKeyState.LEARNING_SHOWCASE)
        //         {
        //             key.ChangeLocalState(ARModifierKey.EModifierKeyState.LEARNING_AVAILABLE);
        //         }
        //         
        //
        //         if (key.keyPressedState == EKeyState.KEY_PRESSED)
        //         {
        //             key.ChangeLocalState(ARModifierKey.EModifierKeyState.LEARNING_SELECTED);
        //         }
        //         
        //     }
        //
        //     foreach (var key in _primaryKeysForChanging)
        //     {
        //         if (key.primaryKeyState == ARPrimaryKey.EPrimaryKeyState.LEARNING_SHOWCASE)
        //         {
        //             key.SetPrimaryKeyState(ARPrimaryKey.EPrimaryKeyState.LEARNING_AVAILABLE);
        //         }
        //
        //         if (key.keyPressedState == EKeyState.KEY_PRESSED)
        //         {
        //             key.SetPrimaryKeyState(ARPrimaryKey.EPrimaryKeyState.LEARNING_SELECTED);
        //         }
        //     }
        // }
        // else
        // {
        //     return null;
        // }

        return null;
    }
}
