using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShortcutSuccessPanelState : MonoBehaviour
{
    
    [SerializeField] private Image background;
    [SerializeField] private Image uiImage;
    [SerializeField] private TextMeshProUGUI textMeshPro;

    
    public enum EShortcutSuccessPopUp
    {
        AVAILABLE,
        UNAVAILABLE
    }

    private void Awake()
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
        
        sequence.Append(uiImage.DOFade(1, 1f));
        sequence.AppendInterval(0.1f);
        sequence.AppendCallback(Unavailable);
    }
    
    private void Unavailable()
    {
        var sequence = DOTween.Sequence();
        sequence.Insert(0, background.DOFade(0, 0.65f))
            .Insert(0, uiImage.DOFade(0, 0.65f))
            .Insert(0, textMeshPro.DOFade(0, 0.65f));
        sequence.Play();
    }
}