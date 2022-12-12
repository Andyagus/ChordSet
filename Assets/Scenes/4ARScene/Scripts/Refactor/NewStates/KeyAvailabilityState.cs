using System;
using System.Collections;
using System.Collections.Generic;
using AR_Keyboard;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyAvailabilityState : MonoBehaviour
{
    private ARKeyboard _keyboard;
    private bool _welcomeState; 
    
    
    

    public enum EKeyAvailability
    {
        AVAILABLE,
        UNAVAILABLE,
        RESTORE
    }

    public void SetKeyAvailability(EKeyAvailability state, Key key)
    {
        switch (state)
        {
            case EKeyAvailability.AVAILABLE:
                Available(key);
                break;
            case EKeyAvailability.UNAVAILABLE:
                Unavailable(key);
                break;
            case EKeyAvailability.RESTORE:
                Restore(key);
                break;
        }
    }

    

    private void Available(Key key)
    {
        var textMeshProMultiple = key.GetComponentsInChildren<TextMeshProUGUI>();

        foreach (var text in textMeshProMultiple)
        {
            text.DOFade(1, 0.973f);
        }

        if (key.secondaryImage != null)
        {
            key.secondaryImage.DOFade(1, .973f);
        }
    }
    
    private void Unavailable(Key key)
    {
        var textMeshProMultiple = key.GetComponentsInChildren<TextMeshProUGUI>();

        foreach (var text in textMeshProMultiple)
        {
            text.DOFade(0.1f, 0.793f);
        }

        if (key.secondaryImage != null)
        {
            key.secondaryImage.DOFade(0, 0.973f);
        }
          
    }
    
    private void Restore(Key key)
    {
        var primaryKey = key.GetComponent<ARPrimaryKey>();
        primaryKey.keyText.DOText(primaryKey.KeyName, 0.5f);
    }
}
