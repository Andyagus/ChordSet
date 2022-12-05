using System;
using System.Collections;
using System.Collections.Generic;
using AR_Keyboard;
using AR_Keyboard.State;
using DG.Tweening;
using Enums;
using TMPro;
using UnityEngine;

public class CopyShortcut : Shortcut
{
    public Transform stamp;

    // private Vector3 _originalPosition;

    public Transform executePosition;
    
    private Sequence _setGraphicSequence;
    private Sequence _executeSequence;
    
    public float localYMove = 0.007f;

    public bool graphicCopied;

    public Action onGraphicCopied;
    
    public override void SetGraphics(ARPrimaryKey key)
    {

        // _originalPosition = transform.position;
        _setGraphicSequence = DOTween.Sequence();
        _setGraphicSequence.Append(stamp.DOLocalMoveY(localYMove, 1.2f));
        base.SetGraphics(key);
    }

    public override void Execute(EKeyState keyState, ARPrimaryKey key)
    {
        _executeSequence = DOTween.Sequence();
        var newPos = new Vector3(0.0001f, .0025f, -0.002f);
        _executeSequence.Append(stamp.DOLocalMove(newPos, 1f));
        
        var keyText = key.GetComponentInChildren<TextMeshProUGUI>();
        _executeSequence.Insert(0, keyText.DOFade(0.12f , 1.13f));

        var moveToVKeyPos = new Vector3(0.0187f, 0.0097f, -0.002f);
        _executeSequence.Append(stamp.DOLocalMove(moveToVKeyPos, 0.896453f));

        graphicCopied = true;
        if (onGraphicCopied != null)
        {
            onGraphicCopied();
        }
        
        base.Execute(keyState, key);
    }

    public override void StopSequence(ARPrimaryKey key)
    {
        if (_setGraphicSequence != null)
        {
            _setGraphicSequence.Pause();
            _setGraphicSequence.Kill();
        }

        if (_executeSequence != null)
        {
            _executeSequence.Pause();
            _executeSequence.Kill();
        }
        base.StopSequence(key);
    }
}
