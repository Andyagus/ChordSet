using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShortcutPopUpState : MonoBehaviour
{
    

    // [SerializeField] private Image panelBackground;
    [SerializeField] private GameObject popUp;
    
    public enum EShortcutPopUp
    {
        ACTIVE,
        INACTIVE
    }

    public void TogglePanelState()
    {
        switch (popUp.activeSelf)
        {
            case true:
                Inactive();
                break;
            case false:
                Active();
                break;
            default:
                break;
        }
    }
    
    //can pass in parameters here…
    private void Active()
    {
        popUp.SetActive(true);
        // panelBackground.DOFade(0.354f, 1f);
        // panelText.DOFade(1, 1f);
        // panelText.DOText(shortcutName, 0f);
    }
    
    private void Inactive()
    {
        popUp.SetActive(false);
        // panelBackground.DOFade(0, 1f);
        // panelText.DOFade(0, 1f);
    }
}