using TMPro;
using UnityEngine;

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
