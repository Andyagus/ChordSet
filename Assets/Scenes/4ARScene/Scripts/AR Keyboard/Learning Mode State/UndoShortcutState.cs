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
    
    //display those keys in highlight -
    
    public override void Entry(ARKeyboard keyboard)
    {

        keyboard.ARScreen.ChangeScreenState(ARKeyboardScreen.EScreenState.ACTIVE);

        
        
        
        videoPlayer = Instantiate(videoPlayer, this.transform);
        videoPlayer.transform.position = Vector3.zero;
        
        var rawImage = keyboard.ARScreen.GetComponentInChildren<RawImage>();
        rawImage.texture = renderTexture;

        _showcaseSequence = DOTween.Sequence();
        
        foreach (var modifierKey in keyboard.modifierKeys)
        {
            
            modifierKey.ChangeLocalState(ARModifierKey.EModifierKeyState.LEARNING_STATE_ENTRY);
            
            foreach (var shortcutKey in undoShortcut.keysToAccess)
            {
                
                // if (modifierKey.KeyName == shortcutKey)
                // {
                //     _modifierKeysForChanging = new List<ARModifierKey>();
                //     _modifierKeysForChanging.Add(modifierKey);
                //     
                //     _showcaseSequence.AppendInterval(0.5f);
                //
                //     _showcaseSequence.AppendCallback(() =>
                //         modifierKey.ChangeLocalState(ARModifierKey.EModifierKeyState.LEARNING_SHOWCASE));
                //     _showcaseSequence.AppendInterval(1f);
                // }
                // else
                // {
                //     modifierKey.ChangeLocalState(ARModifierKey.EModifierKeyState.UNAVAILABLE);
                // }
            }
        }
        foreach (var primaryKey in keyboard.primaryKeys)
        {

            primaryKey.SetPrimaryKeyState(ARPrimaryKey.EPrimaryKeyState.LEARNING_STATE_ENTRY);

            
            foreach (var shortcutKey in undoShortcut.keysToAccess)
            {
                // if (primaryKey.KeyName == shortcutKey)
                // {
                //     _primaryKeysForChanging = new List<ARPrimaryKey>();
                //
                //     _primaryKeysForChanging.Add(primaryKey);
                //
                //     _showcaseSequence.AppendInterval(0.5f);
                //     _showcaseSequence.AppendCallback(() => 
                //         primaryKey.SetPrimaryKeyState(ARPrimaryKey.EPrimaryKeyState.LEARNING_SHOWCASE));
                // }else if (primaryKey.KeyName == "arrow-left" || primaryKey.KeyName == "arrow-right" 
                //                                              || primaryKey.KeyName == "Return"
                //                                              || primaryKey.KeyName == "Escape")
                // {
                //     primaryKey.SetPrimaryKeyState(ARPrimaryKey.EPrimaryKeyState.LEARNING_HELPER);
                // }
                // else
                // {
                //     primaryKey.SetPrimaryKeyState(ARPrimaryKey.EPrimaryKeyState.UNAVAILABLE);
                // }
            }
        }
    }

    public override ARKeyboardState HandleInput(string keyName, EKeyState keyState, ARKeyboard keyboard)
    {
        // List<string> namesToKeep = new List<string>
        // {
        //     "Q",
        //     "W",
        //     "S",
        //     "<",
        //     ">"
        // };
        //

        foreach (var primaryKey in keyboard.primaryKeys)
        {
            
            
            // foreach (var nameKeep in namesToKeep)
            // {
            //     if (primaryKey.KeyName == nameKeep)
            //     {
            //         
            //     }
            // }

            // if (primaryKey.KeyName == "Return" && primaryKey.keyPressedState == EKeyState.KEY_PRESSED)
            // {
            //     _entryMode = true;
            // }
        }

        if (_entryMode)
        {
            
            //both need to be pressed at same time
            foreach (var key in _modifierKeysForChanging)
            {
                if (key.modifierState == ARModifierKey.EModifierKeyState.LEARNING_SHOWCASE)
                {
                    key.ChangeLocalState(ARModifierKey.EModifierKeyState.LEARNING_AVAILABLE);
                }
                

                if (key.keyPressedState == EKeyState.KEY_PRESSED)
                {
                    key.ChangeLocalState(ARModifierKey.EModifierKeyState.LEARNING_SELECTED);
                }
                
            }

            foreach (var key in _primaryKeysForChanging)
            {
                if (key.primaryKeyState == ARPrimaryKey.EPrimaryKeyState.LEARNING_SHOWCASE)
                {
                    key.SetPrimaryKeyState(ARPrimaryKey.EPrimaryKeyState.LEARNING_AVAILABLE);
                }

                if (key.keyPressedState == EKeyState.KEY_PRESSED)
                {
                    key.SetPrimaryKeyState(ARPrimaryKey.EPrimaryKeyState.LEARNING_SELECTED);
                }
            }
        }
        else
        {
            return null;
        }

        return null;
    }
}
