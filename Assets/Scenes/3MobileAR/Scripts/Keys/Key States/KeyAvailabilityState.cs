using DG.Tweening;
using Scenes._3MobileAR.Scripts.Keyboard;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes._3MobileAR.Scripts.Keys.Key_States
{
    
    /// <summary>
    /// This state is used to fade out the keys letter(s) and image,
    /// based on the availability of the key.
    /// Currently availability is set manually.
    /// TODO: Make availability automatic by keeping track of progress of shortcuts
    /// </summary>
    public class KeyAvailabilityState : MonoBehaviour
    {
        private ARKeyboard _keyboard;
        private bool _welcomeState;

        [SerializeField] private TextMeshProUGUI letterText;
        [SerializeField] private TextMeshProUGUI secondaryText;
        [SerializeField] private Image letterImage;

        [Header("Controls")]
        [SerializeField] private float fadeAmt = 0.25f;
        [SerializeField] private float fadeTime = 0.973f;
    
        public enum EKeyAvailability
        {
            NONE,
            AVAILABLE,
            UNAVAILABLE,
        }

        public void SetKeyAvailabilityState(EKeyAvailability state)
        {
            switch (state)
            {
                case EKeyAvailability.AVAILABLE:
                    Available();
                    break;
                case EKeyAvailability.UNAVAILABLE:
                    Unavailable();
                    break;
            }
        }

 
        private void Available()
        {
            if (letterText != null)
            {
                letterText.DOFade(1, fadeTime);
            }

            if (secondaryText != null)
            {
                secondaryText.DOFade(1, fadeTime);
            }

            if (letterImage != null)
            {
                letterImage.DOFade(1, fadeTime/2);
            }
        }
    
        private void Unavailable()
        {
            if (letterText != null)
            {
                letterText.DOFade(fadeAmt, fadeTime);
            }

            if (secondaryText != null)
            {
                secondaryText.DOFade(fadeAmt, fadeTime);
            }

            if (letterImage != null)
            {
                letterImage.DOFade(fadeAmt, fadeTime);
            }
        }
    

    }
}
