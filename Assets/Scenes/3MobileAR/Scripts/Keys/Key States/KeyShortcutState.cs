using System;
using AR_Keyboard;
using DG.Tweening;
using Scenes._3MobileAR.Scripts.Keys.Primary_Key;
using Scenes._3MobileAR.Scripts.Keys.Shortcuts;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes._3MobileAR.Scripts.Keys.Key_States
{
    
    public class KeyShortcutState : MonoBehaviour
    {
        //DOTween Sequence
        private Sequence _instantiateSequence;
        private Sequence _eraseSequence;
        
        [SerializeField] private float fadeInAmt = 1f;
        [SerializeField] private float fadeOutAmt = 0f;
        [SerializeField] private float fadeTime = 1f;
        //used for instantiation, to place Shortcut graphic above the Key
        private readonly Vector3 _placementOffset =  new Vector3(0f, 0.0007f, 0f);
        
        //Assigning the shortcuts in the inspector on the PrimaryKey base prefab variant
        //TODO: Refactor - do not assign all shortcuts to each key instead onto specific key.
        [Header("Command State Shortcuts")]
        public Shortcut undoShortcut;
        public Shortcut cutShortcut;
        public Shortcut copyShortcut;
        public Shortcut pasteShortcut;
        public Shortcut printShortcut;
        public Shortcut rulerShortcut;
        
        [Header("Command-Shift State Shortcuts")]
        public Shortcut saveAsShortcut;
        public Shortcut screenshotShortcut;
        public Shortcut selectAllShortcut;
        
        public enum EKeyShortcutState
        {
            UNDO_SHORTCUT,
            CUT_SHORTCUT,
            COPY_SHORTCUT,
            PASTE_SHORTCUT,
            PRINT_SHORTCUT,
            RULER_SHORTCUT,
            SAVE_AS_SHORTCUT,
            SCREENSHOT_SHORTCUT,
            SELECT_ALL_SHORTCUT,
            NONE
        }

        //Transitioning to the states instantiate the shortcut on the state
        public void SetKeyShortcutState(EKeyShortcutState state, ARPrimaryKey primaryKey)
        {
            switch (state)
            {
                case EKeyShortcutState.UNDO_SHORTCUT:
                    //Passing in the primary key (gameObject to instantiate logo on) and what shortcut to use
                    InstantiateShortcut(primaryKey, undoShortcut);
                    break;
                case EKeyShortcutState.CUT_SHORTCUT:
                    InstantiateShortcut(primaryKey, cutShortcut);
                    break;
                case EKeyShortcutState.COPY_SHORTCUT:
                    InstantiateShortcut(primaryKey, copyShortcut);
                    break;
                case EKeyShortcutState.PASTE_SHORTCUT:
                    InstantiateShortcut(primaryKey, pasteShortcut);
                    break;
                case EKeyShortcutState.PRINT_SHORTCUT:
                    InstantiateShortcut(primaryKey, printShortcut);
                    break;
                case EKeyShortcutState.RULER_SHORTCUT:
                    InstantiateShortcut(primaryKey, rulerShortcut);
                    break;
                case EKeyShortcutState.SAVE_AS_SHORTCUT:
                    InstantiateShortcut(primaryKey, saveAsShortcut);
                    break;
                case EKeyShortcutState.SCREENSHOT_SHORTCUT:
                    InstantiateShortcut(primaryKey, screenshotShortcut);
                    break;
                case EKeyShortcutState.SELECT_ALL_SHORTCUT:
                    InstantiateShortcut(primaryKey, selectAllShortcut);
                    break;
                case EKeyShortcutState.NONE:
                    EraseShortcut(primaryKey);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }
        
        /// <summary>
        /// InstantiateShortcut() - 
        /// The selected state passes the key and the intended shortcut
        /// instantiates shortcut on the key, and sets the keys current shortcut
        /// to the passed in shortcut 
        /// </summary>
        
        private void InstantiateShortcut(ARPrimaryKey primaryKey, Shortcut shortcut)
        {
            //TODO: Organize when key text (KeyAvailability) is faded in our out, may need to be more aligned with shortcut
            
            //If the erase shortcut sequence is happening, make sure to kill the sequence
            _eraseSequence.Kill();
            _instantiateSequence = DOTween.Sequence();
            var instantiatedShortcut = Instantiate(shortcut, primaryKey.transform);
            primaryKey.currentShortcut = instantiatedShortcut;
            instantiatedShortcut.transform.position = primaryKey.transform.position + _placementOffset;
            
            //TODO: Call Shortcut image directly through field instead of using GetComponent 
            _instantiateSequence.Append(instantiatedShortcut.GetComponentInChildren<Image>().DOFade(fadeInAmt, fadeTime));
        }
    
        //Called when shortcut is set to None.
        private void EraseShortcut(ARPrimaryKey primaryKey)
        {
            _instantiateSequence.Kill();
            _eraseSequence = DOTween.Sequence();
        
            _eraseSequence.Append(primaryKey.currentShortcut.GetComponentInChildren<Image>().DOFade(fadeOutAmt, fadeTime));
            _eraseSequence.OnKill(() =>
            {
                Destroy(primaryKey.currentShortcut.gameObject);
            });

        }
    }
}
