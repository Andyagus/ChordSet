using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MacShortcutLayout : MonoBehaviour
{
    public Sprite placementImage;
    public string functionName;

    public Image imageField;
    public TextMeshProUGUI functionField;
    
    // Start is called before the first frame update
    private void Start()
    {
        imageField.sprite = placementImage;
        functionField.text = functionName;
    }

}
