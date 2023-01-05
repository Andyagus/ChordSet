using System;
using UnityEngine;

namespace Scenes._3MobileAR.Scripts.Keys.Shortcuts
{
    /// <summary>
    /// SubState of shortcut, handles what methods and actions need to be called
    /// depending on the current activity of a specific shortcut 
    /// </summary>
    public class ShortcutActivityState : MonoBehaviour
    {
        public enum EShortcutActivity
        {
            ACTIVE,
            INACTIVE,
        }
    
        public void SetShortcutActivity(EShortcutActivity state, Shortcut shortcut)
        {
            switch (state)
            {
                case EShortcutActivity.ACTIVE:
                    Active(shortcut);
                    break;
                case EShortcutActivity.INACTIVE:
                    Inactive(shortcut);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }
        
        private void Active(Shortcut shortcut)
        {
            //TODO: Add additional functionality including logo filling up a color, etc
            if (shortcut.onShortcutExecuted != null)
            {
                //Sends out onShortcutExecuted event to subscribers
                shortcut.onShortcutExecuted(shortcut);
            }
        }

        private void Inactive(Shortcut shortcut)
        {
        }
    }
}
