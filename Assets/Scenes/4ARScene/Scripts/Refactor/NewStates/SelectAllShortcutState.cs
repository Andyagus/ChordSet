using System.Collections;
using System.Collections.Generic;
using AR_Keyboard;
using AR_Keyboard.State;
using DG.Tweening;
using DG.Tweening.Core;
using Enums;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class SelectAllShortcutState : ARKeyboardState
{
   private GameObject _screenSpaceUI;
   
   [SerializeField] private GameObject videoPlayer;
   [SerializeField] private RenderTexture renderTexture;

   private Image _fullscreenPanel;

   [SerializeField] private Sprite selectAllSprite;

   private Sequence _showcaseSequence;

   private Transform _localCanvas;
   private ShortcutSuccessPanel _shortcutSuccessPanel;
   private bool _cmdPressed;
   private bool _shiftPressed;
   private bool _aPressed;
   private bool _shortcutComplete;

   public override void Entry(ARKeyboard keyboard)
   {

      _localCanvas = keyboard.ARScreen.gameObject.transform.Find("Canvas");
      _shortcutSuccessPanel = _localCanvas.GetComponentInChildren<ShortcutSuccessPanel>();

      DisplaySequence(keyboard);
      
      
   }

   private void DisplaySequence(ARKeyboard keyboard)
   {
      _showcaseSequence = DOTween.Sequence();
      
      _showcaseSequence.AppendCallback(() =>
      {
         FadeOutKeys(keyboard);
      });
      

      _showcaseSequence.AppendCallback(() =>
      {
         ChangeUIText(keyboard);
      });


      _showcaseSequence.AppendInterval(3f);
      
      _showcaseSequence.AppendCallback(() =>
      {
         SetNewOutlines(keyboard);
      });
      
      _showcaseSequence.AppendInterval(0.7f);
      
      _showcaseSequence.AppendCallback(() =>
      {
         ScreenFade(keyboard);
      });
        
      _showcaseSequence.AppendInterval(0.34f);
      
      _showcaseSequence.AppendCallback(() =>
      {
         ShowVideoPlayer(keyboard);
      });
        

      _showcaseSequence.AppendCallback(() =>
      {
         videoPlayer.GetComponent<VideoPlayer>().Play(); 
      });
      
      _showcaseSequence.AppendInterval(2.5792473f);

      
      _showcaseSequence.AppendCallback(() =>
      {
         KeyFollow(keyboard);
      });
      
      _showcaseSequence.AppendInterval(5.23f);

      _showcaseSequence.AppendCallback(() =>
      {
         ScreenFadeOut(keyboard);
      });

      _showcaseSequence.AppendCallback(() =>
      {
         HideVideoPlayer(keyboard);
      });
      
   }

   private void ScreenFadeOut(ARKeyboard keyboard)
   {
      _fullscreenPanel = _localCanvas.gameObject.transform.Find("Fullscreen-panel").GetComponent<Image>();
      _fullscreenPanel.DOFade(0f, 3f);

   }

   private void HideVideoPlayer(ARKeyboard keyboard)
   {
      keyboard.ARScreen.ChangeScreenState(ARKeyboardScreen.EScreenState.INACTIVE);

      videoPlayer = Instantiate(videoPlayer, this.transform);
      videoPlayer.transform.position = Vector3.zero;
      var rawImage = keyboard.ARScreen.GetComponentInChildren<RawImage>();
      rawImage.texture = renderTexture;
   }


   private void KeyFollow(ARKeyboard keyboard)
   {
      var localSequence = DOTween.Sequence();

      localSequence.Pause();
      
      foreach (var modifier in keyboard.modifierKeys)
      {
         if (modifier.KeyName == "command-left")
         {
            localSequence.AppendCallback(() =>
            {
               modifier.keyPressed = EKeyState.KEY_PRESSED;
            });
         }
         if (modifier.KeyName == "shift-left")
         {
            localSequence.AppendInterval(1f);
            localSequence.AppendCallback(() =>
            {
               modifier.keyPressed = EKeyState.KEY_PRESSED;
            });
         }
      }

      foreach (var primaryKey in keyboard.primaryKeys)
      {
         if (primaryKey.KeyName == "A")
         {
            localSequence.AppendInterval(1.12973f);
            localSequence.AppendCallback(() =>
            {
               primaryKey.keyPressed = EKeyState.KEY_PRESSED;
            });
         }
      }

      localSequence.AppendInterval(2f);
      foreach (var modifier in keyboard.modifierKeys)
      {
         if (modifier.KeyName == "command-left")
         {
            localSequence.AppendCallback(() =>
            {
               modifier.keyPressed = EKeyState.KEY_UNPRESSED;
            });
         }
         if (modifier.KeyName == "shift-left")
         {
            localSequence.AppendCallback(() =>
            {
               modifier.keyPressed = EKeyState.KEY_UNPRESSED;
            });
         }
      }

      foreach (var primaryKey in keyboard.primaryKeys)
      {
         if (primaryKey.KeyName == "A")
         {
            localSequence.AppendCallback(() =>
            {
               primaryKey.keyPressed = EKeyState.KEY_UNPRESSED;
            });
         }
      }
      
      localSequence.Play();
   }

   private void SetNewOutlines(ARKeyboard keyboard)
   {
      foreach (var modifierKey in keyboard.modifierKeys)
      {
         if (modifierKey.KeyName == "command-left")
         {
            modifierKey.keyAvailability = KeyAvailabilityState.EKeyAvailability.AVAILABLE;
            modifierKey.keyOutline = KeyOutlineState.EKeyOutline.OUTLINE;
         }

         if (modifierKey.KeyName == "shift-left")
         {
            modifierKey.keyAvailability = KeyAvailabilityState.EKeyAvailability.AVAILABLE;
            modifierKey.keyOutline = KeyOutlineState.EKeyOutline.OUTLINE;
         }
      }

      foreach (var primaryKey in keyboard.primaryKeys)
      {
         if (primaryKey.KeyName == "A")
         {
            primaryKey.keyAvailability = KeyAvailabilityState.EKeyAvailability.AVAILABLE;
            primaryKey.keyOutline = KeyOutlineState.EKeyOutline.OUTLINE;
         }
      }   }

   private void ChangeUIText(ARKeyboard keyboard)
   {
      _screenSpaceUI = GameObject.Find("ScreenSpaceUI");
      var text = _screenSpaceUI.GetComponentInChildren<TextMeshProUGUI>();
      text.DOText("Select All", 1f, scrambleMode: ScrambleMode.None);

   }


   private void FadeOutKeys(ARKeyboard keyboard)
   {
      foreach (var key in keyboard.keys)
      {
         key.keyOutline = KeyOutlineState.EKeyOutline.NO_OUTLINE;

         key.keyAvailability = KeyAvailabilityState.EKeyAvailability.UNAVAILABLE;
         // if (key.KeyName == "command-left")
         // {
         //    key.keyAvailability = KeyAvailabilityState.EKeyAvailability.UNAVAILABLE;            
         // }
         // if (key.KeyName == "Z")
         // {
         //    key.keyAvailability = KeyAvailabilityState.EKeyAvailability.UNAVAILABLE;
         // }
      }

   }
   
   private void ShowVideoPlayer(ARKeyboard keyboard)
   {
      keyboard.ARScreen.ChangeScreenState(ARKeyboardScreen.EScreenState.ACTIVE);

      videoPlayer = Instantiate(videoPlayer, this.transform);
      videoPlayer.transform.position = Vector3.zero;
      var rawImage = keyboard.ARScreen.GetComponentInChildren<RawImage>();
      rawImage.texture = renderTexture;
   }
   
   private void ScreenFade(ARKeyboard keyboard)
   {
      _fullscreenPanel = keyboard.ARScreen.gameObject.transform.Find("Canvas").gameObject
         .transform.Find("Fullscreen-panel").GetComponent<Image>();
      _fullscreenPanel.DOFade(0.5f, 3f);
   }

   public override ARKeyboardState HandleInput(Key key, ARKeyboard keyboard)
   {
      
      
      if (key.KeyName == "command-left" && key.keyPressed == EKeyState.KEY_PRESSED)
      {
         _cmdPressed = true;
      }
      if (key.KeyName == "shift-left" && key.keyPressed == EKeyState.KEY_PRESSED)
      {
         _shiftPressed = true;
      }
      if (key.KeyName == "A" && key.keyPressed == EKeyState.KEY_PRESSED)
      {
         _aPressed = true;
      }

      if (_cmdPressed && _shiftPressed && _aPressed)
      {
         if (!_shortcutComplete)
         {
            var completionSequence = DOTween.Sequence();
            completionSequence.Pause();
            completionSequence.AppendCallback(() =>
            {
               _shortcutSuccessPanel.SetShortcutSuccessPopUpState(ShortcutSuccessPanel.EShortcutSuccessPopUp.AVAILABLE,
                  selectAllSprite, "Select All");
            });
            completionSequence.AppendInterval(2f);
            completionSequence.AppendCallback(() =>
            {
               _shortcutSuccessPanel.SetShortcutSuccessPopUpState(ShortcutSuccessPanel.EShortcutSuccessPopUp.UNAVAILABLE, null, null);
            });
            
            completionSequence.Play();
         }
         
         
      }
      
      if (key.KeyName == "U" && key.keyPressed == EKeyState.KEY_PRESSED)
      {
         DisplaySequence(keyboard);
      }

      return null;
   }
}
