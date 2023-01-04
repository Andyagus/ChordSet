using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoState : MonoBehaviour
{
   
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
      rawImage.DOFade(0, 2f);
   }

   private void DisplayVideo(RenderTexture renderTexture, VideoClip clip)
   {
      if (rawImage.color.a == 0)
      {
         rawImage.DOFade(1, 0.5f);
      }
      rawImage.texture = renderTexture;
      videoPlayer.targetTexture = renderTexture;
      videoPlayer.clip = clip;
      
      //wait time and play video? 
   }
   
}
