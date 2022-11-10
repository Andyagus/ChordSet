using AR_Keyboard;
using UnityEngine;

namespace Effects
{
    public class KeyColorManager : MonoBehaviour
    {
        public static void ChangeKeyColor(ARKey key, Color color)
        {
            var keyMaterial= key.GetComponent<MeshRenderer>().material;
            keyMaterial.color = color;
        }
    }
}
