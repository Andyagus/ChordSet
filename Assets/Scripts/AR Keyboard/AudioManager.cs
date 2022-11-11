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
    private List<Shortcut> _shortcuts;
    
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _shortcuts = GameObject.Find("AR Keyboard").GetComponentsInChildren<Shortcut>().ToList();
    }

    private void Start()
    {
        foreach (var shortcut in _shortcuts)
        {
            shortcut.onShortcutExecuted.AddObserver(this);
        }
    }

    public void OnNotify(object entity)
    {
        Debug.Log(entity);
    }
}
