using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AR_Keyboard;
using Interfaces;
using UnityEditor;
using UnityEngine;

public class AudioManager : MonoBehaviour, IObserver
{
    private AudioSource _audioSource;
    private List<ARPrimaryKey> _primaryKeys;
    
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _primaryKeys = GameObject.Find("AR Keyboard").GetComponentsInChildren<ARPrimaryKey>().ToList();
    }

    private void Start()
    {
        foreach (var primaryKey in _primaryKeys)
        {
            primaryKey.onPrimaryKeyHit.AddObserver(this);
        }
    }

    public void OnNotify(object entity)
    {
        Shortcut shortcut = (Shortcut)entity;
        // entity.
    }
}
