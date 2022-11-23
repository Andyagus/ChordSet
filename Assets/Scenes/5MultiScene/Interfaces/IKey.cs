using UnityEngine;

namespace Interfaces
{
    public interface IKey
    {
        public string KeyName
        {
            get;
            set;
        }

        public KeyCode KeyCode
        {
            get;
            set;
        }
    }
}
