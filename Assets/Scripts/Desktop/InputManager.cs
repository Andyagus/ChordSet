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
            // _normcore = GameObject.Find("Normcore").GetComponent<MockNormcore>();

            _inputKeys = GetComponentsInChildren<InputKey>().ToList<InputKey>();
        }

        private void Start()
        {
            _keySyncDictionary = GameObject.FindObjectOfType<KeySyncDictionary>();

            foreach (var key in _inputKeys)
            {
                key.onKeyChanged.AddObserver(this);
            }

            //TODO this is not great.
            StartCoroutine(AddToDictionary());


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

            // _keySync.SetNewKey(inputKey.KeyName, inputKey.keyState);
            
            
            // _normcore.UpdateNormcoreModel(inputKey);
            
            //Removed this dictionary because requires keeping track of every key
            // InputKey inputKey = (InputKey)entity;
            //
            // if (inputKeyDict.ContainsKey(inputKey))
            // {
            //     Debug.Log("Don't have input key!");
            // }
            // if((InputKey)entity)
            // inputKeyDict.Add((InputKey)entity, true);
            // Debug.Log(inputKeyDict.Count);
        }
    }
}
