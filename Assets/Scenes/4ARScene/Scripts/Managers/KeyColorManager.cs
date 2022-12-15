using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AR_Keyboard;
using Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Effects
{
    public class KeyColorManager : MonoBehaviour, IObserver
    {
        private Color originalShortcutColor;
        
        private List<ARPrimaryKey> _primaryKeys;
        // private static Dictionary<string, Color> _colorPalette;

        public Color red;
        public Color yellow;
        public Color blue;
        public Color darkGray;
        public Color lightGray;

        private static List<Color> _colorPalette;

        
        private void Awake()
        {
            _primaryKeys = GameObject.Find("AR_Keyboard").GetComponentsInChildren<ARPrimaryKey>().ToList();
            
            _colorPalette = new List<Color>
            {
                red,
                yellow,
                blue,
                darkGray,
                lightGray
            };
        }


        // public static Shortcut InstantiateShortcut(ARPrimaryKey primaryKey, Shortcut shortcut)
        // {
        //     
        //
        //     Vector3 offset;
        //     
        //     var newShortcut = Instantiate(shortcut, primaryKey.transform);
        //     // primaryKey.currentShortcut = newShortcut;
        //
        //     offset = shortcut.shortcutName == "Back To Keyboard" ? new Vector3(.0098f, 0.0001f, 0f) : new Vector3(0, 0.0007f, 0f);
        //     
        //     newShortcut.transform.position = primaryKey.transform.position + offset;
        //
        //     return newShortcut;
        //
        // }
        
        
        public static Color PickRandomColor()
        {
            var i = Random.Range(0, _colorPalette.Count);
            var randomColor = _colorPalette[i];

            return randomColor;
        }
        
        
        public static Color ColorRequest(string colorRequest)
        {
            // var color = _colorPalette[colorRequest];
            // return color;
            return Color.white;
        }

        private void Start()
        {
            foreach (var primaryKey in _primaryKeys)
            {
                // primaryKey.onPrimaryKeyHit.AddObserver(this);
            }
        }

        public void OnNotify(object entity)
        {
            Shortcut shortcut = (Shortcut)entity;
            originalShortcutColor = shortcut.GetComponentInChildren<Image>().color;
            shortcut.GetComponentInChildren<Image>().color = Color.green;
            StartCoroutine(RevertBackColorTimer(shortcut));
        }

        private IEnumerator RevertBackColorTimer(Shortcut shortcut)
        {
            yield return new WaitForSeconds(0.3147f);
            shortcut.GetComponentInChildren<Image>().color = originalShortcutColor;
        }

        public static void ChangeKeyColor(ARPrimaryKey key, Color color)
        {
            // Debug.Log("Color Manager: " + key.KeyName);
            var keyMaterial= key.GetComponentInChildren<MeshRenderer>().material;
            keyMaterial.color = color;
        }
        
    }
}
