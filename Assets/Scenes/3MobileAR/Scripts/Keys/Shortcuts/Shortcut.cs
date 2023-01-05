using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scenes._3MobileAR.Scripts.Keys.Shortcuts
{
    /// <summary>
    /// Base class for all shortcuts instantiated through KeyShortcutState.
    /// Shortcut GameObjects display logo on the ARKeyboard Keys
    /// to indicate what shortcuts are available during certain states. 
    /// </summary>
    public class Shortcut : MonoBehaviour
    {
        //The event is called when ShortcutActivityState is set to active
        public Action<Shortcut> onShortcutExecuted;
        
        //Enum used when shortcut received from observers to have shortcut specific methods 
        public enum EShortcuts
        {
            UNDO,
            CUT,
            PRINT,
            RULER,
            SAVE_AS,
            SELECT_ALL,
            SCREENSHOT,
            NONE
        }
        
        public EShortcuts eShortcut;
        public string shortcutName;
        public Sprite shortcutSprite;
        
        //TODO: Refactor - KeysToAccess is ideal structure for future architecture, base everything off of this.
        public List<string> keysToAccess;
        
        /// <summary>
        /// Activity State is a SubState on shortcut to keep track of actions when pressed or unpressed
        /// </summary>
        [Header("Shortcut Activity State")]
        public ShortcutActivityState.EShortcutActivity shortcutActivity;
        private ShortcutActivityState.EShortcutActivity _prevShortcutActivity = ShortcutActivityState.EShortcutActivity.INACTIVE; 
        private ShortcutActivityState _activityState;
        
        public virtual void Awake()
        {
            _activityState = GetComponent<ShortcutActivityState>();
        }

        public virtual void Update()
        {
            if (shortcutActivity != _prevShortcutActivity)
            {
                _activityState.SetShortcutActivity(shortcutActivity, this);
                _prevShortcutActivity = shortcutActivity;
            }
        }
    }
}
