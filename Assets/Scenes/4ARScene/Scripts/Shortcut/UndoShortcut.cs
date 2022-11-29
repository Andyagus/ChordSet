using AR_Keyboard;
using DG.Tweening;
using Enums;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes._4ARScene.Scripts.Shortcut
{
    public class UndoShortcut : AR_Keyboard.Shortcut
    {
        private GameObject _undoGameObject;
        private Image arrowIcon;
        private Image pulsingLineIcon;
        private TextMeshProUGUI undoText;
        private Sequence _sequence;

        [Range(0,10)]
        [SerializeField]  private float arrowFadeInTime = 4.1f;
        
        public override void Awake()
        {
            base.Awake();
        }

        public override void StopSequence()
        {
            Destroy(_undoGameObject);

            if (_sequence != null)
            {
                _sequence.Pause();
                _sequence.Kill();
            }
        }


        public override void SetGraphics(ARPrimaryKey key)
        {
            var keyText = key.GetComponentInChildren<TextMeshProUGUI>();

            _sequence = DOTween.Sequence();

            var offset = new Vector3(0f, 0.00013f, 0f);
            _undoGameObject = Instantiate(gameObject, key.transform);
            _undoGameObject.transform.position = key.transform.position + offset;
            undoText = _undoGameObject.GetComponentInChildren<TextMeshProUGUI>();
            
            var images = _undoGameObject.GetComponentsInChildren<Image>();
            arrowIcon = images[0];
            pulsingLineIcon = images[1];

            
            // _sequence.Append(arrowIcon.DOFade(0, 0)).SetAutoKill(false);
            _sequence.PrependInterval(0.5f);
            var pulseLineIcon = pulsingLineIcon.DOFade(0, .5f).SetLoops(6, LoopType.Yoyo);
            _sequence.Append(pulseLineIcon);
            _sequence.Append(pulsingLineIcon.DOFade(0.5f, 0f));
            var rectMove = pulsingLineIcon.rectTransform.DOLocalMoveX(-0.3f, 0.145732f);
            _sequence.Append(rectMove);
            _sequence.Append(keyText.DOFade(0, 0.002f));
            _sequence.Append(pulsingLineIcon.DOFade(0, .2f));
            _sequence.Insert(3.65f, arrowIcon.DOFade(1, 2f));
            _sequence.Insert(3.65f, undoText.DOFade(1, 2f));
            _sequence.AppendInterval(2);
            _sequence.SetLoops(-1, LoopType.Restart);
            _sequence.SetAutoKill(false);
            
        }


     
        public override void Execute(EKeyState keyState, ARPrimaryKey key)
        {
            Debug.Log("Undo Shortcut Called");
        }
    }
}
