using System;
using System.Collections;
using System.Collections.Generic;
using AR_Keyboard;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TooltipState : MonoBehaviour
{
    public Tooltip startTooltip;
    public Tooltip nextShortcutTooltip;
    public Tooltip prevShortcutTooltip;
    
    [Header("DoTween")]
    private Sequence _instantiateSequence;
    private Sequence _destroySequence;
    private Vector3 _placementOffset = new Vector3(0f, 0.0007f, 0f);

    public enum ETooltip
    {
        NONE,
        START,
        NEXT_SHORTCUT,
    }

    public void SetTooltipState(ETooltip state, ARPrimaryKey primaryKey)
    {
        switch (state)
        {
            case ETooltip.START:
                InstantiateTooltip(primaryKey, startTooltip);
                // StartTooltip(primaryKey);
                break;
            case ETooltip.NEXT_SHORTCUT:
                InstantiateTooltip(primaryKey, nextShortcutTooltip);
                break;
            case ETooltip.NONE:
                EraseTooltip(primaryKey);
                // None();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(state), state, null);
        }
    }


    private void InstantiateTooltip(ARPrimaryKey primaryKey, Tooltip tooltip)
    {
        _destroySequence.Kill();
        _instantiateSequence = DOTween.Sequence();
        var newTooltip = Instantiate(tooltip);
        primaryKey.currentTooltip = newTooltip;

        newTooltip.transform.position = primaryKey.transform.position + _placementOffset;
        _instantiateSequence.Append(newTooltip.GetComponentInChildren<TextMeshProUGUI>().DOFade(1, 1f));
        _instantiateSequence.Insert(0, newTooltip.GetComponentInChildren<Image>().DOFade(1, 1f));
    }

    private void EraseTooltip(ARPrimaryKey primaryKey)
    {
        _instantiateSequence.Kill();
        _destroySequence = DOTween.Sequence();
        _destroySequence.Append(primaryKey.currentTooltip.GetComponentInChildren<TextMeshProUGUI>().DOFade(0, 1f));
        _destroySequence.Insert(0, primaryKey.currentTooltip.GetComponentInChildren<Image>().DOFade(0, 1f));

        _destroySequence.OnKill(() =>
        {
            Destroy(primaryKey.currentTooltip.gameObject);
        });
    }
  
}