using System;
using Common.OutGame.Presenter;
using UI.View.Title;
using UniRx;

namespace UI.Presenter.Title
{
    public sealed class UITitleBackGroundPresenter : PresenterBase<UITitleBackGroundWindow>
    {
        public UITitleBackGroundPresenter(PresenterCommonArgs commonArgs) : base(commonArgs)
        {
        }

        public IObservable<Unit> CreditButtonObservable => TargetView.CreditButtonObservable;
        public IObservable<Unit> TapToStartButtonObservable => TargetView.TapToStartButtonObservable;
    }
}