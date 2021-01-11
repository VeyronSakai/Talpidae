using System;
using Common.OutGame.Event;
using UniPresentation.View;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.View.Title
{
    public sealed class UITitleBackgroundWindow : ViewBase
    {
        [SerializeField] private PointerEventHandler pointerEventHandler;
        [SerializeField] private Button creditButton;

        public IObservable<Unit> OnTapCreditButton => creditButton.OnClickAsObservable();
        public IObservable<Unit> OnPointerDown => pointerEventHandler.PointerDownSubject;
    }
}