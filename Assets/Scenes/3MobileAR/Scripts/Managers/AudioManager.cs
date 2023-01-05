using System.Collections.Generic;
using AR_Keyboard;
using Scenes._3MobileAR.Scripts.Keyboard;
using Scenes._3MobileAR.Scripts.Keys.Primary_Key;
using Scenes._3MobileAR.Scripts.Keys.Shortcuts;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource _audioSource;
    private ARKeyboard _arKeyboard;
    private List<ARPrimaryKey> _primaryKeys;
    [SerializeField] private AudioClip bellClip;
    
    
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _arKeyboard = FindObjectOfType<ARKeyboard>();

        _arKeyboard.onAmbientStateChanged += OnStateChanged;
    }

    private void OnStateChanged(ARKeyboardState arKeyboardState)
    {
        foreach (var primaryKey in _arKeyboard.primaryKeys)
        {
            if (primaryKey.currentShortcut != null)
            {
                primaryKey.currentShortcut.onShortcutExecuted += OnShortcutExecuted;
            }
        }
    }

    private void OnShortcutExecuted(Shortcut shortcut)
    {
        switch (shortcut.eShortcut)
        {
            case Shortcut.EShortcuts.CUT:
                _audioSource.clip = bellClip;
                _audioSource.Play();
                break;
            case Shortcut.EShortcuts.UNDO:
                _audioSource.clip = bellClip;
                _audioSource.Play();
                break;
            //add print sound here
        }    
    }
}
