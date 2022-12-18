using AR_Keyboard;
using Enums;
using Normal.Realtime;
using UnityEngine;

public class KeySync : RealtimeComponent<KeySyncModel>
{
    // ReSharper disable InconsistentNaming
    private ARKeyboard _ARKeyboard; 
    // ReSharper restore InconsistentNaming

    private void Start()
    {
        //need conditional here for only mobile app
        _ARKeyboard = GameObject.FindObjectOfType<ARKeyboard>();
    }
    
    public void SetNewKey(string keyName, EKeyState eKeyState)
    {
        model.keyName = keyName;
        model.keyState = eKeyState;
    }
}
