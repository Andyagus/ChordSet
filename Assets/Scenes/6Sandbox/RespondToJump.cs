using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public class RespondToJump : MonoBehaviour, IObserver
{
    private Jump _jump;
    private Jump2 _jump2;
    
    private void Awake()
    {
        _jump = GetComponent<Jump>();
        _jump2 = GetComponent<Jump2>();
    }

    private void Start()
    {
        _jump.jumpSubject.AddObserver(this);
        _jump2.jumpSubject.AddObserver(this);
    }

    public void OnNotify(object entity)
    {
        Debug.Log("Notified about the jump" + entity.GetType());
    }
    
}
