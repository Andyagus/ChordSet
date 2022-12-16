using System;
using System.Collections;
using System.Collections.Generic;
using AR_Keyboard;
using DG.Tweening;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class KeyShortcutState : MonoBehaviour
{
    
    [Header("Command State Shortcuts")]
    public Shortcut undoShortcut;
    public Shortcut cutShortcut;
    public Shortcut copyShortcut;
    public Shortcut pasteShortcut;
    public Shortcut printShortcut;
    public Shortcut rulerShortcut;
    
    [Header("Command-Shift State Shortcuts")]
    public Shortcut saveAsShortcut;
    public Shortcut screenshotShortcut;
    public Shortcut selectAllShortcut;
    
    public enum EKeyShortcutState
    {
        UNDO_SHORTCUT,
        CUT_SHORTCUT,
        COPY_SHORTCUT,
        PASTE_SHORTCUT,
        PRINT_SHORTCUT,
        RULER_SHORTCUT,
        SAVE_AS_SHORTCUT,
        SCREENSHOT_SHORTCUT,
        SELECT_ALL_SHORTCUT,
        NONE
    }

    public void SetKeyShortcutState(EKeyShortcutState state, ARPrimaryKey primaryKey)
    {

        switch (state)
        {
            case EKeyShortcutState.UNDO_SHORTCUT:
                InstantiateShortcut(primaryKey, undoShortcut);
                break;
            case EKeyShortcutState.CUT_SHORTCUT:
                InstantiateShortcut(primaryKey, cutShortcut);
                break;
            case EKeyShortcutState.COPY_SHORTCUT:
                InstantiateShortcut(primaryKey, copyShortcut);
                break;
            case EKeyShortcutState.PASTE_SHORTCUT:
                InstantiateShortcut(primaryKey, pasteShortcut);
                break;
            case EKeyShortcutState.PRINT_SHORTCUT:
                InstantiateShortcut(primaryKey, printShortcut);
                break;
            case EKeyShortcutState.RULER_SHORTCUT:
                InstantiateShortcut(primaryKey, rulerShortcut);
                break;
            case EKeyShortcutState.SAVE_AS_SHORTCUT:
                InstantiateShortcut(primaryKey, saveAsShortcut);
                break;
            case EKeyShortcutState.SCREENSHOT_SHORTCUT:
                InstantiateShortcut(primaryKey, screenshotShortcut);
                break;
            case EKeyShortcutState.SELECT_ALL_SHORTCUT:
                InstantiateShortcut(primaryKey, selectAllShortcut);
                break;
            case EKeyShortcutState.NONE:
                EraseShortcut(primaryKey);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(state), state, null);
        }
    }


    private void InstantiateShortcut(ARPrimaryKey primaryKey, Shortcut shortcut)
    {
        var sequence = DOTween.Sequence();

        sequence.Pause();
        
        if (shortcut != null)
        {
            sequence.AppendCallback(() =>
            {
                if (primaryKey.currentShortcut != null)
                {
                    Destroy(primaryKey.currentShortcut.gameObject);
                }
            }); 
            
            sequence.Append(primaryKey.letterText.DOFade(0, 1f));

            sequence.InsertCallback(0, () =>
            {
                var newShortcut = Instantiate(shortcut, primaryKey.transform);
                var offset = new Vector3(0f, 0.0007f, 0f);
                newShortcut.transform.position = primaryKey.transform.position + offset;
                primaryKey.currentShortcut = newShortcut;
                newShortcut.GetComponentInChildren<Image>().DOFade(1, 1f);
            });
            
            sequence.Play();
        }
    }
    
    private void EraseShortcut(ARPrimaryKey primaryKey)
    {

        var sequence = DOTween.Sequence();

        sequence.Pause();
        
        sequence.Append(primaryKey.currentShortcut.GetComponentInChildren<Image>().DOFade(0, 1f));
        sequence.Insert(0, primaryKey.letterText.DOFade(1, 1f));

        sequence.AppendCallback(() =>
        {
            if (primaryKey.currentShortcut != null)
            {
                Destroy(primaryKey.currentShortcut.gameObject);
            }
        });

        sequence.Play();
    }
    
    
}
