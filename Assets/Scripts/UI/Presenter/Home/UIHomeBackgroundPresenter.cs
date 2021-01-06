using System;
using Common.OutGame.Presentation.Presenter;
using UI.View.Home;
using UniRx;

namespace UI.Presenter.Home
{
    public sealed class UIHomeBackgroundPresenter : PresenterBase<UIHomeBackgroundWindow>
    {
        public UIHomeBackgroundPresenter(PrefabGenParams prefabGenParams) : base(prefabGenParams)
        {
        }

        public IObservable<Unit> GachaButtonOnClickAsObservable => TargetView.GachaButtonOnClickAsObservable;
        public IObservable<Unit> CostumeButtonOnClickAsObservable => TargetView.CostumeButtonOnClickAsObservable;
        public IObservable<Unit> MatchingButtonOnClickAsObservable => TargetView.MatchingButtonOnClickAsObservable;
    }
}