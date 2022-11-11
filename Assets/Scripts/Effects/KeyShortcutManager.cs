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
            
            //TODO Fix this placement key method also prefab is rotated 180, not done programatically, bad...
            var shortcut = Instantiate(key.shortcuts[1]);
            //match top of key - just winging it need to be more elegant -- this whole thing
            var offset = Vector3.up * 1.10f;
            var shortcutTransform = shortcut.transform;
            var keyTransform = key.transform;
            shortcutTransform.position = keyTransform.position + offset;
            shortcutTransform.rotation = keyTransform.rotation;
            // shortcutTransform.eulerAngles = new Vector3(keyTransform.eulerAngles.x, 180, 0f);
            
            shortcutTransform.SetParent(keyTransform);
            
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
