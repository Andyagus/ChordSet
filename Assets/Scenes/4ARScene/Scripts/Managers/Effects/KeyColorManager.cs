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

        private void Awake()
        {
            _primaryKeys = GameObject.Find("AR Keyboard").GetComponentsInChildren<ARPrimaryKey>().ToList();
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
            var keyMaterial= key.GetComponent<MeshRenderer>().material;
            keyMaterial.color = color;
        }
        
    }
}
