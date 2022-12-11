using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AR_Keyboard;
using Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Effects
{
    public class KeyColorManager : MonoBehaviour, IObserver
    {
        private Color originalShortcutColor;
        
        private List<ARPrimaryKey> _primaryKeys;
        //could switch to other………

        private static Dictionary<string, Color> _colorPalette;
        

        private void Awake()
        {
            _primaryKeys = GameObject.Find("AR Keyboard").GetComponentsInChildren<ARPrimaryKey>().ToList();

            _colorPalette = new Dictionary<string, Color>()
            {
                {"white", Color.white},
                {"black", Color.black}
            };
        }


        public static Shortcut InstantiateShortcut(ARPrimaryKey primaryKey, Shortcut shortcut)
        {
            
            //this could all tie in 


            Vector3 offset;
            
            if (primaryKey.GetComponentInChildren<Shortcut>() != null)
            {
                // primaryKey.currentShortcut.StopSequence(primaryKey);
                // Destroy(primaryKey.currentShortcut.gameObject);
            }

            var newShortcut = Instantiate(shortcut, primaryKey.transform);
            // primaryKey.currentShortcut = newShortcut;

            offset = shortcut.shortcutName == "Back To Keyboard" ? new Vector3(.0098f, 0.0001f, 0f) : new Vector3(0, 0.0007f, 0f);
            
            newShortcut.transform.position = primaryKey.transform.position + offset;

            return newShortcut;

        }
        
        public static Color ColorRequest(string colorRequest)
        {
            var color = _colorPalette[colorRequest];
            return color;
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
