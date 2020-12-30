using System;
using Common.OutGame.View;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UI.View.Title
{
    public sealed class UITitleBackGroundWindow : ViewBase
    {
        [SerializeField] private Button tapToStartButton;
        [SerializeField] private Button creditButton;

        public IObservable<Unit> TapToStartButtonObservable => tapToStartButton.OnClickAsObservable();
        public IObservable<Unit> CreditButtonObservable => creditButton.OnClickAsObservable();
    }
}