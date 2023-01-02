using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShortcutPopUpState : MonoBehaviour
{
    [SerializeField] private Image popUpBackground;
    [SerializeField] private TextMeshProUGUI popUpText;
    [SerializeField] private Image popUpImage;

    private float _fadeTime = 0.35f;
    
    public enum EShortcutPopUp
    {
        ACTIVE,
        INACTIVE
    }

    public void SetPopUpState(EShortcutPopUp state)
    {
        switch (state)
        {
            case EShortcutPopUp.ACTIVE:
                Active();
                break;
            case EShortcutPopUp.INACTIVE:
                Inactive();
                break;
            default:
                break;
        }
    }
    
    private void Active()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(popUpBackground.DOFade(0.74f, _fadeTime))
            .Insert(0, popUpText.DOFade(1, _fadeTime))
            .Insert(0, popUpImage.DOFade(1, _fadeTime));
        sequence.AppendInterval(0.74f * 4);
        //TODO OnShortcutDisplayComplete() callback from preview manager 
        sequence.AppendCallback(Inactive);
    }
    
    private void Inactive()
    {
        popUpBackground.DOFade(0, _fadeTime);
        popUpText.DOFade(0, _fadeTime);
        popUpImage.DOFade(0, _fadeTime);
    }
}