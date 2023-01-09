using Scenes._3MobileAR.Scripts.Screen_Space_UI._1Main;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Scenes._3MobileAR.Scripts.Screen_Space_UI._2Utility
{
    /// <summary>
    /// Have the ScrollRects scroll position match the currently selected item in the list.
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
        
        //Learned this algorithm from YouTube, need to spend more time
        //working through it and provide more explanation / YouTube video link.
        private void OnListPopulated()
        {
            if (_scrollRect)
            {
                int childCount = _scrollRect.content.transform.childCount;
                int childIndex = transform.GetSiblingIndex();
                childIndex = childIndex < (childCount / 2f) ? childIndex - 1 : childIndex;
                _scrollPosition = 1 - ((float)childIndex / childCount);
            }
        }

        //When item in list is selected, set scrollbar to equal the scroll position. 
        public void OnSelect(BaseEventData eventData)
        {
            _scrollRect.verticalScrollbar.value = _scrollPosition;
        }
    }
}
