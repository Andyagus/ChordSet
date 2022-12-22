using System.Collections;
using System.Collections.Generic;
using AR_Keyboard;
using AR_Keyboard.State;
using UnityEngine;

public class LearningModeState : ARKeyboardState
{
    [SerializeField] protected ARKeyboardState nextState;
    [SerializeField] protected ARKeyboardState previousState;
    [SerializeField] public string shortcutName;

    public List<Key> keysInShortcut;

    public void DisplayShortcutKeys()
    {
        foreach (var key in keysInShortcut)
        {
            key.isInLearningMode = true;
            key.keyOutline = KeyOutlineState.EKeyOutline.OUTLINE;
            key.keyAvailability = KeyAvailabilityState.EKeyAvailability.AVAILABLE;
        }
    }

    public void DiscardShortcutKeys()
    {
        foreach (var key in keysInShortcut)
        {
            key.keyOutline = KeyOutlineState.EKeyOutline.NO_OUTLINE;
            key.isInLearningMode = false;
        }

    }

}
