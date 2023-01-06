using System;
using DG.Tweening;
using Scenes._3MobileAR.Scripts.Keys.Primary_Key;
using UnityEngine;

namespace Scenes._3MobileAR.Scripts.Keys.Key_States
{
    /// <summary>
    /// This state was primarily built to shift keys back and fourth
    /// to and from "CHORD SET" in the intro 
    /// TODO: Refactor - However, I believe this state
    /// can play a larger role in the future for setting
    /// up keys and their various letters, maybe be combined
    /// with shortcuts and Availability State. 
    /// </summary>
    public class KeyLetterState : MonoBehaviour
    {
        [SerializeField] private float fadeTime = 0;
        private string _originalLetter;
            
        public enum EKeyLetter
        {
            NONE,
            C,
            H,
            O,
            R,
            D,
            S,
            E,
            T
        }

        public void SetKeyLetterState(EKeyLetter state, ARPrimaryKey primaryKey)
        {
            switch (state)
            {
                case EKeyLetter.NONE:
                    RestoreLetter(primaryKey);
                    break;
                case EKeyLetter.C:
                    ChangeLetter("C", primaryKey);
                    break;
                case EKeyLetter.H:
                    ChangeLetter("H", primaryKey);
                    break;
                case EKeyLetter.O:
                    ChangeLetter("O", primaryKey);                
                    break;
                case EKeyLetter.R:
                    ChangeLetter("R", primaryKey);                
                    break;
                case EKeyLetter.D:
                    ChangeLetter("D", primaryKey);
                    break;
                case EKeyLetter.S:
                    ChangeLetter("S", primaryKey);
                    break;
                case EKeyLetter.E:
                    ChangeLetter("E", primaryKey);
                    break;
                case EKeyLetter.T:
                    ChangeLetter("T", primaryKey);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }
        
        private void ChangeLetter(string text, ARPrimaryKey primaryKey)
        {
            //storing original letter before changing it.  (Nice to store fields in their 
            //respective state machines)
            _originalLetter = primaryKey.letterText.text;
            primaryKey.letterText.DOText(text, fadeTime);
        }
    
        private void RestoreLetter(ARPrimaryKey primaryKey)
        {
            primaryKey.letterText.DOText(_originalLetter, fadeTime);
        }
    }
}
