using Interfaces;
using UnityEngine;

namespace Desktop
{
    public class InputKey : MonoBehaviour, IKey
    {
        [SerializeField] private string _keyName;
        public Subject onKeyChanged;
        
        string IKey.KeyName
        {
            get => _keyName;
            set => _keyName = value;
        }

        [SerializeField] private KeyCode _keyCode;

        public KeyCode KeyCode
        {
            get => _keyCode;
            set => _keyCode = value;
        }
    }
}
