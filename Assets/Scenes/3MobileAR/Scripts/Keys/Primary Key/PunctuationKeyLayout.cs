using TMPro;
using UnityEngine;

namespace Scenes._3MobileAR.Scripts.Keys.Primary_Key
{
    /// <summary>
    /// Punctuation Key Layout.  Many different layout classes
    /// because attributes of various keys are different
    /// </summary>
    public class PunctuationKeyLayout : MonoBehaviour
    {
        public string topSymbol;
        public string bottomSymbol;

        public TextMeshProUGUI topSymbolText;
        public TextMeshProUGUI bottomSymbolText;

        private void Awake()
        {
            topSymbolText.text = topSymbol;
            bottomSymbolText.text = bottomSymbol;
        }
    }
}
