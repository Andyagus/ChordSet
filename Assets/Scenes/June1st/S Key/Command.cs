using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Command : MonoBehaviour
{
   private ActionType? _prevActionType;
   public ActionType actionType;
   public Color commandColor;
   public string title;
   public string letter;
   public Sprite logo;
   public Mods modToAccess;

   private void Awake()
   {
      SwitchAction();
      // color = Color.red;
      // _prevActionType = null;
   }

   private void Update()
   {

      // if (_prevActionType != actionType)
      // {
      //    SwitchAction();
      //    _prevActionType = actionType;
      // }
   }

   private void SwitchAction()
   {
      switch (actionType)
      {
         case ActionType.ESelectionTool:
            // commandColor = ColorPicker.Orange;
            break;
         case ActionType.EManipulationTool:
            // commandColor = ColorPicker.Blue;
            break;
         case ActionType.EColorTool:
            // commandColor = ColorPicker.Purple;
            break;
         default:
            throw new ArgumentOutOfRangeException();
      }
   }
}
