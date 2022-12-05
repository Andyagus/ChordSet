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
            
            //these are available graphics...
            // key.SetPrimaryKeyState(ARPrimaryKey.EPrimaryKeyState.TYPING_OFF);

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

        public override void Execute(EKeyState inputKeyState, ARPrimaryKey primaryKey)
        {
            
            Debug.Log("Executing primary key");


            if (primaryKey.primaryKeyState == ARPrimaryKey.EPrimaryKeyState.ACTIVE)
            {
                KeyColorManager.ChangeKeyColor(primaryKey, Color.white);

                // primaryKey.SetPrimaryKeyState(ARPrimaryKey.EPrimaryKeyState.TYPING_ON);
            }else if (primaryKey.primaryKeyState == ARPrimaryKey.EPrimaryKeyState.INACTIVE)
            {
                KeyColorManager.ChangeKeyColor(primaryKey, Color.black);
                // primaryKey.SetPrimaryKeyState(ARPrimaryKey.EPrimaryKeyState.TYPING_OFF);
            }
            
            // if (inputKeyState == EKeyState.KEY_PRESSED && primaryKey.primaryKeyState == ARPrimaryKey.EPrimaryKeyState.TYPING_OFF)
            // {
            //     primaryKey.SetPrimaryKeyState(ARPrimaryKey.EPrimaryKeyState.TYPING_ON);
            // }
            // else if (inputKeyState == EKeyState.KEY_UNPRESSED && primaryKey.primaryKeyState == ARPrimaryKey.EPrimaryKeyState.TYPING_ON)
            // {
            //     primaryKey.SetPrimaryKeyState(ARPrimaryKey.EPrimaryKeyState.TYPING_OFF);
            // }

        }
    }
}