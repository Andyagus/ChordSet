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
        //DOTween Sequence
        private Sequence _instantiateSequence;
        private Sequence _eraseSequence;
        private readonly float _sequenceStartTime = 0f;
        [SerializeField] private float fadeInAmt = 1f;
        [SerializeField] private float fadeOutAmt = 0f;
        [SerializeField] private float fadeTime = 1f;
        
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

            var instantiatedTooltip = Instantiate(tooltip, primaryKey.transform);
            primaryKey.currentTooltip = instantiatedTooltip;

            instantiatedTooltip.transform.position = primaryKey.transform.position + _placementOffset;
        
            //TODO: Get rid of these GetComponents - Clean these few lines up.
            _tooltipText = primaryKey.currentTooltip.GetComponentInChildren<TextMeshProUGUI>();
            _tooltipImage = primaryKey.currentTooltip.GetComponentInChildren<Image>();
            //Bad: Getting letter text directly - but here getting text, in primary key was not even going for text.
            if (primaryKey.letterText != null) _instantiateSequence.Append(primaryKey.letterText.DOFade(fadeOutAmt, fadeTime));
            if(_tooltipText!=null) _instantiateSequence.Insert(_sequenceStartTime, instantiatedTooltip.GetComponentInChildren<TextMeshProUGUI>().DOFade(fadeInAmt, fadeTime));
            if(_tooltipImage!=null)_instantiateSequence.Insert(_sequenceStartTime, instantiatedTooltip.GetComponentInChildren<Image>().DOFade(fadeInAmt, fadeTime));
        }
        
        //TODO The none shortcut should remove letter keys, instead of the "available/unavailable" state. Shortcuts determine key availability
        private void EraseTooltip(ARPrimaryKey primaryKey)
        {
            _instantiateSequence.Kill();
            _eraseSequence = DOTween.Sequence();
            //Fade in letter text, fade out tooltip. 
            if (primaryKey.letterText != null) _eraseSequence.Append(primaryKey.letterText.DOFade(fadeInAmt, fadeTime));
            if(_tooltipText!=null) _eraseSequence.Insert(_sequenceStartTime, _tooltipText.DOFade(fadeOutAmt, fadeTime));
            if(_tooltipImage!=null) _eraseSequence.Insert(_sequenceStartTime, _tooltipImage.DOFade(fadeOutAmt, fadeTime));

            _eraseSequence.OnKill(() =>
            {
                //Destroy tooltip 
                Destroy(primaryKey.currentTooltip.gameObject);
                primaryKey.currentTooltip = null;
            });
        }
  
    }
}