using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyAvailabilityState : MonoBehaviour
{
    public enum EKeyAvailability
    {
        AVAILABLE,
        UNAVAILABLE
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
}
