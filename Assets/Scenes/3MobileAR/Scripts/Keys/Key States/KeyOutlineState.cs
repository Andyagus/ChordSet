using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class KeyOutlineState : MonoBehaviour
{
    
    [SerializeField] private Image outline;
    public enum EKeyOutline
    {
        OUTLINE,
        NO_OUTLINE
    }

    public void SetOutlineState(EKeyOutline state, Key key)
    {
        switch (state)
        {
            case EKeyOutline.OUTLINE:
                Outline();
                break;
            case EKeyOutline.NO_OUTLINE:
                NoOutline();
                break;
        }
    }
    private void Outline()
    {
        outline.DOFade(1, 1.2f);
    }
    
    private void NoOutline()
    {
        outline.DOFade(0, 1.2f);    
    }

    
}

