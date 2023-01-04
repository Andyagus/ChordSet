using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ListItemScrollView : MonoBehaviour, ISelectHandler
{
    private ScrollRect _scrollRect;
    private ShortcutList _shortcutList;
    private float _scrollPosition = 1;
    
    private void Awake()
    {
        _scrollRect = GetComponentInParent<ScrollRect>(true);
        _shortcutList = GetComponentInParent<ShortcutList>(true);
        _shortcutList.onListPopulated += OnListPopulated;
    }

    private void OnListPopulated()
    {
        if (_scrollRect)
        {
            int childCount = _scrollRect.content.transform.childCount;
            int childIndex = transform.GetSiblingIndex();
            childIndex = childIndex < ((float)childCount / 2f) ? childIndex - 1 : childIndex;
            _scrollPosition = 1 - ((float)childIndex / childCount);
        }
    }

    public void OnSelect(BaseEventData eventData)
    {
        _scrollRect.verticalScrollbar.value = _scrollPosition;
    }
}
