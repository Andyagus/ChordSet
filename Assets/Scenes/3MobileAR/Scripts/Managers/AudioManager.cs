using System.Collections.Generic;
using Scenes._3MobileAR.Scripts.Keyboard;
using Scenes._3MobileAR.Scripts.Keys.Primary_Key;
using Scenes._3MobileAR.Scripts.Keys.Shortcuts;
using UnityEngine;

namespace Scenes._3MobileAR.Scripts.Managers
{
    
    /// <summary>
    /// AudioManager subscribes to shortcut onShortcutExecuted and plays sounds when called
    /// </summary>
    public class AudioManager : MonoBehaviour
    {
        private AudioSource _audioSource;
        private ARKeyboard _ARKeyboard;

        //TODO: Add multiple clips here
        [SerializeField] private AudioClip bellClip;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _ARKeyboard = FindObjectOfType<ARKeyboard>();
            _ARKeyboard.onAmbientStateChanged += OnStateChanged;
        }

        /// <summary>
        /// Subscribing to on AmbientStateChanged.
        /// I architected like this because when new shortcut state is activated
        /// new shortcuts are placed on keys.  And at that point you want look through
        /// the active shortcuts on the keys and subscribe to their OnShortcutExecuted events
        ///
        /// TODO: This is not ideal, because you need to resubscribe to OnShortcutExecuted each time state changes.
        /// Refactor - Have shortcuts on their specific keys at start and subscribe once when app starts
        /// TODO: Need to unsubscribe from events on state chance too 
        /// </summary>
        
        private void OnStateChanged(ARKeyboardState arKeyboardState)
        {
            foreach (var primaryKey in _ARKeyboard.primaryKeys)
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
                //TODO Add more sounds here
                case Shortcut.EShortcuts.CUT:
                    _audioSource.clip = bellClip;
                    _audioSource.Play();
                    break;
                case Shortcut.EShortcuts.UNDO:
                    _audioSource.clip = bellClip;
                    _audioSource.Play();
                    break;
            }    
        }
    }
}
