using Interfaces;
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
    }
}
