using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShortcutSuccessPanel : MonoBehaviour
{

    [SerializeField] private Image background;
    [SerializeField] private Image uiImage;
    [SerializeField] private TextMeshProUGUI textMeshPro;

    [SerializeField] public Sprite imageToPlace;
    [SerializeField] public String titleToPlace;

    public enum EShortcutSuccessPopUp
    {
        AVAILABLE,
        UNAVAILABLE
    }

    public EShortcutSuccessPopUp shortcutSuccessPopUp = EShortcutSuccessPopUp.UNAVAILABLE;


    private void Start()
    {
        Unavailable();
    }

    public void SetShortcutSuccessPopUpState(EShortcutSuccessPopUp state, Sprite sprite, string text)
    {
        switch (state)
        {
            case EShortcutSuccessPopUp.AVAILABLE:
                Available(sprite, text);
                break;
            case EShortcutSuccessPopUp.UNAVAILABLE:
                Unavailable();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(state), state, null);
        }
    }
    
    private void Available(Sprite sprite, string text)
    {
        uiImage.sprite = sprite;
        textMeshPro.text = text;
        var sequence = DOTween.Sequence();

        sequence.Insert(0, background.DOFade(0.572549f, 1f))
            .Insert(0, uiImage.DOFade(0.98f, 1f))
            .Insert(0, textMeshPro.DOFade(0.98f, 1f));
        
        uiImage.DOFade(1, 1f);
    }

    private void Unavailable()
    {
        var sequence = DOTween.Sequence();
        sequence.Insert(0, background.DOFade(0, 1f))
            .Insert(0, uiImage.DOFade(0, 1f))
            .Insert(0, textMeshPro.DOFade(0, 1f));
        sequence.Play();

    }
}
