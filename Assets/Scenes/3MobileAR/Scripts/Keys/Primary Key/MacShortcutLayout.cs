using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes._3MobileAR.Scripts.Keys.Primary_Key
{
    /// <summary>
    /// Layout for function keys
    /// TODO: rename class to FunctionKeyLayout
    /// </summary>
    public class MacShortcutLayout : MonoBehaviour
    {
        public Sprite placementImage;
        public string functionName;

        public Image imageField;
        public TextMeshProUGUI functionField;
        
        private void Start()
        {
            imageField.sprite = placementImage;
            functionField.text = functionName;
        }

    }
}
