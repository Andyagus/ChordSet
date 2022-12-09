using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MockKeyboard : MonoBehaviour
{
    private List<Key> keys;

    private void Awake()
    {
        keys = GetComponentsInChildren<Key>().ToList();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
