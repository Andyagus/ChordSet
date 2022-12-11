using System;
using System.Net.Mime;
using AR_Keyboard.State;
using DG.Tweening;
using Effects;
using Enums;
using Interfaces;
using Scenes._4ARScene.Scripts.AR_Keyboard;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AR_Keyboard
{
    public class ARPrimaryKey : Key
    {
        private ARKeyboard _arKeyboard;
        
        // [SerializeField] public Shortcut learningStateWelcomeShortcut;
        // [SerializeField] public Shortcut learningStateUndoShortcut;
        [Tooltip("for G only right now")]
        [SerializeField] public ARPrimaryKey referenceKeyForMultikeyShortcuts;
        public TextMeshProUGUI keyText;
        
        
        private TextMeshProUGUI _textMesh;

        [Tooltip("Primary Key Shortcut State")]
        private KeyShortcutState _keyShortcutState;
        public KeyShortcutState.EKeyShortcutState keyShortcutState = KeyShortcutState.EKeyShortcutState.NO_SHORTCUT;
        private KeyShortcutState.EKeyShortcutState _prevShortcut = KeyShortcutState.EKeyShortcutState.NO_SHORTCUT;



        public override void Awake()
        {
            _keyShortcutState = GetComponent<KeyShortcutState>();

            DOTween.Clear();
            _textMesh = GetComponentInChildren<TextMeshProUGUI>();
            _arKeyboard = GetComponentInParent<ARKeyboard>();
            base.Awake();
        }

        public override void Update()
        {
            if (keyShortcutState != _prevShortcut)
            {
                _keyShortcutState.SetKeyShortcutState(keyShortcutState, this);
                _prevShortcut = keyShortcutState;
            }
            base.Update();
        }

        //     
        //     public void SetPrimaryKeyState(EPrimaryKeyState state)
        //     {
        //         switch (state)
        //         {
        //             //this should be passed to animation manager.   
        //             case EPrimaryKeyState.ANIMATION_PAUSE:
        //                 AnimationPause();
        //                 break;
        //             case EPrimaryKeyState.ANIMATION_PLAY:
        //                 AnimationPlay();
        //                 break;
        //             case EPrimaryKeyState.UNAVAILABLE:
        //                 Unavailable();
        //                 break;
        //             case EPrimaryKeyState.TYPING_ON:
        //                 TypingOn();
        //                 break;
        //             case EPrimaryKeyState.TYPING_OFF:
        //                 TypingOff();
        //                 break;
        //             case EPrimaryKeyState.DEFAULT:
        //                 DefaultState();
        //                 break;
        //             case EPrimaryKeyState.LEARNING_SHOWCASE:
        //                 LearningShowcase();
        //                 break;
        //             case EPrimaryKeyState.LEARNING_STATE_ENTRY:
        //                 LearningStateEntry();
        //                 break;
        //             case EPrimaryKeyState.LEARNING_WELCOME:
        //                 LearningWelcome();
        //                 break;
        //             case EPrimaryKeyState.LEARNING_HELPER:
        //                 LearningHelper();
        //                 break;
        //             case EPrimaryKeyState.LEARNING_AVAILABLE:
        //                 LearningAvailable();
        //                 break;
        //             case EPrimaryKeyState.LEARNING_SELECTED:
        //                 LearningSelected();
        //                 break;
        //             case EPrimaryKeyState.LEARNING_ACTIVE_MENU_BUTTON:
        //                 LearningActiveMenuButton();
        //                 break;
        //             case EPrimaryKeyState.LEARNING_STATE_ENTER_MODE:
        //                 LearningStateEnterMode();
        //                 break;
        //
        //         }
        //     }
        //
        //     private void LearningStateEnterMode()
        //     {
        //
        //         primaryKeyState = EPrimaryKeyState.LEARNING_STATE_ENTER_MODE;
        //         
        //         if (learningStateUndoShortcut != null)
        //         {
        //             if (KeyName != "Q")
        //             {
        //                 var textGroup = GetComponentsInChildren<TextMeshProUGUI>();
        //
        //                 AnimationManager.FadeTextMeshPro(textGroup);
        //
        //                 if (GetComponentInChildren<Image>() != null)
        //                 {
        //                     var images = GetComponentsInChildren<Image>();
        //                     AnimationManager.FadeImages(images);
        //                 }
        //             }
        //             else
        //             {
        //                 var textGroup = GetComponentsInChildren<TextMeshProUGUI>();
        //                 foreach (var text in textGroup)
        //                 {
        //                     text.DOText("Back to Shortcut", 1f);
        //                     // text.DOFade(0.75f, 1f);
        //                 }
        //             }
        //         }
        //         
        //         
        //     }
        //
        //     private void LearningStateEntry()
        //     {
        //
        //         var sequence = DOTween.Sequence();
        //
        //
        //         if (keyName == "G")
        //         {
        //             var renderers = GetComponentsInChildren<MeshRenderer>();
        //
        //             foreach (var rend in renderers)
        //             {
        //                 rend.material.DOColor(Color.black, 1f);
        //             }
        //         }
        //         
        //         if (learningStateUndoShortcut != null)
        //         {
        //             sequence.AppendCallback(() =>
        //             {
        //                 AnimationManager.AnimateLearningModeShortcut(this, learningStateUndoShortcut);
        //             });
        //         }else if (KeyName == "Z")
        //         {
        //             sequence.AppendInterval(4);
        //             sequence.AppendCallback(() =>
        //             {
        //                 AnimationManager.ApplyKeyOutlineToPrimary(this);
        //             });
        //         }
        //         else
        //         {
        //             var textGroup = GetComponentsInChildren<TextMeshProUGUI>();
        //             sequence.AppendCallback(() =>
        //             { 
        //                 AnimationManager.FadeTextMeshPro(textGroup);
        //             });
        //
        //             if (GetComponentInChildren<Image>() != null)
        //             {
        //                 var images = GetComponentsInChildren<Image>();
        //                 sequence.AppendCallback(() =>  AnimationManager.FadeImages(images));
        //             }
        //
        //         }
        //     }
        //     
        //     
        //     private void LearningActiveMenuButton()
        //     {
        //         primaryKeyState = EPrimaryKeyState.LEARNING_ACTIVE_MENU_BUTTON;
        //         var rend = GetComponentInChildren<Renderer>();
        //         rend.material.DOColor(Color.white, 0.2f);
        //
        //         
        //     }
        //
        //     private void LearningWelcome()
        //     {
        //
        //         primaryKeyState = EPrimaryKeyState.LEARNING_WELCOME;
        //         
        //         var textGroup = GetComponentsInChildren<TextMeshProUGUI>();
        //
        //         if (keyName == "Space")
        //         {
        //             foreach (var text in textGroup)
        //             {
        //                 // text.DOText("Learning Mode", 3f, scrambleMode: ScrambleMode.Uppercase);
        //                 text.DOFade(1, 4f);
        //             }
        //         }else if (keyName == "G")
        //         {
        //             var sequence = DOTween.Sequence();
        //             sequence.Pause();
        //             
        //             var shortcut = KeyColorManager.InstantiateShortcut(this, learningStateWelcomeShortcut);
        //             var shortcutImage = shortcut.GetComponentInChildren(typeof(Image), false) as Image;
        //             
        //             sequence.Append(_textMesh.DOFade(0f, 0f));
        //             sequence.Append(shortcutImage.DOFade(1f, 3.24f).SetEase(Ease.InSine));
        //
        //             sequence.Play();
        //         }
        //         else
        //         {
        //             if (textGroup != null)
        //             {
        //                 foreach(var text in textGroup)
        //                 {
        //                     text.DOText(keyName, 4f, scrambleMode: ScrambleMode.Uppercase);
        //                     text.DOFade(.1f, 2.3f);
        //                 } 
        //             }
        //         }
        //         
        //         
        //         if (GetComponentInChildren<Image>() != null)
        //         {
        //             var image = GetComponentInChildren<Image>();
        //             image.DOFade(.1f, 1.3f);
        //         }
        //         
        //     }
        //
        //     private void LearningSelected()
        //     {
        //         primaryKeyState = EPrimaryKeyState.LEARNING_SELECTED;
        //
        //         var rend = GetComponentInChildren<Renderer>();
        //         rend.material.DOColor(Color.yellow, 2f);
        //     }
        //
        //     private void LearningAvailable()
        //     {
        //         primaryKeyState = EPrimaryKeyState.LEARNING_AVAILABLE;
        //         keyOutline.gameObject.SetActive(true);        
        //         // var rend = GetComponentInChildren<Renderer>();
        //         // rend.material.DOColor(Color.white, 2f);
        //     }
        //
        //     private void LearningHelper()
        //     {
        //         primaryKeyState = EPrimaryKeyState.LEARNING_HELPER;
        //
        //         var rend = GetComponentInChildren<Renderer>();
        //         rend.material.DOColor(Color.red, 2f);
        //     }
        //
        //     private void LearningShowcase()
        //     {
        //         primaryKeyState = EPrimaryKeyState.LEARNING_SHOWCASE;
        //
        //         var rend = GetComponentInChildren<Renderer>();
        //         rend.material.DOColor(Color.cyan, 2f);
        //         // KeyColorManager.ChangeKeyColor(this, Color.cyan);
        //     }
        //
        //     private void DefaultState()
        //     {
        //         primaryKeyState = EPrimaryKeyState.DEFAULT;
        //         KeyColorManager.ChangeKeyColor(this, Color.black);
        //     }
        //
        //
        //     private void AnimationPause()
        //     {
        //         primaryKeyState = EPrimaryKeyState.ANIMATION_PAUSE;
        //     }
        //     
        //     private void AnimationPlay()
        //     {
        //         primaryKeyState = EPrimaryKeyState.ANIMATION_PLAY;
        //     }
        //
        //     private void Unavailable()
        //     {
        //         primaryKeyState = EPrimaryKeyState.UNAVAILABLE;
        //         var textGroup = GetComponentsInChildren<TextMeshProUGUI>();
        //
        //         if (textGroup != null)
        //         {
        //             foreach(var text in textGroup)
        //             {
        //                 text.DOFade(.1f, 1.3f);
        //             } 
        //         }
        //
        //         //this is in learning mode welcome
        //         
        //
        //         
        //         
        //         
        //
        //         if (GetComponentInChildren<Image>() != null)
        //         {
        //             var image = GetComponentInChildren<Image>();
        //             image.DOFade(.1f, 1.3f);
        //         }
        //     }
        //     
        //     private void TypingOn()
        //     {
        //         primaryKeyState = EPrimaryKeyState.TYPING_ON;
        //         KeyColorManager.ChangeKeyColor(this, Color.white);
        //     }
        //     
        //     private void TypingOff()
        //     {
        //         primaryKeyState = EPrimaryKeyState.TYPING_OFF;
        //         KeyColorManager.ChangeKeyColor(this, Color.black);
        //     }
        //      // Debug.Log("Typing shortcut called");
        //      //    if (keyState == EKeyState.KEY_PRESSED)
        //      //    {
        //      //        KeyColorManager.ChangeKeyColor(key, Color.gray);
        //      //    }else if (keyState == EKeyState.KEY_UNPRESSED)
        //      //    {
        //      //        var originalColor = Color.black;
        //      //        KeyColorManager.ChangeKeyColor(key, originalColor);
        //      //    }
        //     
        // }
    }
}
