using System.Collections;
using System.Collections.Generic;
using AR_Keyboard;
using UnityEngine;

public class KeyShortcutManager : MonoBehaviour
{
    public static void PlaceKeyShortcut(ARKey key)
    {
        if (key.shortcuts[1] != null)
        {
            var shortcut = Instantiate(key.shortcuts[1]);
            var offset = Vector3.up * 2;
            shortcut.transform.position = key.transform.position + offset; 
        }
    }
}
