using TMPro;
using UnityEngine;

namespace Scenes._3MobileAR.Scripts.Keys.Primary_Key
{
    /// <summary>
    /// Placement for all of the main primary keys (A,B,C, etc…), setting their GameObject Keyboard Key
    /// to the name of the primary key.
    /// TODO: Refactor - not great if primary key name is different than what you want to display on key 
    /// </summary>
    public class LetterPlacement : MonoBehaviour
    {
        private TextMeshProUGUI _textMesh;
        private ARPrimaryKey _primaryKey;

        private void Awake()
        {
            _textMesh = GetComponentInChildren<TextMeshProUGUI>();
            _primaryKey = GetComponent<ARPrimaryKey>();
        }

        private void Start()
        {
            if (_textMesh != null)
            {
                _textMesh.text = _primaryKey.KeyName;
            }
        }

    }
}
