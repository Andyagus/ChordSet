using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes._3MobileAR.Scripts.Keys.Key_States
{
    /// <summary>
    /// Sets outline on key for emphasis on required presses.
    /// Tried implementing into learning mode, but now primarily for modifier key.
    /// </summary>
    public class KeyOutlineState : MonoBehaviour
    {
        [SerializeField] private Image outline;
        [SerializeField] private float fadeInAmt = 1;
        [SerializeField] private float fadeOutAmt = 0;
        [SerializeField] private float fadeTime;
        
        public enum EKeyOutline
        {
            OUTLINE,
            NO_OUTLINE
        }

        public void SetOutlineState(EKeyOutline state)
        {
            switch (state)
            {
                case EKeyOutline.OUTLINE:
                    Outline();
                    break;
                case EKeyOutline.NO_OUTLINE:
                    NoOutline();
                    break;
            }
        }
        private void Outline()
        {
            outline.DOFade(fadeInAmt, fadeTime);
        }
    
        private void NoOutline()
        {
            outline.DOFade(fadeOutAmt, fadeTime);
        }

    
    }
}

