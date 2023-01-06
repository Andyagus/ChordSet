using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes._3MobileAR.Scripts.Screen.States
{
    /// <summary>
    /// Triggered when a shortcut is accessed.  The UI GameObject gets customized
    /// animated through this state.
    /// This is currently the only portion of the AR Screen being utilized. 
    /// </summary>
    public class ShortcutSuccessPanelState : MonoBehaviour
    {
        [SerializeField] private Image background;
        [SerializeField] private Image uiImage;
        [SerializeField] private TextMeshProUGUI textMeshPro;
        
        //DOTween Sequence 
        [SerializeField] private float insertTime = 0f;
        [SerializeField] private float fadeTime = 1f;
        [SerializeField] private float fadeInAmt = 0.98f;
        [SerializeField] private float fadeOutAmt = 0f;
        
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
            //Setting the image and text of the popup
            uiImage.sprite = sprite;
            textMeshPro.text = text;
            
            //Fade the shortcut success in and after 0.1 seconds fade it back out. 
            var availableSequence = DOTween.Sequence();
            availableSequence.Insert(insertTime, background.DOFade(fadeInAmt/2, fadeTime))
                .Insert(insertTime, uiImage.DOFade(fadeInAmt, fadeTime))
                .Insert(insertTime, textMeshPro.DOFade(fadeInAmt, fadeTime));
            availableSequence.AppendInterval(insertTime/10f);
            availableSequence.AppendCallback(Unavailable);
        }
    
        private void Unavailable()
        {
            var unavailableSequence = DOTween.Sequence();
            unavailableSequence.Insert(insertTime, background.DOFade(fadeOutAmt, fadeTime/2))
                .Insert(insertTime, uiImage.DOFade(fadeOutAmt, fadeTime/2))
                .Insert(insertTime, textMeshPro.DOFade(fadeOutAmt, fadeTime/2));
            unavailableSequence.Play();
        }
    }
}
