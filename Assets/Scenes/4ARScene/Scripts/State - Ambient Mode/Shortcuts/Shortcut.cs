using System;
using System.Collections.Generic;
using AR_Keyboard.State;
using Interfaces;
using TMPro;
using UnityEngine;
using Enums;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UI;

namespace AR_Keyboard
{
    //maybe implement subscriber observer here
    public class Shortcut : MonoBehaviour
    {
        
        public Subject onShortcutExecuted;

        public enum EShortcuts
        {
            COPY_SHORTCUT,
            PAST_SHORTCUT,
            UNDO_SHORTCUT,
            CUT_SHORTCUT
            
        }
        public EShortcuts eShortcut;
        public string shortcutName;
        
        
        [Header("Shortcut Activity State")] 
        private ShortutActivityState _activityState;
        
        public ShortutActivityState.EShortcutActivity shortcutActivity;
        private ShortutActivityState.EShortcutActivity _prevShortcutActivity = ShortutActivityState.EShortcutActivity.INACTIVE; 
        
        public virtual void Awake()
        {
            _activityState = GetComponent<ShortutActivityState>();
            onShortcutExecuted = new Subject();
        }

        public virtual void Update()
        {
            if (shortcutActivity != _prevShortcutActivity)
            {
                _activityState.SetShortcutActivity(shortcutActivity, this);
                _prevShortcutActivity = shortcutActivity;
            }
        }

        public virtual void Execute(ARPrimaryKey key)
        {
            // key.SetPrimaryKeyState(ARPrimaryKey.EPrimaryKeyState.ANIMATION_PLAY);
        }
        
        
        
    }
}
