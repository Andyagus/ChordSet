using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes._3MobileAR.Scripts.Screen_Space_UI._1Main
{
    /// <summary>
    /// Class connected to the Shortcut prefab instantiated on the list.  Has button component,
    /// OnClick event is set through the ShortcutList class
    /// </summary>
    public class ShortcutListItem : MonoBehaviour
    {
        public TextMeshProUGUI shortcutName;
        public Image shortcutImage;
        public TextMeshProUGUI shortcutKeys;
    }
}
