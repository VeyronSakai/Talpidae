using System;
using Common.OutGame.Presenter;
using UI.View.Title;
using UniRx;

namespace UI.Presenter.Title
{
    public sealed class UITitleBackGroundPresenter : PresenterBase<UITitleBackGroundWindow>
    {
        public UITitleBackGroundPresenter(PrefabGenParams prefabGenParams) : base(prefabGenParams)
        {
        }

        public IObservable<Unit> CreditButtonDownAsObservable => TargetView.CreditButtonObservable;
        public IObservable<Unit> PointerDownAsObservable => TargetView.PointerDownObservable;
    }
}