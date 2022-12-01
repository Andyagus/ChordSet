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
        
        public override void Execute(EKeyState keyState, ARPrimaryKey key)
        {
            _executeSequence = DOTween.Sequence();
            _executeSequence.Append(scissors.rectTransform.DOLocalMoveX(amountToMoveScissors, 1f, false));
            // _executeSequence.Append(xFull.transform.DOSpiral(2f));
            _executeSequence.Insert(1, xTop.rectTransform.DOSpiral(2));
            _executeSequence.Insert(1, xBottom.rectTransform.DOSpiral(2));
            // var primaryKey = GetComponentInParent<ARPrimaryKey>();
            // primaryKey.onPrimaryKeyHit.Notify(this);
        }

        public override void SetGraphics(ARPrimaryKey key)
        {
            var keyText = key.GetComponentInChildren<TextMeshProUGUI>();
            _animationSequence = DOTween.Sequence();

            _animationSequence.Append(keyText.DOFade(0, 1f))
                .Append(xTop.DOFade(1, 0.5f))
                .Insert(1, xBottom.DOFade(1, 0.5f))
                .Append(scissors.DOFade(1, 1f)).SetAutoKill(false);
            _animationSequence.SetAutoKill(false);


        }

        public override void StopSequence()
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
        }
    }
}
