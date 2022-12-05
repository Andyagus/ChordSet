using System;
using AR_Keyboard;
using DG.Tweening;
using Enums;
using Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UndoShortcut : Shortcut
{
    private Image arrowIcon;
    private Image pulsingLineIcon;
    private TextMeshProUGUI undoText;
    private Sequence _sequence;

    [Header("Control Panel")] [SerializeField]
    
    [Tooltip("rect transform")]
    [Range(-0.5f, 0f)]
    private float distanceToMoveRectTransform = -0.3f;
    
    [Range(0, 0.5f)]
    private float timeToMoveRectTransform = 0.145732f;
    
    [Range(0,1)]
    [SerializeField]  private float iconFadeOutOffset = 1;
    
    [Range(0,10)]
    [SerializeField]  private float arrowFadeInTime = 1.12f;


    public override void StopSequence()
    {
        if (_sequence != null)
        {
            _sequence.Pause();
            _sequence.Kill();
        }
    }


    public override void SetGraphics(ARPrimaryKey key)
    {
        

        var keyText = key.GetComponentInChildren<TextMeshProUGUI>();

        var sequenceDuration = 3;
        
        _sequence = DOTween.Sequence();
        
        undoText = GetComponentInChildren<TextMeshProUGUI>();
        var images = GetComponentsInChildren<Image>();
        arrowIcon = images[0];
        pulsingLineIcon = images[1];
        //
        _sequence.Append(pulsingLineIcon.DOFade(1, sequenceDuration / 7.34f));
        _sequence.Append(pulsingLineIcon.rectTransform.DOLocalMoveX(distanceToMoveRectTransform, timeToMoveRectTransform));
        _sequence.Append(keyText.DOFade(0, sequenceDuration/8f));
        _sequence.Append(pulsingLineIcon.DOFade(0, iconFadeOutOffset));
        _sequence.Insert(arrowFadeInTime, arrowIcon.DOFade(1, 2f));

    }


 
    public override void Execute(EKeyState keyState, ARPrimaryKey key)
    {

        onShortcutExecuted.Notify(this);
        Debug.Log("Undo Shortcut Called");
    }
}

