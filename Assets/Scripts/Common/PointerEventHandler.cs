using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Common
{
    [DisallowMultipleComponent]
    public class PointerEventHandler : MonoBehaviour, IPointerDownHandler
    {
        [HideInInspector] public readonly Subject<Unit> PointerDownSubject = new Subject<Unit>();

        public void OnPointerDown(PointerEventData eventData)
        {
            PointerDownSubject.OnNext(Unit.Default);
        }
    }
}