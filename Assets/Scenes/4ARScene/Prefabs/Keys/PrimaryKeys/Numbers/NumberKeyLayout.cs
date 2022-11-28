using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NumberKeyLayout : MonoBehaviour
{
    public string symbol;
    public string number;
    
    public TextMeshProUGUI topText;
    public TextMeshProUGUI bottomText;
    // Start is called before the first frame update
    
    void Start()
    {
        topText.text = symbol;
        bottomText.text = number;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
