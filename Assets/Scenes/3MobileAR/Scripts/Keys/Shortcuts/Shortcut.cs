using System;
using System.Collections.Generic;
using UnityEngine;

namespace AR_Keyboard
{
    //maybe implement subscriber observer here
    public class Shortcut : MonoBehaviour
    {
        public Action<Shortcut> onShortcutExecuted;
        
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
        public List<string> keysToAccess;
        
        [Header("Shortcut Activity State")] 
        private ShortcutActivityState _activityState;
        
        public ShortcutActivityState.EShortcutActivity shortcutActivity;
        private ShortcutActivityState.EShortcutActivity _prevShortcutActivity = ShortcutActivityState.EShortcutActivity.INACTIVE; 
        
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
