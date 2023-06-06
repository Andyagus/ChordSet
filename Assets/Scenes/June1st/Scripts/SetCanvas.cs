using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetCanvas : MonoBehaviour
{
    private TextMeshProUGUI _letter;
    private TextMeshProUGUI _shortcutTitle;
    private Image _shortcutIcon;
    private PrimaryKeyInfo _keyInfo;

    
    
    
    private void Awake()
    {
        _keyInfo = GetComponentInParent<PrimaryKeyInfo>(true);
        _letter.text = _keyInfo.keyName;
        _shortcutTitle.text = _keyInfo.shortcutName;
        _shortcutIcon.sprite = _keyInfo.logo;

    }
}
