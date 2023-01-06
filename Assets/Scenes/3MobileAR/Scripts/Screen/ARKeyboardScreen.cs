using Scenes._3MobileAR.Scripts.Keyboard;
using Scenes._3MobileAR.Scripts.Keys.Shortcuts;
using Scenes._3MobileAR.Scripts.Screen.States;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes._3MobileAR.Scripts.Screen
{
    /// <summary>
    /// AR Keyboard Screen class is attached to screen game object, a child of AR Keyboard
    /// This GameObject is covering the computer-screen in the real world environment.
    ///
    /// The class is only being used to display shortcut success pop-ups, but in other iterations
    /// played larger role, including showing preview shortcuts
    ///
    /// TODO: Explore - would like to explore how we can further use the screen to help with keyboard shortcuts
    /// video was an interesting approach, but needs more understanding.  
    /// </summary>
    public class ARKeyboardScreen : MonoBehaviour
    {

        private ARKeyboard _ARKeyboard;
    
        [Header("States")] 
        public BackgroundPanelState.EBackgroundPanel backgroundPanelState;
        private BackgroundPanelState.EBackgroundPanel _previousBackgroundPanelState = BackgroundPanelState.EBackgroundPanel.INACTIVE;
        private BackgroundPanelState _backgroundPanelState;

        public PositioningAreaState.EPositioningArea positioningAreaState;
        private PositioningAreaState.EPositioningArea _previousPositioningAreaState;
        private PositioningAreaState _positioningAreaState;
        
        public VideoState.EVideoState videoState;
        private VideoState.EVideoState _previousVideoState;
        private VideoState _videoState;
        
        public ShortcutSuccessPanelState.EShortcutSuccessPopUp shortcutSuccessPanelState;
        private ShortcutSuccessPanelState.EShortcutSuccessPopUp _previousShortcutSuccessPanelState;
        private ShortcutSuccessPanelState _shortcutSuccessPanelState;
    
        private void Awake()
        {
            _ARKeyboard = FindObjectOfType<ARKeyboard>();
            _ARKeyboard.onAmbientStateChanged += OnAmbientStateChanged;

            _backgroundPanelState = GetComponent<BackgroundPanelState>();
            _positioningAreaState = GetComponent<PositioningAreaState>();
            _videoState = GetComponent<VideoState>();
            _shortcutSuccessPanelState = GetComponent<ShortcutSuccessPanelState>();
        }

        private void OnAmbientStateChanged(ARKeyboardState obj)
        {
            foreach (var primaryKey in _ARKeyboard.primaryKeys)
            {
                if (primaryKey.currentShortcut != null)
                {
                    primaryKey.currentShortcut.onShortcutExecuted += OnShortcutExecuted;
                }
            }
        }

        /// <summary>
        /// When a shortcut is executed (subscribed from ARKeyboard.onAmbientStateChanged) call the
        /// shortcut success panel state and pass in the shortcut.
        /// </summary>
        private void OnShortcutExecuted(Shortcut shortcut)
        {
            //TODO Get components directly from shortcut instead of get component. Handle in the state, not as argument.
            _shortcutSuccessPanelState
                .SetShortcutSuccessPopUpState(ShortcutSuccessPanelState.EShortcutSuccessPopUp.AVAILABLE, 
                    shortcut.GetComponentInChildren<Image>().sprite, shortcut.shortcutName);
        }


        private void Update()
        {
            if (backgroundPanelState != _previousBackgroundPanelState)
            {
                _backgroundPanelState.SetBackgroundPanel(backgroundPanelState);
                _previousBackgroundPanelState = backgroundPanelState;
            }

            if (positioningAreaState != _previousPositioningAreaState)
            {
                _positioningAreaState.SetPositioningArea(positioningAreaState);
                _previousPositioningAreaState = positioningAreaState;
            }

            if (videoState != _previousVideoState)
            {
                _videoState.SetVideoState(videoState);
                _previousVideoState = videoState;
            }
        }

    }
}
