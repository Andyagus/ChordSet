using System;
using DG.Tweening;
using UnityEngine;

namespace Scenes._3MobileAR.Scripts.Keys.Key_States
{
    /// <summary>
    /// Changes color to either black or white.  State is being currently coupled to the
    /// KeyPressed State.
    /// TODO: Decouple color state and key pressed state
    /// </summary>
    public class KeyColorState : MonoBehaviour
    {
        [SerializeField] private float fadeTime = 0.1f;
    
        public enum EKeyColorState
        {
            BLACK,
            WHITE
        }

        public void SetKeyColorState(EKeyColorState state, Key key)
        {
            switch (state)
            {
                case EKeyColorState.BLACK:
                    Black(key);
                    break;
                case EKeyColorState.WHITE:
                    White(key);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }


        private void White(Key key)
        {
            var color = Color.white;
            var rend = key.GetComponentInChildren<MeshRenderer>();
            rend.material.DOColor(color, fadeTime);
        }
    
        private void Black(Key key)
        {
            var color = Color.black;
            var rend = key.GetComponentInChildren<MeshRenderer>();
            rend.material.DOColor(color, fadeTime);
        }
    
    }
}
