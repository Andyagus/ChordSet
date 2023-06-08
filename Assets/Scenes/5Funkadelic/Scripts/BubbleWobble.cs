using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Serialization;

public class BubbleWobble : MonoBehaviour
{
    private Transform _orbTransform;
    private Sequence _orbMoveSequence;

    public Transform objectToRotateTransform;
    
    private void Awake()
    {
        _orbTransform = GetComponent<Transform>();
    }

    private void Start()
    {
        _orbMoveSequence = DOTween.Sequence();

        var currentZPos = transform.position.z;
        
        _orbMoveSequence.Append(_orbTransform.DOMoveZ(currentZPos+0.01f, .5f));
        _orbMoveSequence.Append(_orbTransform.DOMoveZ(currentZPos, .5f));
        _orbMoveSequence.SetLoops(-1);

    }

    private void Update()
    {
        transform.Rotate(objectToRotateTransform.position, 10 * Time.deltaTime);
        
        objectToRotateTransform.Rotate(180, 180, 180, Space.Self);
        

    }
}
