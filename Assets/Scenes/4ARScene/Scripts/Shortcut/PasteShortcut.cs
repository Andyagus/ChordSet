using System;
using DG.Tweening;
using Enums;
using TMPro;
using UnityEditor;
using UnityEngine;

namespace AR_Keyboard.Shortcuts.Scripts
{
   public class PasteShortcut : Shortcut
   {

      private Sequence _executeSequence;
      private TextMeshProUGUI _mainKeyText
         ;
      public TextMeshProUGUI cLetterText;

      private CopyShortcut _copyShortcut;
      
      public override void Awake()
      {
         //THIS IS NOT IDEAL BECAUSE THERE ARE MULTIPLE TEXT MESHES
         _mainKeyText = GameObject.Find("V").GetComponentInChildren<TextMeshProUGUI>();
         _copyShortcut = GameObject.Find("C").GetComponentInChildren<CopyShortcut>();
         base.Awake();
      }

      private void Start()
      {
         _copyShortcut.onGraphicCopied += OnGraphicCopied;
      }

      private void OnGraphicCopied()
      {

         _mainKeyText.DOFade(1, 2.7f);
         // var keyText = GetComponentInParent<TextMeshProUGUI>();
         // keyText.DOFade(0f, 1f);
      }

      public override void Execute(ARPrimaryKey key)
      {


         if (_copyShortcut.graphicCopied)
         {
            _executeSequence = DOTween.Sequence();

            var newPos = new Vector3(0.0173f, 0.0026f, -.001f);
            var postPos = new Vector3(0.0187f, 0.0097f, -0.002f);
            
            _executeSequence.Append(_copyShortcut.stamp.DOLocalMove(newPos, 0.1f).SetEase(Ease.Linear))
               .Append(cLetterText.DOFade(1, 0f))
               .Append(_copyShortcut.stamp.DOLocalMove(postPos, 0.2f).SetEase(Ease.InSine));
         }
         base.Execute(key);
      }

      public override void StopSequence(ARPrimaryKey key)
      {
         if (_executeSequence != null)
         {
            _executeSequence.Pause();
            _executeSequence.Kill();
         }
         
         base.StopSequence(key);
      }

      public override void SetGraphics(ARPrimaryKey key)
      {
         _mainKeyText.DOFade(0.1f, 2f);

         base.SetGraphics(key);
      }
   }
}
