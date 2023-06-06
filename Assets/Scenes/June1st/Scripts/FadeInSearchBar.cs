using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class FadeInSearchBar : MonoBehaviour
{

    private Sequence _searchBarSequence;
    [SerializeField] private Transform searchBar;
    [SerializeField] private Image searchBarBG;
    [SerializeField] private TextMeshProUGUI searchBarText;

    private Vector3 _originalScale;
    private Vector3 _originalPosition;
    
    [SerializeField] private GameObject referenceBar;
    private Vector3 _searchBarScaleSize;
    private Vector3 _searchBarMovePosition;

    private bool _searchBarOpened;
    
    private void Awake()
    {
        var sbTransform = searchBar.transform;
        
        _originalScale = sbTransform.localScale;
        _originalPosition = sbTransform.position;
        
        _searchBarScaleSize = referenceBar.transform.localScale;
        _searchBarMovePosition = referenceBar.transform.position;

        _searchBarOpened = false;

    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!_searchBarOpened)
            {
                OpenSearchBar();
                _searchBarOpened = true;
            }
            else
            {
                CloseSearchBar();
                _searchBarOpened = false;
            }
        }    
    }

    private void CloseSearchBar()
    {
        searchBar.DOScale(_originalScale,1f);
        searchBar.DOMove(_originalPosition, 1f);
        searchBarBG.DOFade(0, 1.25f);
        searchBarText.DOFade(0, 1.25f);
    }

    private void OpenSearchBar()
    {
        searchBar.DOScale(_searchBarScaleSize,1f);
        searchBar.DOMove(_searchBarMovePosition, 1f);
        searchBarBG.DOFade(1, 1.25f);
        searchBarText.DOFade(1, 1.25f);
        
    }
}
