using AR_Keyboard;
using Scenes._3MobileAR.Scripts.Keys.Primary_Key;
using TMPro;
using UnityEngine;

public class LetterPlacement : MonoBehaviour
{
    private TextMeshProUGUI _textMesh;
    private ARPrimaryKey _primaryKey;
    
    private void Awake()
    {
        _textMesh = GetComponentInChildren<TextMeshProUGUI>();
        _primaryKey = GetComponent<ARPrimaryKey>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (_textMesh != null)
        {
            _textMesh.text = _primaryKey.KeyName;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
