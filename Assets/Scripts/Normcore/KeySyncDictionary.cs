using System;
using System.Collections;
using System.Collections.Generic;
using AR_Keyboard;
using Desktop;
using Enums;
using UnityEngine;
using Normal.Realtime;
using Normal.Realtime.Serialization;
using Normcore;

public class KeySyncDictionary : RealtimeComponent<KeySyncDictionaryModel>
{

    public ARKeyboard _ARKeyboard;
    // public Action<Dictionary<KeyCode, KeySyncModel>> OnKeyDictionaryChanged;
    
    protected override void OnRealtimeModelReplaced(KeySyncDictionaryModel previousModel, KeySyncDictionaryModel currentModel)
    {
        currentModel.realtimeDictionary.modelAdded += OnModelAdded;
        currentModel.realtimeDictionary.modelReplaced += OnModelReplaced;
    }


    private void OnModelAdded(RealtimeDictionary<KeySyncModel> dictionary, uint key, KeySyncModel keySyncModel, bool remote)
    {
        // Debug.Log("On model added");
    }

    private void OnModelReplaced(RealtimeDictionary<KeySyncModel> dictionary, uint key, KeySyncModel oldmodel, KeySyncModel newmodel, bool remote)
    {
        // #if !UNITY_EDITOR
        _ARKeyboard = GameObject.FindObjectOfType<ARKeyboard>();
        if (_ARKeyboard != null)
        {
            _ARKeyboard.OnKeyDictionaryReceived(model.realtimeDictionary);
        }
        // #endif
        
        // Debug.Log("On model replaced");
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
    }

    public void SetDictionary(InputKey inputKey)
    {
        var key = new KeySyncModel();
        key.keyName = inputKey.KeyName;
        key.keyState = inputKey.keyState;

        if (model.realtimeDictionary.ContainsKey((uint)inputKey.KeyCode))
        {
            model.realtimeDictionary[(uint)inputKey.KeyCode] = key;
        }

    }
    
}
