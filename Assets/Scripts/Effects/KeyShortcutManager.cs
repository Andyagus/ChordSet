using AR_Keyboard;
using AR_Keyboard.State;
using UnityEngine;

namespace Effects
{
    public class KeyShortcutManager : MonoBehaviour
    {
        public static Shortcut PlaceKeyShortcut(ARPrimaryKey key, ARKeyboardState keyboardState)
        {
            switch (keyboardState.GetType().ToString())
            {
                case "AR_Keyboard.State.CommandState":
                    // var shortcut = Instantiate(key.commandStateShortcut);
                    // return SetShortcut(key, shortcut);
                default:
                    Debug.Log("Nothing on this state");
                    break;
            }
            return null;
        }

        public static Shortcut SetShortcut(ARPrimaryKey key, Shortcut shortcut)
        {
            var shortcutTransform = shortcut.transform;
            var keyTransform = key.transform;
            shortcutTransform.position = keyTransform.position;
            shortcutTransform.position += shortcutTransform.up * 4;
            shortcutTransform.rotation = keyTransform.rotation;
            // shortcutTransform.eulerAngles = new Vector3(keyTransform.eulerAngles.x, 180, 0f);
            shortcutTransform.SetParent(keyTransform);

            return shortcut;
        }

        public static void RemoveShortcut(ARPrimaryKey key)
        {
            Destroy(key.GetComponentInChildren<Shortcut>().gameObject);
        }
    }
}
