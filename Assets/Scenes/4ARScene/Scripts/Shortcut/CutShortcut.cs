using System;
using DG.Tweening;
using Enums;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AR_Keyboard.Shortcuts.Scripts
{
    public class CutShortcut : Shortcut
    {
        [SerializeField] private GameObject xFull;
        [SerializeField] private Image xTop;
        [SerializeField] private Image xBottom;
        [SerializeField] private Image scissors;
        private Sequence _animationSequence;
        private Sequence _executeSequence;

        [SerializeField] private float amountToMoveScissors = 0.1f;
        
        public override void Execute(ARPrimaryKey key)
        {
            
            _executeSequence = DOTween.Sequence();

            if (scissors != null)
            {
                _executeSequence.Append(scissors.rectTransform.DOLocalMoveX(amountToMoveScissors, 0.3f));
            }
            
            var tweenToLocation1 = new Vector3(0.05f, 0.03f, 0.002f);
            var tweenToLocation2 = new Vector3(0.08f, 0.07f, 0.002f);
            
            _executeSequence.Insert(0.3f, xTop.rectTransform.DOLocalMove(tweenToLocation1, 1.2f));
            _executeSequence.Insert(0.3f, xBottom.rectTransform.DOLocalMove(tweenToLocation2, 2.1f));
            
            _executeSequence.Insert(1.2f, xTop.DOFade(0, 1f));
            _executeSequence.Insert(1.2f, xBottom.DOFade(0, 1f));
            // _executeSequence.SetAutoKill(false);

            base.Execute(key);
        }

        public override void SetGraphics(ARPrimaryKey key)
        {
            var keyText = key.GetComponentInChildren<TextMeshProUGUI>();
            _animationSequence = DOTween.Sequence();

            _animationSequence.Append(keyText.DOFade(0, 1f))
                .Append(xTop.DOFade(1, 0.5f))
                .Insert(1, xBottom.DOFade(1, 0.5f))
                .Append(scissors.DOFade(1, 1f));
            _animationSequence.SetAutoKill(false);
            base.SetGraphics(key);
        }

        public override void StopSequence(ARPrimaryKey key)
        {
            if (_animationSequence != null)
            {
                _animationSequence.Pause();
                _animationSequence.Kill();
            }
            
            if (_executeSequence != null)
            {
                _executeSequence.Pause();
                _executeSequence.Kill();
            }
            base.StopSequence(key);
        }
    }
}
