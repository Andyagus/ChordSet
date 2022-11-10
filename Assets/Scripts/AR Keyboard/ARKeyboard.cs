using System;
using System.Collections;
using System.Collections.Generic;
using Desktop;
using Interfaces;
using Normcore;
using UnityEngine;

public class ARKeyboard : MonoBehaviour, IObserver
{
    private MockNormcore _normcore;

    private void Awake()
    {
        _normcore = GameObject.Find("Normcore").GetComponent<MockNormcore>();
    }

    private void Start()
    {
        _normcore.normcoreModelUpdated.AddObserver(this);
    }

    public void OnNotify(object entity)
    {
        var inputKey = (InputKey)entity; 
        Debug.Log("Update state machine with: " + inputKey);
    }
}
