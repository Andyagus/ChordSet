using System.Collections;
using System.Collections.Generic;
using AR_Keyboard;
using UnityEngine;

public class KeyShortcutManager : MonoBehaviour
{
    public static Shortcut PlaceKeyShortcut(ARKey key)
    {
        if (key.shortcuts[1] != null)
        {
            var shortcut = Instantiate(key.shortcuts[1]);
            var offset = Vector3.up * 2;
            shortcut.transform.position = key.transform.position + offset;
            shortcut.transform.SetParent(key.transform);
            return shortcut;
        }

        return null;
    }

    //this needs work
    public static void RemoveShortcut(ARKey key)
    {
        if (key.shortcuts[1] != null)
        {
            var shortcut = key.GetComponentInChildren<Shortcut>();
            Destroy(shortcut.gameObject);
            //need to have access to the instance...... can not be static  
        }  
    }
}
