using System;
using System.Collections;
using System.Collections.Generic;
using Normal.Realtime;
using UnityEngine;

public class TestRealtimePlayerManager : MonoBehaviour
{
    private Realtime _realtime;

    private void Awake()
    {
        _realtime = GetComponent<Realtime>();
        _realtime.didConnectToRoom += DidConnectToRoom;
    }

    private void DidConnectToRoom(Realtime realtime)
    {
        Realtime.Instantiate("Cube", ownedByClient:true, preventOwnershipTakeover: true);
    }
    
}
