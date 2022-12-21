using System;
using System.Collections;
using System.Collections.Generic;
using AR_Keyboard;
using AR_Keyboard.State;
using UnityEngine;

public class ScreenSpaceUI : MonoBehaviour
{

   private ARKeyboard _arKeyboard;
   
   [Header("Panel State")] 
   public PanelState.EPanelState panelState;
   private PanelState.EPanelState _previousPanelState;
   private PanelState _panelState;

   private void Awake()
   {
      _arKeyboard = FindObjectOfType<ARKeyboard>();
      _panelState = GetComponent<PanelState>();
   }

   private void Start()
   {
      _arKeyboard.onLearningModeStateChanged += OnLearningModeStateChanged;
   }

   private void OnLearningModeStateChanged(ARKeyboardState state)
   {
      var learningModeState = state.GetComponent<LearningModeState>();
      _panelState.SetPanelState(PanelState.EPanelState.ACTIVE, learningModeState.shortcutName);
   }

   // private void Update()
   // {
   //    if (panelState != _previousPanelState)
   //    {
   //       _panelState.SetPanelState(panelState);
   //       _previousPanelState = panelState;
   //    }
   // }
}
