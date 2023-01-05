using System;
using DG.Tweening;
using Scenes._3MobileAR.Scripts.Keys.Primary_Key;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes._3MobileAR.Scripts.Keys.Tooltips
{
    
    /// <summary>
    /// ToolTips are similar to shortcuts but instead of effecting
    /// an external app (ie text editor) they provide in app
    /// contextual commands. Currently none are being used.  But
    /// I would like to explore implementation in future. 
    /// </summary>
    
    //TODO: Refactor - Shortcut and Tooltips are almost identical, except for execution. Should inherit base class.

    public class TooltipState : MonoBehaviour
    {
        private Sequence _instantiateSequence;
        private Sequence _destroySequence;
        private readonly Vector3 _placementOffset = new Vector3(0f, 0.0007f, 0f);
    
        private TextMeshProUGUI _primaryKeyText;
        private Image _primaryKeyImage;
    
        [Header("Welcome Mode State")]
        public Tooltip startTooltip;

        [Header("Ambient Mode State")] 
        public Tooltip goToLearningModeTooltip;
    
        [Header("Learning Mode State")] 
        public Tooltip learningModeTitleTooltip;
        public Tooltip playTooltip;
        public Tooltip backToAmbientModeTooltip;
        public Tooltip loopTooltip;
        public Tooltip nextShortcutTooltip;
        public Tooltip previousShortcutTooltip;
        public Tooltip favoriteTooltip;
    


        public enum ETooltip
        {
            NONE,
            START,
            GO_TO_LEARNING_MODE,
            LEARNING_MODE_TITLE,
            PLAY,
            BACK_TO_AMBIENT_MODE,
            LOOP,
            NEXT_SHORTCUT,
            PREVIOUS_SHORTCUT,
            FAVORITE
        }

        public void SetTooltipState(ETooltip state, ARPrimaryKey primaryKey)
        {
            switch (state)
            {
                case ETooltip.NONE:
                    EraseTooltip(primaryKey);
                    break;
                case ETooltip.START:
                    InstantiateTooltip(primaryKey, startTooltip);
                    break;
                case ETooltip.GO_TO_LEARNING_MODE:
                    InstantiateTooltip(primaryKey, goToLearningModeTooltip);
                    break;
                case ETooltip.LEARNING_MODE_TITLE:
                    InstantiateTooltip(primaryKey, learningModeTitleTooltip);
                    break;
                case ETooltip.PLAY:
                    InstantiateTooltip(primaryKey, playTooltip);
                    break;
                case ETooltip.BACK_TO_AMBIENT_MODE:
                    InstantiateTooltip(primaryKey, backToAmbientModeTooltip);
                    break;
                case ETooltip.LOOP:
                    InstantiateTooltip(primaryKey, loopTooltip);
                    break;
                case ETooltip.NEXT_SHORTCUT:
                    InstantiateTooltip(primaryKey, nextShortcutTooltip);
                    break;
                case ETooltip.PREVIOUS_SHORTCUT:
                    InstantiateTooltip(primaryKey, previousShortcutTooltip);
                    break;
                case ETooltip.FAVORITE:
                    InstantiateTooltip(primaryKey, favoriteTooltip);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }


        //TODO Combine instantiate and erase into one method 
    
        private void InstantiateTooltip(ARPrimaryKey primaryKey, Tooltip tooltip)
        {
            if (primaryKey.currentTooltip != null)
            {
                EraseTooltip(primaryKey);
            }
        
            _destroySequence.Kill();
            _instantiateSequence = DOTween.Sequence();
        
            var newTooltip = Instantiate(tooltip, primaryKey.transform);
            primaryKey.currentTooltip = newTooltip;

            newTooltip.transform.position = primaryKey.transform.position + _placementOffset;
        
            _primaryKeyText = primaryKey.currentTooltip.GetComponentInChildren<TextMeshProUGUI>();
            _primaryKeyImage = primaryKey.currentTooltip.GetComponentInChildren<Image>();

            if (primaryKey.letterText != null) _instantiateSequence.Append(primaryKey.letterText.DOFade(0, 1f));
            if(_primaryKeyText!=null) _instantiateSequence.Insert(0, newTooltip.GetComponentInChildren<TextMeshProUGUI>().DOFade(1, 1f));
            if(_primaryKeyImage!=null)_instantiateSequence.Insert(0, newTooltip.GetComponentInChildren<Image>().DOFade(1, 1f));
        }

    
        //TODO The none shortcut should remove letter keys, instead of the "available/unavailable" state. Shortcuts determine key availability
        private void EraseTooltip(ARPrimaryKey primaryKey)
        {
            _instantiateSequence.Kill();
            _destroySequence = DOTween.Sequence();

            if (primaryKey.letterText != null) _destroySequence.Append(primaryKey.letterText.DOFade(1, 1f));
            if(_primaryKeyText!=null) _destroySequence.Insert(0, _primaryKeyText.DOFade(0, 1f));
            if(_primaryKeyImage!=null) _destroySequence.Insert(0, _primaryKeyImage.DOFade(0, 1f));

            _destroySequence.OnKill(() =>
            {
                Destroy(primaryKey.currentTooltip.gameObject);
            });
        }
  
    }
}