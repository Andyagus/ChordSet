using DG.Tweening;
using TMPro;
using UnityEngine;

namespace AR_Keyboard
{
    public class ARModifierKey : Key
    {

        private MeshRenderer _meshRenderer;
        private Color _originalColor;

        private Sequence _unavailableSequence;
        // public TextMeshProUGUI modifierText;

        public TextMeshProUGUI[] modifierTexts;
        
        public override void Awake()
        {
            modifierTexts = GetComponentsInChildren<TextMeshProUGUI>();
            _meshRenderer = GetComponentInChildren<MeshRenderer>();
            _originalColor = _meshRenderer.material.color;
            base.Awake();
        }
        
         public GameObject activeGlowGameObject;
         
        
         // public void ChangeLocalState(EModifierKeyState state)
         // {
         //     switch (state)
         //     {
         //         case EModifierKeyState.AVAILABLE:
         //             Available();
         //             break;
         //         case EModifierKeyState.ACTIVE:
         //             Active();
         //             break;
         //         case EModifierKeyState.UNAVAILABLE:
         //             Unavailable();
         //             break;
         //         case EModifierKeyState.DEFAULT:
         //             DefaultState();
         //             break;
         //         case EModifierKeyState.LEARNING_WELCOME:
         //             LearningWelcome();
         //             break;
         //         case EModifierKeyState.LEARNING_SHOWCASE:
         //             LearningShowcase();
         //             break;
         //         case EModifierKeyState.LEARNING_STATE_ENTRY:
         //             LearningStateEntry();
         //             break;
         //         case EModifierKeyState.LEARNING_AVAILABLE:
         //             LearningAvailable();
         //             break;
         //         case EModifierKeyState.LEARNING_SELECTED:
         //             LearningSelected();
         //             break;
         //         case EModifierKeyState.LEARNING_ACTIVE_MENU_BUTTON:
         //             LearningActiveMenuButton();
         //             break;
         //         case EModifierKeyState.LEARNING_ENTER_MODE:
         //             LearningEnterMode();
         //             break;
         //     }
         // }
         //
         // private void LearningEnterMode()
         // {
         //     throw new NotImplementedException();
         // }
         //
         // private void LearningStateEntry()
         // {
         //
         //     if (KeyName == "command-left")
         //     {
         //         var sequence = DOTween.Sequence();
         //         sequence.AppendInterval(3);
         //         sequence.AppendCallback(SetOutline);
         //     }
         //     else
         //     {
         //         var textGroup = GetComponentsInChildren<TextMeshProUGUI>();
         //
         //         // FadeText(TextMeshProUGUI text);
         //         foreach (var text in textGroup)
         //         {
         //             text.DOFade(0, 1.4f);
         //         }
         //         
         //         // FadeImage(Image image);
         //         if (GetComponentInChildren<Image>() != null)
         //         {
         //             var image = GetComponentInChildren<Image>();
         //             image.DOFade(.1f, 1.3f);
         //         }
         //     }
         //     
         // }
         //
         // private void SetOutline()
         // {
         //     _keyOutline.gameObject.SetActive(true);
         //     // _keyOutline.GetComponentInChildren<MeshRenderer>().material.DOFade(1, 2f);
         //     //fade it in
         //
         // }
         //
         // private void LearningActiveMenuButton()
         // {
         //     modifierState = EModifierKeyState.LEARNING_ACTIVE_MENU_BUTTON;
         // }
         //
         // private void LearningWelcome()
         // {
         //     modifierState = EModifierKeyState.LEARNING_WELCOME;
         //    
         //     var textGroup = GetComponentsInChildren<TextMeshProUGUI>();
         //     
         //     if (textGroup != null)
         //     {
         //         foreach(var text in textGroup)
         //         {
         //             text.DOText(keyName, 4f, scrambleMode: ScrambleMode.Uppercase);
         //             text.DOFade(.1f, 2.3f);
         //         } 
         //     }
         //
         //     if (GetComponentInChildren<Image>() != null)
         //     {
         //         var image = GetComponentInChildren<Image>();
         //         image.DOFade(.1f, 1.3f);
         //     }         
         // }
         //
         // private void LearningSelected()
         // {
         //     modifierState = EModifierKeyState.LEARNING_AVAILABLE;
         //     var rend = GetComponentInChildren<MeshRenderer>();
         //     rend.material.DOColor(Color.yellow, 2f);
         // }
         //
         // private void LearningAvailable()
         // {
         //     modifierState = EModifierKeyState.LEARNING_AVAILABLE;
         //     var rend = GetComponentInChildren<MeshRenderer>();
         //     rend.material.DOColor(Color.white, 2f);
         // }
         //
         // private void LearningShowcase()
         // {
         //     modifierState = EModifierKeyState.LEARNING_SHOWCASE;
         //     var rend = GetComponentInChildren<MeshRenderer>();
         //     rend.material.DOColor(Color.cyan, 2f);
         //
         // }
         //
         // private void DefaultState()
         // {
         //     modifierState = EModifierKeyState.DEFAULT;
         //     var rend = GetComponentInChildren<MeshRenderer>();
         //     rend.material.DOColor(Color.black, 0.34f);
         // }
         //
         // private void Available()
         // {
         //     modifierState = EModifierKeyState.AVAILABLE;
         //     var rend = GetComponentInChildren<MeshRenderer>();
         //     rend.material.DOColor(Color.yellow, 0.34f);
         //     // var glow = Instantiate(activeGlowGameObject, transform);
         //     // glow.transform.position = transform.position;
         // }
         //
         // private void Unavailable()
         // {
         //     modifierState = EModifierKeyState.UNAVAILABLE;
         //     StartCoroutine(FadeOutKeys());
         // }
         //
         // private void Active()
         // {
         //     modifierState = EModifierKeyState.ACTIVE;
         //     var rend = GetComponentInChildren<MeshRenderer>();
         //     rend.material.DOColor(Color.white, 0.74652f);
         // }
         //
         // private IEnumerator FadeOutKeys()
         // {
         //     //for editor hiccups
         //     yield return new WaitForSeconds(0.1f);
         //     _unavailableSequence = DOTween.Sequence();
         //
         //     foreach (var text in modifierTexts)
         //     {
         //        _unavailableSequence.Insert(0, text.DOFade(0.1f, 1f));
         //     }
         //     
         //     if (GetComponentInChildren<Image>() != null)
         //     {
         //         var image = GetComponentInChildren<Image>();
         //         image.DOFade(.1f, 1.3f);
         //     }
         //     
         //     _unavailableSequence.SetAutoKill(false);
         // }
         //
         //

    }
}
