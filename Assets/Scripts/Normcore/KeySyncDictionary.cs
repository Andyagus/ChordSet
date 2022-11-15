using System;
using System.Collections;
using System.Collections.Generic;
using AR_Keyboard;
using Desktop;
using Enums;
using UnityEngine;
using Normal.Realtime;
using Normcore;

public class KeySyncDictionary : RealtimeComponent<KeySyncDictionaryModel>
{

    public ARKeyboard _ARKeyboard;
    // public Action<Dictionary<KeyCode, KeySyncModel>> OnKeyDictionaryChanged;
    
    protected override void OnRealtimeModelReplaced(KeySyncDictionaryModel previousModel, KeySyncDictionaryModel currentModel)
    {
        // currentModel.
    }

    private void Start()
    {
        _ARKeyboard = GameObject.FindObjectOfType<ARKeyboard>();
    }

    public void CreateDictionary(InputKey inputKey)
    {
        var key = new KeySyncModel();
        key.keyName = inputKey.KeyName;
        key.keyState = inputKey.keyState;
        if (!model.realtimeDictionary.ContainsKey((uint)inputKey.KeyCode))
        {
            model.realtimeDictionary.Add((uint)inputKey.KeyCode, key);
        }
        // model.realtimeDictionary.Add((uint) inputKey.KeyCode, key);
    }

    public void GetDictionary()
    {
        
    }    
    public void SetDictionary(InputKey inputKey)
    {
        // Debug.Log(model.realtimeDictionary);

        model.realtimeDictionary[(uint)inputKey.KeyCode].keyState = inputKey.keyState;

        # if !UNITY_EDITOR
            
        #endif
        if (_ARKeyboard != null)
        {
            _ARKeyboard.OnKeyDictionaryReceived((uint)inputKey.KeyCode, model.realtimeDictionary);
        }
        
        // Debug.Log("here");

    }

    private void SayHi()
    {
        Debug.Log("Hi");
    }
}
