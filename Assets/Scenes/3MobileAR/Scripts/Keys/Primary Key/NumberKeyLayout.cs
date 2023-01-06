using TMPro;
using UnityEngine;

namespace Scenes._3MobileAR.Scripts.Keys.Primary_Key
{
    /// <summary>
    /// NumberKey Layout (1, 2, 3, 4, etc…)
    /// </summary>
    public class NumberKeyLayout : MonoBehaviour
    {
        public string symbol;
        public string number;
    
        public TextMeshProUGUI topText;
        public TextMeshProUGUI bottomText;
    
        private void Start()
        {
            topText.text = symbol;
            bottomText.text = number;
        }

    }
}
