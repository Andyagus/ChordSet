using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes._3MobileAR.Scripts.Screen.States
{
    /// <summary>
    /// In previous iterations of the app this positioning area enabled the user to place the
    /// text editor app in the correct location for accurate positioning of video over text.
    /// However in latest iterations video was removed, so this class is not used.  Keeping it in
    /// out of personal interest in the process.
    /// </summary>
    public class PositioningAreaState : MonoBehaviour
    {
        [SerializeField] private Image positioningArea;
        [SerializeField] private float fadeInAmt = 1f;
        [SerializeField] private float fadeOutAmt = 0f;
        [SerializeField] private float fadeTime = 1f;
    
        public enum EPositioningArea
        {
            ACTIVE,
            INACTIVE
        }

        public void SetPositioningArea(EPositioningArea state)
        {
            switch (state)
            {
                case EPositioningArea.ACTIVE:
                    Active();
                    break;
                case EPositioningArea.INACTIVE:
                    Inactive();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }
    
        private void Active()
        {
            positioningArea.DOFade(fadeInAmt, fadeTime);
        }
    
        private void Inactive()
        {
            positioningArea.DOFade(fadeOutAmt, fadeTime);
        }
    }
}
