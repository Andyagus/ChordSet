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

    [SerializeField] private TextMeshProUGUI letterText;
    [SerializeField] private TextMeshProUGUI secondaryText;
    [SerializeField] private Image letterImage;


    public enum EKeyAvailability
    {
        NONE,
        AVAILABLE,
        UNAVAILABLE,
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
        if (letterText != null)
        {
            letterText.DOFade(1, 0.973f);
        }

        if (secondaryText != null)
        {
            secondaryText.DOFade(1, 0.973f);
        }

        if (letterImage != null)
        {
            letterImage.DOFade(1, 0.34f);
        }
    }
    
    private void Unavailable(Key key)
    {
        if (letterText != null)
        {
            letterText.DOFade(0.2f, 0.973f);
        }

        if (secondaryText != null)
        {
            secondaryText.DOFade(0.2f, 0.973f);
        }

        if (letterImage != null)
        {
            letterImage.DOFade(0.2f, 0.34f);
        }
    }
    

}
