using AR_Keyboard;
using UnityEngine;
using UnityEngine.UI;

public class StarShortcut : Shortcut
{

    [SerializeField] private Image starImage;
    [SerializeField] private Sprite starOutline;
    [SerializeField] private Sprite starFill;
    [SerializeField] private ParticleSystem starSuccess;
    [SerializeField] private AudioClip starSound;
    
    
    public enum eStarState
    {
        PRESSED,
        UNPRESSED
    }

    public eStarState starState;
    public eStarState previousState;

    // private void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.S))
    //     {
    //         if (starState == eStarState.UNPRESSED)
    //         {
    //             SetStarState(eStarState.PRESSED);
    //         }
    //     }
    // }

    public void SetStarState(eStarState state)
    {
        switch (state)
        {
            case eStarState.PRESSED:
                starState = eStarState.PRESSED;
                starImage.sprite = starFill;
                break;
            case eStarState.UNPRESSED:
                starState = eStarState.UNPRESSED;
                Debug.Log("UNPressed");
                starImage.sprite = starOutline;
                break;
        }
    }
}
