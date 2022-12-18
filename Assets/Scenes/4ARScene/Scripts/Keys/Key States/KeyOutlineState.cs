using UnityEngine;

public class KeyOutlineState : MonoBehaviour
{
    public enum EKeyOutline
    {
        OUTLINE,
        NO_OUTLINE
    }

    public void SetOutlineState(EKeyOutline state, KeyOutline outline)
    {
        switch (state)
        {
            case EKeyOutline.OUTLINE:
                Outline(outline);
                break;
            case EKeyOutline.NO_OUTLINE:
                NoOutline(outline);
                break;
        }
    }
    private void Outline(KeyOutline outline)
    {
        outline.gameObject.SetActive(true);
    }
    
    private void NoOutline(KeyOutline outline)
    {
        outline.gameObject.SetActive(false);
    }

    
}

