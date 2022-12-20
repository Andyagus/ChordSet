using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSpaceUI : MonoBehaviour
{
   [Header("Panel State")] 
   public PanelState.EPanelState panelState;
   private PanelState.EPanelState _previousPanelState;
   private PanelState _panelState;

   
   private void Awake()
   {
      _panelState = GetComponent<PanelState>();
   }

   private void Update()
   {
      if (panelState != _previousPanelState)
      {
         _panelState.SetPanelState(panelState);
         _previousPanelState = panelState;
      }
   }
}
