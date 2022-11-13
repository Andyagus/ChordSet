using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AR_Keyboard;
using Enums;
using Interfaces;
using UnityEngine;

public class AudioManager : MonoBehaviour, IObserver
{
    private AudioSource _audioSource;
    private List<ARPrimaryKey> _primaryKeys;
    [SerializeField] private AudioClip bellClip;
    
    
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
        switch (shortcut.eShortcut)
        {
            case EShortcuts.CUT_SHORTCUT:
                _audioSource.clip = bellClip;
                _audioSource.Play();
                break;
        }
        // entity.
    }
}
