using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public class Jump : JumpParent
{
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Notify");
            jumpSubject.Notify(this);
        }
    }
}
