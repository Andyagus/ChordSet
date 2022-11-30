using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public class JumpParent : MonoBehaviour
{
    public Subject jumpSubject;
    
    private void Awake()
    {
        jumpSubject = new Subject();
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
