using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Interfaces;
using Scenes._2Normcore.Scripts;
using UnityEngine;

namespace Scenes._1Desktop.Scripts
{
    /// <summary>
    /// Input Manager receives key press from input key events and sends the
    /// key to Normcore (network) to eventually be passed to AR Keyboard.
    /// </summary>
    
    public class InputManager : MonoBehaviour
    {
        private List<InputKey> _inputKeys;
        private KeySyncDictionary _keySyncDictionary;
        
        private void Awake()
        {
            _inputKeys = GetComponentsInChildren<InputKey>().ToList();
        }

        private void Start()
        {
            _keySyncDictionary = FindObjectOfType<KeySyncDictionary>();
            
            //The Coroutine waits for the KeySyncDictionary to be initialized before adding the keys
            StartCoroutine(AddToDictionary());
            
            foreach (var key in _inputKeys)
            {
                key.onKeyChanged += OnKeyChanged;
            }

        }
        
        private IEnumerator AddToDictionary()
        {
            yield return new WaitForSeconds(1);
            
            foreach (var key in _inputKeys)
            {
                _keySyncDictionary.CreateDictionary(key);
            }  
        }

        private void OnKeyChanged(InputKey inputKey)
        {
            _keySyncDictionary.SetDictionary(inputKey);
        }
    }
}
