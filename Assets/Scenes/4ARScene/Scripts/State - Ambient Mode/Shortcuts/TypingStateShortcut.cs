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
        
        public override void StopSequence(ARPrimaryKey primaryKey)
        {
            // if (_sequence != null)
            // {
            //     _sequence.Pause();
            //     _sequence.Kill();
            // }
        }

        public override void SetGraphics(ARPrimaryKey key)
        {
            
            
            
            // // DOTween.pause
            //
            // //these are available graphics...
            // // key.SetPrimaryKeyState(ARPrimaryKey.EPrimaryKeyState.TYPING_OFF);
            //
            // _sequence = DOTween.Sequence();
            // var text = key.GetComponentInChildren<TextMeshProUGUI>();
            // var dt = text.DOText(key.name, 1f);
            // var dc = text.DOColor(Color.white, 1f);
            // _sequence.Append(dt).Insert(0, dc);
            //
            // // var sequence = DOTween.Sequence();
            // // sequence.Append(text.DOText(key.KeyName, 1));
            // // sequence.Insert(0, text.DOFade(1, 1));
            // // DOTween.Clear();
        }

        public override void Execute(ARPrimaryKey primaryKey)
        {
            
            Debug.Log("Executing typing state shortcut");

        }
    }
}