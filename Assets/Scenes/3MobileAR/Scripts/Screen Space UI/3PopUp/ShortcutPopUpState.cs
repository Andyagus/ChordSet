using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes._3MobileAR.Scripts.Screen_Space_UI._3PopUp
{
    /// <summary>
    /// Handles UI Shortcut Pop-up appear and disappear animations. 
    /// </summary>
    public class ShortcutPopUpState : MonoBehaviour
    {
        //TODO: Refactor - accessing fields that are already defined in the prefab
        [SerializeField] private Image popUpBackground;
        [SerializeField] private TextMeshProUGUI popUpText;
        [SerializeField] private Image popUpImage;
    
        [SerializeField] private float fadeInAmt = 0.74f;
        [SerializeField] private float fadeOutAmt = 0f;
        [SerializeField] private float fadeTime = 0.35f;
        [SerializeField] private float insertTime = 0;
        [SerializeField] private float appendTime = 2.96f;
    
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
            sequence.Append(popUpBackground.DOFade(fadeInAmt, fadeTime))
                .Insert(insertTime, popUpText.DOFade(fadeInAmt, fadeTime))
                .Insert(insertTime, popUpImage.DOFade(fadeInAmt, fadeTime));
            sequence.AppendInterval(appendTime);
            sequence.AppendCallback(Inactive);
        }
    
        private void Inactive()
        {
            //TODO InActive should be called from OnShortcutDisplayComplete() callback from ShortcutPreviewManager 
            popUpBackground.DOFade(fadeOutAmt, fadeTime);
            popUpText.DOFade(fadeOutAmt, fadeTime);
            popUpImage.DOFade(fadeOutAmt, fadeTime);
        }
    }
}