using System;
using Common;
using Common.OutGame.View;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UI.View.Title
{
    public sealed class UITitleBackGroundWindow : ViewBase
    {
        [SerializeField] private PointerEventHandler pointerEventHandler;
        [SerializeField] private Button creditButton;

        public IObservable<Unit> CreditButtonObservable => creditButton.OnClickAsObservable();
        public IObservable<Unit> PointerDownObservable => pointerEventHandler.PointerDownSubject;
    }
}