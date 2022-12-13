using System.Collections;
using System.Collections.Generic;
using AR_Keyboard;
using AR_Keyboard.State;
using DG.Tweening;
using Enums;
using TMPro;
using UnityEngine;

public class WelcomeModeIntro : ARKeyboardState
{
    [SerializeField] private ARKeyboardState welcomeModeOut;
    
    public override void Entry(ARKeyboard keyboard)
    {
        StartCoroutine(LightUpKeys(keyboard));
        // Debug.Log("Coroutine Finished");
        // foreach (var keys in keyboard.keys)
        // {
        //     
        // }
    }

    private IEnumerator LightUpKeys(ARKeyboard keyboard)
    {
        // while()
        var count = keyboard.keys.Count;
        var i = 0;
         
        List<Key> selectedKeys = new List<Key>(); 
        
        while (i < count)
        {
            var randomKeyIndex = Random.Range(0, count);
            var selectedKey = keyboard.keys[randomKeyIndex];
            selectedKeys.Add(selectedKey);
            selectedKey.keyPressed = EKeyState.KEY_PRESSED;
            yield return new WaitForSeconds(.03f);
            i++;
        }
        
        yield return new WaitForSeconds(0.9f);
        
        foreach (var key in selectedKeys)
        {
            key.keyPressed = EKeyState.KEY_UNPRESSED;
            yield return new WaitForSeconds(.01f);
        }

        foreach (var key in keyboard.keys)
        {
            key.keyAvailability = KeyAvailabilityState.EKeyAvailability.UNAVAILABLE;
            
            if (key.KeyName == "Q")
            {
                yield return new WaitForSeconds(0.02f);
                key.keyPressed = EKeyState.KEY_PRESSED;
                yield return new WaitForSeconds(0.02f);
                var primaryKey = key.GetComponent<ARPrimaryKey>();
                primaryKey.keyAvailability = KeyAvailabilityState.EKeyAvailability.AVAILABLE;
                primaryKey.keyText.DOText("C", 0.2f);
                yield return new WaitForSeconds(0.2f);
                key.keyPressed = EKeyState.KEY_UNPRESSED;
                
            }
            if (key.KeyName == "W")
            {
                yield return new WaitForSeconds(0.02f);
                key.keyPressed = EKeyState.KEY_PRESSED;
                yield return new WaitForSeconds(0.02f);
                var primaryKey = key.GetComponent<ARPrimaryKey>();
                primaryKey.keyAvailability = KeyAvailabilityState.EKeyAvailability.AVAILABLE;
                primaryKey.keyText.DOText("H", 0.5f);
                yield return new WaitForSeconds(0.2f);
                key.keyPressed = EKeyState.KEY_UNPRESSED;
            }
            if (key.KeyName == "E")
            {
                yield return new WaitForSeconds(0.02f);
                key.keyPressed = EKeyState.KEY_PRESSED;
                yield return new WaitForSeconds(0.02f);
                var primaryKey = key.GetComponent<ARPrimaryKey>();
                primaryKey.keyAvailability = KeyAvailabilityState.EKeyAvailability.AVAILABLE;
                primaryKey.keyText.DOText("O", 0.5f);
                yield return new WaitForSeconds(0.2f);
                key.keyPressed = EKeyState.KEY_UNPRESSED;
            }
            if (key.KeyName == "R")
            {
                yield return new WaitForSeconds(0.02f);
                key.keyPressed = EKeyState.KEY_PRESSED;
                yield return new WaitForSeconds(0.02f);
                var primaryKey = key.GetComponent<ARPrimaryKey>();
                primaryKey.keyAvailability = KeyAvailabilityState.EKeyAvailability.AVAILABLE;
                primaryKey.keyText.DOText("R", 0.5f);
                yield return new WaitForSeconds(0.2f);
                key.keyPressed = EKeyState.KEY_UNPRESSED;
            }
            if (key.KeyName == "T")
            {
                yield return new WaitForSeconds(0.02f);
                key.keyPressed = EKeyState.KEY_PRESSED;
                yield return new WaitForSeconds(0.02f);
                var primaryKey = key.GetComponent<ARPrimaryKey>();
                primaryKey.keyAvailability = KeyAvailabilityState.EKeyAvailability.AVAILABLE;
                primaryKey.keyText.DOText("D", 0.5f);
                yield return new WaitForSeconds(0.2f);
                key.keyPressed = EKeyState.KEY_UNPRESSED;
            }

            if (key.KeyName == "A")
            {
                yield return new WaitForSeconds(0.02f);
                key.keyPressed = EKeyState.KEY_PRESSED;
                yield return new WaitForSeconds(0.02f);
                var primaryKey = key.GetComponent<ARPrimaryKey>();
                primaryKey.keyAvailability = KeyAvailabilityState.EKeyAvailability.AVAILABLE;
                primaryKey.keyText.DOText("S", 0.5f);
                yield return new WaitForSeconds(0.2f);
                key.keyPressed = EKeyState.KEY_UNPRESSED;

            }
            if (key.KeyName == "S")
            {
                yield return new WaitForSeconds(0.02f);
                key.keyPressed = EKeyState.KEY_PRESSED;
                yield return new WaitForSeconds(0.02f);
                var primaryKey = key.GetComponent<ARPrimaryKey>();
                primaryKey.keyAvailability = KeyAvailabilityState.EKeyAvailability.AVAILABLE;
                primaryKey.keyText.DOText("E", 0.5f);
                yield return new WaitForSeconds(0.2f);
                key.keyPressed = EKeyState.KEY_UNPRESSED;
            }
            if (key.KeyName == "D")
            {
                yield return new WaitForSeconds(0.02f);
                key.keyPressed = EKeyState.KEY_PRESSED;
                yield return new WaitForSeconds(0.02f);
                var primaryKey = key.GetComponent<ARPrimaryKey>();
                primaryKey.keyAvailability = KeyAvailabilityState.EKeyAvailability.AVAILABLE;
                primaryKey.keyText.DOText("T", 0.5f);
                yield return new WaitForSeconds(0.2f);
                key.keyPressed = EKeyState.KEY_UNPRESSED;
            }
                        
        }

        foreach (var key in keyboard.keys)
        {
            if (key.KeyName == "space")
            {
                yield return new WaitForSeconds(2);
                key.keyAvailability = KeyAvailabilityState.EKeyAvailability.AVAILABLE;
                key.displayText.DOText("START", 0.5f);
                key.displayText.DOFade(1, 2.0f);
                key.displayImage.DOFade(1, 2.1f);
            } 

        }
        
        yield return null;
    }

    public override ARKeyboardState HandleInput(Key key, ARKeyboard keyboard)
    {
        if (key.KeyName == "space" && key.keyPressed == EKeyState.KEY_PRESSED)
        {
            var state = Instantiate(welcomeModeOut);
            return state;
        }

        return null;
    }
}
