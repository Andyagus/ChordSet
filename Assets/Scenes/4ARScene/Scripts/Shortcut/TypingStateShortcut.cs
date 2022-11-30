using DG.Tweening;
using Effects;
using Enums;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

namespace AR_Keyboard.Shortcuts.Scripts
{
    public class TypingStateShortcut : Shortcut
    {
        private Sequence _sequence;
        
        public override void StopSequence()
        {
            if (_sequence != null)
            {
                _sequence.Pause();
                _sequence.Kill();
            }
        }

        public override void SetGraphics(ARPrimaryKey key)
        {
            // DOTween.pause
            
            _sequence = DOTween.Sequence();
            var text = key.GetComponentInChildren<TextMeshProUGUI>();
            var dt = text.DOText(key.name, 1f);
            var dc = text.DOColor(Color.white, 1f);
            _sequence.Append(dt).Insert(0, dc);
            
            // var sequence = DOTween.Sequence();
            // sequence.Append(text.DOText(key.KeyName, 1));
            // sequence.Insert(0, text.DOFade(1, 1));
            // DOTween.Clear();
        }

        public override void Execute(EKeyState keyState, ARPrimaryKey key)
        {
            
            Debug.Log("Typing shortcut called");
            if (keyState == EKeyState.KEY_PRESSED)
            {
                KeyColorManager.ChangeKeyColor(key, Color.grey);
            }else if (keyState == EKeyState.KEY_UNPRESSED)
            {
                var originalColor = new Color 
                {
                     r = .1132075f,
                     g = .1132075f,
                     b = .1132075f 
                }; 
                KeyColorManager.ChangeKeyColor(key, originalColor);
            }
        }
    }
}