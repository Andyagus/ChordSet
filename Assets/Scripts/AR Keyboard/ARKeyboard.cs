using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AR_Keyboard;
using AR_Keyboard.State;
using Desktop;
using Interfaces;
using Normcore;
using UnityEngine;

public class ARKeyboard : MonoBehaviour, IObserver
{
    private MockNormcore _normcore;
    private ARKeyboardState _state;
    
    //convenience list for instantiation
    public List<ARKeyboardState> states;
    
    public List<ARKey> ARPrimaryKeys;
    public List<ARKey> ARModifierKeys;

    private void Awake()
    {
        _normcore = GameObject.Find("Normcore").GetComponent<MockNormcore>();
        ARPrimaryKeys = GetComponentsInChildren<ARPrimaryKey>().ToList<ARKey>();
        ARModifierKeys = GetComponentsInChildren<ARModifierKey>().ToList<ARKey>();
        _state = Instantiate(states[0], this.transform, true);
        _state.Entry(this);
    }

    private void Start()
    {
        _normcore.normcoreModelUpdated.AddObserver(this);
    }

    public void OnNotify(object entity)
    {
        var inputKey = (InputKey)entity; 
        // Debug.Log("Update state machine with: " + inputKey);

        _state.HandleInput(inputKey, this);
    }
}