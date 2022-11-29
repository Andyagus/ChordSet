using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DoTweenLoopTest : MonoBehaviour
{
    private Sequence _sequence;
    private bool _paused;

    public Image canvasImage;

    private int _count;
    
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(1);

     

        
        // _sequence = DOTween.Sequence();
        // _sequence.Append(canvasImage.DOColor(Color.green, 1));
        // _sequence.SetLoops(-1, LoopType.Yoyo);
        
        // _sequence.Append(transform.DOScale(10, 1));
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!_paused)
            {
                _sequence.Pause();
                _paused = true;
            }
            else
            {
                _sequence.Play();
                _paused = false;
            }
        }
        
    }
}
