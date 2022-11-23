using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Interfaces;
using Normcore;
using UnityEngine;


namespace Desktop
{
    public class InputManager : MonoBehaviour, IObserver
    {
        private List<InputKey> _inputKeys;
        private KeySyncDictionary _keySyncDictionary;
        
        private void Awake()
        {
            _inputKeys = GetComponentsInChildren<InputKey>().ToList<InputKey>();
        }

        private void Start()
        {
            _keySyncDictionary = GameObject.FindObjectOfType<KeySyncDictionary>();
            
            

            
            //TODO this is not great.
            StartCoroutine(AddToDictionary());
            
            foreach (var key in _inputKeys)
            {
                key.onKeyChanged.AddObserver(this);
            }

        }
        
        public IEnumerator AddToDictionary()
        {
            yield return new WaitForSeconds(1);
            
            foreach (var key in _inputKeys)
            {
                _keySyncDictionary.CreateDictionary(key);
            }  
        }

        public void OnNotify(object entity)
        {
            var inputKey = (InputKey)entity;
            _keySyncDictionary.SetDictionary(inputKey);
        }
    }
}
