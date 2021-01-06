using System;
using Common.OutGame.Event;
using Common.OutGame.Presentation.View;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UI.View.Title
{
    public sealed class UITitleBackgroundWindow : ViewBase
    {
        [SerializeField] private PointerEventHandler pointerEventHandler;
        [SerializeField] private Button creditButton;

        public IObservable<Unit> CreditButtonOnClickAsObservable => creditButton.OnClickAsObservable();
        public IObservable<Unit> PointerDownAsObservable => pointerEventHandler.PointerDownSubject;
    }
}