using System;
using System.Collections;
using System.Collections.Generic;
using AR_Keyboard;
using Enums;
using Normal.Realtime;
using UnityEngine;

public class KeySync : RealtimeComponent<KeySyncModel>
{
    // ReSharper disable InconsistentNaming
    private ARKeyboard _ARKeyboard; 
    // ReSharper restore InconsistentNaming


    private void Start()
    {
        //need conditional here for only mobile app
        _ARKeyboard = FindObjectOfType<ARKeyboard>();
    }

    protected override void OnRealtimeModelReplaced(KeySyncModel previousModel, KeySyncModel currentModel)
    {
        currentModel.keyStateDidChange += OnKeyStateChange;
    }

    private void OnKeyStateChange(KeySyncModel keySyncModel, EKeyState value)
    {
        HandleKeyState();
    }
   
    public void SetNewKey(string keyName, EKeyState eKeyState)
    {
        model.keyName = keyName;
        model.keyState = eKeyState;
    }

    private void HandleKeyState()
    {
        _ARKeyboard.OnKeyReceived(model.keyName, model.keyState);
        // Debug.Log($"New Key Set: {model.keyName}, {model.keyState}");
    }

}
