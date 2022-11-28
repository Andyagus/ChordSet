using AR_Keyboard;
using DG.Tweening;
using Enums;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes._4ARScene.Scripts.Shortcut
{
    public class UndoShortcut : AR_Keyboard.Shortcut
    {
        public Image arrowGraphic;  
        private Sequence _sequence; 

        public override void Awake()
        {
            base.Awake();
        }

        public override void StopSequence()
        {
            if (_sequence != null)
            {
                _sequence.Pause();
            }
        }


        public override void SetGraphics(ARPrimaryKey key)
        {
            _sequence = DOTween.Sequence();
            Debug.Log("Set graphics undo called");
            var text = key.GetComponentInChildren<TextMeshProUGUI>();
            // DOTweenTMPAnimator animator = new DOTweenTMPAnimator(text);

            // animator.DORotateChar(0, Vector3.one, 2f);


            // DOTween.
            // _sequence.Append(text.DOColor(Color.blue, 1.3f));
            // _sequence.Append(text.DOText("new text", 1.3f));
            // DOTween.Clear();
        }


     
        public override void Execute(EKeyState keyState, ARPrimaryKey key)
        {
            Debug.Log("Undo Shortcut Called");
        }
    }
}
