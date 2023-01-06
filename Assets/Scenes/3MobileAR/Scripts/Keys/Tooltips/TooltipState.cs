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
        //DOTween
        private Sequence _instantiateSequence;
        private Sequence _eraseSequence;
        private readonly Vector3 _placementOffset = new Vector3(0f, 0.0007f, 0f);
    
        private TextMeshProUGUI _tooltipText;
        private Image _tooltipImage;
    
        //Tooltip GameObjects are attached to PrimaryKey Variants
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
        
        //Passed in state calls Instantiate Tooltip with key and proper tooltip
        public void SetTooltipState(ETooltip state, ARPrimaryKey primaryKey)
        {
            switch (state)
            {
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
                case ETooltip.NONE:
                    EraseTooltip(primaryKey);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }

        private void InstantiateTooltip(ARPrimaryKey primaryKey, Tooltip tooltip)
        {
            //If there is a current tooltip erase it before creating a new one.
            if (primaryKey.currentTooltip != null)
            {
                EraseTooltip(primaryKey);
            }
        
            _eraseSequence.Kill();
            _instantiateSequence = DOTween.Sequence();

            //Personal note: what is going on here? 
            var instantiatedTooltip = Instantiate(tooltip, primaryKey.transform);
            primaryKey.currentTooltip = instantiatedTooltip;

            instantiatedTooltip.transform.position = primaryKey.transform.position + _placementOffset;
        
            //TODO: Get rid of these GetComponents - Clean these few lines up.
            _tooltipText = primaryKey.currentTooltip.GetComponentInChildren<TextMeshProUGUI>();
            _tooltipImage = primaryKey.currentTooltip.GetComponentInChildren<Image>();
            //Bad: Getting letter text directly - but here getting text, in primary key was not even going for text.
            if (primaryKey.letterText != null) _instantiateSequence.Append(primaryKey.letterText.DOFade(0, 1f));
            if(_tooltipText!=null) _instantiateSequence.Insert(0, instantiatedTooltip.GetComponentInChildren<TextMeshProUGUI>().DOFade(1, 1f));
            if(_tooltipImage!=null)_instantiateSequence.Insert(0, instantiatedTooltip.GetComponentInChildren<Image>().DOFade(1, 1f));
        }
        
        //TODO The none shortcut should remove letter keys, instead of the "available/unavailable" state. Shortcuts determine key availability
        private void EraseTooltip(ARPrimaryKey primaryKey)
        {
            _instantiateSequence.Kill();
            _eraseSequence = DOTween.Sequence();
            //Fade in letter text, fade out tooltip. 
            if (primaryKey.letterText != null) _eraseSequence.Append(primaryKey.letterText.DOFade(1, 1f));
            if(_tooltipText!=null) _eraseSequence.Insert(0, _tooltipText.DOFade(0, 1f));
            if(_tooltipImage!=null) _eraseSequence.Insert(0, _tooltipImage.DOFade(0, 1f));

            _eraseSequence.OnKill(() =>
            {
                //Destroy tooltip 
                Destroy(primaryKey.currentTooltip.gameObject);
                primaryKey.currentTooltip = null;
            });
        }
  
    }
}