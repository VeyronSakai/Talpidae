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

        public IObservable<Unit> OnTapGachaButton => TargetView.OnTapGachaButton;
        public IObservable<Unit> OnTapCostumeButton => TargetView.OnTapCostumeButton;
        public IObservable<Unit> OnTapMatchingButton => TargetView.OnTapMatchingButton;
    }
}