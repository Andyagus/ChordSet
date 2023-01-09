using Scenes._3MobileAR.Scripts.Keys.Shortcuts;
using Scenes._3MobileAR.Scripts.Screen_Space_UI._1Main;
using UnityEngine;

namespace Scenes._3MobileAR.Scripts.Screen_Space_UI._3PopUp
{
    /// <summary>
    /// PopUp is activated when an item on the Shortcut List is clicked 
    /// </summary>
    public class ShortcutPopUp : MonoBehaviour
    {
        //TODO: using shortcutListItem for popUp (same class as ListItem prefab)...switch its own class
        //Using ShortcutListItem to reference the UIPopUp prefab in the scene and access its text/image elements
        private ShortcutListItem _shortcutListItem;
        public ShortcutPopUpState.EShortcutPopUp popUpState;
        private ShortcutPopUpState _popUpState;
        [SerializeField] private ShortcutList shortcutList;

        private void Awake()
        {
            _popUpState = GetComponent<ShortcutPopUpState>();
            _shortcutListItem = GetComponent<ShortcutListItem>();
            shortcutList.onListItemClicked += OnListItemClicked;
        }
    
        /// <summary>
        /// When shortcut in list is pressed (subscribed in awake) set PopUp to active with active shortcut name and image
        /// </summary>
        private void OnListItemClicked(Shortcut shortcut)
        {
            popUpState = ShortcutPopUpState.EShortcutPopUp.ACTIVE;
            _popUpState.SetPopUpState(popUpState);
            //TODO: Refactor - setting shortcut list item image and text here, for consistency move to state machine.
            _shortcutListItem.shortcutName.text = shortcut.shortcutName;
            _shortcutListItem.shortcutImage.sprite = shortcut.shortcutSprite;
        }
   
    }
}
