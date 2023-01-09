using Scenes._3MobileAR.Scripts.Screen_Space_UI._1Main;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Scenes._3MobileAR.Scripts.Screen_Space_UI._2Utility
{
    /// <summary>
    /// This class is added to each List Item prefab in the UIList and sets the scrollbar position
    /// to match the currently selected item in the list. 
    /// </summary>
    public class ListItemScrollView : MonoBehaviour, ISelectHandler
    {
        private ScrollRect _scrollRect;
        private ShortcutList _shortcutList;
        private float _scrollPosition = 1;
        
        private void Awake()
        {
            //GetComponent(true) because UI starts out Inactive.
            _scrollRect = GetComponentInParent<ScrollRect>(true);
            _shortcutList = GetComponentInParent<ShortcutList>(true);
            _shortcutList.onListPopulated += OnListPopulated;
        }
        /// <summary>
        /// Parts of algorithm from referenced YouTube video
        /// <see>
        ///     <cref>https://www.youtube.com/watch?v=P8hx343kIGg</cref>
        /// </see>
        /// Determine the scroll bar position by dividing child index by the amount of items in the list.
        /// Had to manually set last item in list due to alignment issues.
        /// TODO: Implement a better algorithm.
        /// </summary>
        private void OnListPopulated()
        {
            if (_scrollRect)
            {
                var childCount = _scrollRect.content.transform.childCount;
                var childIndex = transform.GetSiblingIndex();
                if (childIndex != 0 && childIndex < childCount / 2)
                {
                    //Add additional offset when scroll through first half of the list
                    childIndex -= 1;
                }else if (childIndex == childCount - 1)
                {
                    //check if currently selected item is last item in the list, bring scrollbar to bottom
                    _scrollPosition = 1;
                    return;
                }
                _scrollPosition = (float)childIndex / childCount;
            }
        }
        
        /// <summary>
        /// Implemented through ISelectHandler interface
        /// Set scrollbar to equal the above set scroll position. 
        /// </summary>
        public void OnSelect(BaseEventData eventData)
        {
            //Subtracting 1 from scroll position because vertical scrollbar is set to bottom to top values
            _scrollRect.verticalScrollbar.value = 1 - _scrollPosition;
        }
    }
}
