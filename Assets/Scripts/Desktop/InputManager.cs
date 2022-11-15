using System;
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

        private KeySync _keySync;
        
        private void Awake()
        {
            // _normcore = GameObject.Find("Normcore").GetComponent<MockNormcore>();

            _inputKeys = GetComponentsInChildren<InputKey>().ToList<InputKey>();
        }

        private void Start()
        {
            _keySync = GameObject.FindObjectOfType<KeySync>();

            foreach (var key in _inputKeys)
            {
                key.onKeyChanged.AddObserver(this);
            }
        }

        public void OnNotify(object entity)
        {
            var inputKey = (InputKey)entity;
            _keySync.SetNewKey(inputKey.name, inputKey.keyState);
            
            
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
