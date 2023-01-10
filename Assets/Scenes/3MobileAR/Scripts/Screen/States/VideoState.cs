using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace Scenes._3MobileAR.Scripts.Screen.States
{
   /// <summary>
   /// This class swapped render textures and played appropriate video in AR over the text
   /// editor app.  Although this is not part of current implementation I would like to
   /// explore in the future.   Unfortunately I removed the videos from the project //TODO: Get videos back  
   /// </summary>
   public class VideoState : MonoBehaviour
   {
      [SerializeField] private float fadeInAmt = 1;
      [SerializeField] private float fadeOutAmt = 0;
      [SerializeField] private float fadeInTime = 0.5f;
      [SerializeField] private float fadeOutTime = 2f;
      public enum EVideoState
      {
         NONE,
         UNDO,
         SELECT_ALL
      }
   
      //Using new renderTexture for each because the renderTexture
      //caches an image preview of the video after first play
      [SerializeField] private RawImage rawImage;
      [SerializeField] private VideoPlayer videoPlayer;
      [SerializeField] private RenderTexture undoShortcutRenderTexture;
      [SerializeField] private VideoClip undoShortcutVideo;
      [SerializeField] private RenderTexture selectAllShortcutRenderTexture;
      [SerializeField] private VideoClip selectAllShortcutVideo;

      public void SetVideoState(EVideoState state)
      {
         switch (state)
         {
            case EVideoState.NONE:
               None();
               break;
            case EVideoState.UNDO:
               DisplayVideo(undoShortcutRenderTexture, undoShortcutVideo);
               break;
            case EVideoState.SELECT_ALL:
               DisplayVideo(selectAllShortcutRenderTexture, selectAllShortcutVideo);
               break;
            default:
               throw new ArgumentOutOfRangeException(nameof(state), state, null);
         }
      }
   
      private void None()
      {
         rawImage.DOFade(fadeOutAmt, fadeOutTime);
      }

      private void DisplayVideo(RenderTexture renderTexture, VideoClip clip)
      {
         //TODO not a great check to see if it's faded out - use a bool 
         if (rawImage.color.a == 0)
         {
            rawImage.DOFade(fadeInAmt, fadeInTime);
         }
         rawImage.texture = renderTexture;
         videoPlayer.targetTexture = renderTexture;
         videoPlayer.clip = clip;
      }
   
   }
}
