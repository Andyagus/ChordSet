using System.Collections;
using System.Collections.Generic;
using Scenes._3MobileAR.Scripts.Keys;
using UnityEngine;

public class TestInput : MonoBehaviour
{
    public List<Key> keys;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftCommand))
        {
            Debug.Log("A key pressed");
        }
    }
}
