using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
}
