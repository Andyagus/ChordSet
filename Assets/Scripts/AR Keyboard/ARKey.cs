using Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace AR_Keyboard
{
    public class ARKey : MonoBehaviour, IKey
    {
        [SerializeField] private string keyName;
        public string KeyName
        {
            get => keyName;
            set => keyName = value;
        }

        [SerializeField] private KeyCode keyCode;
        public KeyCode KeyCode
        {
            get => keyCode;
            set => keyCode = value;
        }

        public List<Shortcut> shortcuts;
        
        public Subject onPrimaryKeyHit;
    
        private void Awake()
        {
            onPrimaryKeyHit = new Subject();
        }
    }
}
