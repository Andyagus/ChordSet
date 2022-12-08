using System.Collections.Generic;
using AR_Keyboard;
using DG.Tweening;
using Effects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes._4ARScene.Scripts.AR_Keyboard
{
    public class AnimationManager : MonoBehaviour
    {

        public static void FadeTextMeshPro(TextMeshProUGUI[] textGroup)
        {
            foreach (var text in textGroup)
            {
                text.DOFade(0, 1.4f);
            }
        }

        public static void FadeImages(Image[] images)
        {
            foreach (var image in images)
            {
                image.DOFade(.1f, 1.3f);
            }
        }

        public static void ApplyKeyOutlineToPrimary(ARPrimaryKey primaryKey)
        {
            primaryKey.keyOutline.gameObject.SetActive(true);
        }
        
        public static void AnimateLearningModeShortcut(ARPrimaryKey primaryKey, Shortcut shortcut, float fadeAmt = 0)
        {
            var sequence = DOTween.Sequence();
            // sequence.Pause();

            var keyText = primaryKey.GetComponentsInChildren<TextMeshProUGUI>();

            sequence.AppendCallback(() =>
            {
                foreach (var text in keyText)
                {
                    text.DOFade(0, 0.4f);
                }
            });
            
            if (primaryKey.referenceKeyForMultikeyShortcuts != null)
            {
                AnimateLearningModeShortcut(primaryKey.referenceKeyForMultikeyShortcuts, shortcut);
            }

            if (primaryKey.KeyName == "W")
            {
                return;
            }
            
            var shortcutInstance = KeyColorManager.InstantiateShortcut(primaryKey, shortcut);
            var shortcutTexts = shortcutInstance.GetComponentsInChildren<TextMeshProUGUI>();
            var shortcutImages = shortcutInstance.GetComponentsInChildren<Image>();

            if (shortcutTexts != null)
            {
                foreach (var text in shortcutTexts)
                {
                    sequence.Append(text.DOFade(0.35f, 0.5f));
                }
            }

            if (shortcutImages != null)
            {
                
                foreach (var image in shortcutImages)
                {
                    if (image.name == "Panel")
                    {
                        return;
                    }
                    sequence.Append(image.DOFade(0.35f, 0.5f));
                }  
            }

            // var sequence = DOTween.Sequence();
            // sequence.Pause();
            //
            // var shortcutImage = shortcutInstance.GetComponentInChildren(typeof(Image), false) as Image;
            //
            // var keyText = primaryKey.GetComponentsInChildren<TextMeshProUGUI>();
            //
            // sequence.AppendCallback(() =>
            // {
            //     foreach (var text in keyText)
            //     {
            //         text.DOFade(1, 4f);
            //     }
            // });
            //
            // sequence.Append(shortcutImage.DOFade(1f, 3.24f).SetEase(Ease.InSine));
            // sequence.Play();
        }
    }
}
