using System.Collections;
using System.Collections.Generic;
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
    void Start()
    {
        imageField.sprite = placementImage;
        functionField.text = functionName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
