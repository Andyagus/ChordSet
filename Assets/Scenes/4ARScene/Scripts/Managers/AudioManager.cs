using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AR_Keyboard;
using AR_Keyboard.State;
using Enums;
using Interfaces;
using UnityEngine;

public class AudioManager : MonoBehaviour, IObserver
{
    private AudioSource _audioSource;
    private ARKeyboard _arKeyboard;
    private List<ARPrimaryKey> _primaryKeys;
    [SerializeField] private AudioClip bellClip;
    
    
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _arKeyboard = FindObjectOfType<ARKeyboard>();
        _primaryKeys = FindObjectOfType<ARKeyboard>().GetComponentsInChildren<ARPrimaryKey>().ToList();

        foreach (var key in _primaryKeys)
        {
            // key.OnNewShortcut += OnNewShortcut;
        }
        
    }
    

    // private void OnKeyboardStateChange(ARKeyboardState obj)
    // {
    //     foreach(var key in _primaryKeys)
    // }

    public void OnNotify(object entity)
    {
        Shortcut shortcut = (Shortcut)entity;
        switch (shortcut.eShortcut)
        {
            case EShortcuts.CUT_SHORTCUT:
                _audioSource.clip = bellClip;
                _audioSource.Play();
                break;
            case EShortcuts.UNDO_SHORTCUT:
                _audioSource.clip = bellClip;
                _audioSource.Play();
                break;
        }
        // entity.
    }
}
