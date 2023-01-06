using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes._3MobileAR.Scripts.Screen.States
{
    /// <summary>
    /// Background Panel State fades the screen out (almost to black) and back to regular 
    /// </summary>
    public class BackgroundPanelState : MonoBehaviour
    {
        [SerializeField] private Image backgroundPanel;
        [SerializeField] private float fadeTime = 1;
        [SerializeField] private float fadeInAmt = 0.4f;
        [SerializeField] private float fadeOutAmt = 0f;
        
        public enum EBackgroundPanel
        {
            INACTIVE,
            ACTIVE
        }

        public void SetBackgroundPanel(EBackgroundPanel state)
        {
            switch (state)
            {
                case EBackgroundPanel.INACTIVE:
                    Inactive();
                    break;
                case EBackgroundPanel.ACTIVE:
                    Active();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }
    
        private void Active()
        {
            backgroundPanel.DOFade(fadeInAmt, fadeTime);
        }
    
        private void Inactive()
        {
            backgroundPanel.DOFade(fadeOutAmt, fadeTime);
        }
    }
}
