using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AR_Keyboard
{
    public class Shortcut : MonoBehaviour
    {
        public string shortcutName;
        //image might require canvas...
        public Image shortcutImage; 
        // public Canvas shortcutGraphic;
        public TextMeshProUGUI textMeshPro;

        private void Awake()
        {
            textMeshPro.text = shortcutName;
        }

        public virtual void Execute()
        {
        
        }
    }
}
