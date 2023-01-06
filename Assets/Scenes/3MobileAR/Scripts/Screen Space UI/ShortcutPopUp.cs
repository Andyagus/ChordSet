using Scenes._3MobileAR.Scripts.Keys.Shortcuts;
using Scenes._3MobileAR.Scripts.Managers;
using UnityEngine;

public class ShortcutPopUp : MonoBehaviour
{
    private ARObjectInteractionManager _interactionManager;
    
    private ShortcutListItem _shortcutListItem;
    private ShortcutPopUpState _popUpState;
    public ShortcutPopUpState.EShortcutPopUp popUpState;
    [SerializeField] private ShortcutList shortcutList;
    private ShortcutPreviewManager _shortcutPreviewManager;
    
    
    private void Awake()
    {
        _interactionManager = GameObject.FindObjectOfType<ARObjectInteractionManager>();
        _popUpState = GetComponent<ShortcutPopUpState>();
        _shortcutListItem = GetComponent<ShortcutListItem>();
        shortcutList.onListItemClicked += OnListItemClicked;
    }
    
    private void OnListItemClicked(Shortcut shortcut)
    {
        popUpState = ShortcutPopUpState.EShortcutPopUp.ACTIVE;
        _popUpState.SetPopUpState(popUpState);
        _shortcutListItem.shortcutName.text = shortcut.shortcutName;
        _shortcutListItem.shortcutImage.sprite = shortcut.shortcutSprite;
    }
   
}
