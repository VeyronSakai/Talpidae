using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Presentation.View.InGame
{
    [RequireComponent(typeof(EventTrigger))]
    public class VirtualPad : MonoBehaviour
    {
        public Subject<Vector2> MoveDir { get; } = new Subject<Vector2>();

        // Stickが移動できる円の半径
        [SerializeField] private float movableRadius = 150f;

        // Stickの初期位置
        private Vector2 _initialStickPos;
        private RectTransform _stickRectTransform;
        private RectTransform _canvasRect;
        private bool _isTapped;
        private Camera _targetCamera;

        public void Initialize(Camera targetCamera)
        {
            _targetCamera = targetCamera;
        }


        // Start is called before the first frame update
        private void Awake()
        {
            _stickRectTransform = GetComponent<RectTransform>();
            var parentCanvas = GetComponentInParent<Canvas>();
            _canvasRect = parentCanvas.GetComponent<RectTransform>();
            _initialStickPos = _stickRectTransform.anchoredPosition;
            var eventTrigger = GetComponent<EventTrigger>();

            RegisterEvents(eventTrigger);
        }

        // Update is called once per frame
        private void Update()
        {
            if (!_isTapped)
                return;

            UpdateStickPos();
        }

        private void RegisterEvents(EventTrigger eventTrigger)
        {
            var pointerDownEntry = new EventTrigger.Entry {eventID = EventTriggerType.PointerDown};
            pointerDownEntry.callback.AddListener(data => OnPointerDownDelegate((PointerEventData) data));
            eventTrigger.triggers.Add(pointerDownEntry);

            var pointerUpEntry = new EventTrigger.Entry {eventID = EventTriggerType.PointerUp};
            pointerUpEntry.callback.AddListener((data) => { OnPointerUpDelegate((PointerEventData) data); });
            eventTrigger.triggers.Add(pointerUpEntry);
        }

        private void OnPointerDownDelegate(PointerEventData data)
        {
            _isTapped = true;
        }

        private void OnPointerUpDelegate(PointerEventData data)
        {
            _isTapped = false;
            // 元の場所に戻す
            _stickRectTransform.anchoredPosition = _initialStickPos;
        }

        private void UpdateStickPos()
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvasRect, Input.mousePosition, _targetCamera,
                out var touchPos);

            var modifiedPos = GetModifiedPos(touchPos);

            Vector2 moveVec;

            if (IsStickInMovableArea(modifiedPos))
            {
                _stickRectTransform.anchoredPosition = modifiedPos;
                moveVec = (modifiedPos - _initialStickPos) / movableRadius;
            }
            else
            {
                var moveDir = (modifiedPos - _initialStickPos).normalized;
                _stickRectTransform.anchoredPosition = _initialStickPos + movableRadius * moveDir;
                moveVec = (movableRadius * moveDir).normalized;
            }

            MoveDir.OnNext(moveVec);
        }

        // スティックが可動領域内にあるか
        private bool IsStickInMovableArea(Vector2 modifiedPos)
        {
            return (modifiedPos - _initialStickPos).magnitude < movableRadius;
        }

        // スティックの中心を原点とした座標に変換
        private Vector2 GetModifiedPos(Vector2 touchPos)
        {
            return touchPos + new Vector2(0, _canvasRect.rect.height / 2);
        }
    }
}