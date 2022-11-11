using Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AR_Keyboard
{
    //maybe implement subscriber observer here
    public class Shortcut : MonoBehaviour
    {
        public string shortcutName;
        public Image shortcutImage;
        public TextMeshProUGUI textMeshPro;

        public Subject onShortcutExecuted;
        
        private void Awake()
        {
            onShortcutExecuted = new Subject();
            textMeshPro.text = shortcutName;
        }

        public virtual void Execute() {}
    }
}
