using System;
using Common.OutGame.Presentation.Presenter;
using UI.View.Title;
using UniRx;

namespace UI.Presenter.Title
{
    public sealed class UITitleBackGroundPresenter : PresenterBase<UITitleBackGroundWindow>
    {
        public UITitleBackGroundPresenter(PrefabGenParams prefabGenParams) : base(prefabGenParams)
        {
        }

        public IObservable<Unit> CreditButtonOnClickAsObservable => TargetView.CreditButtonOnClickAsObservable;
        public IObservable<Unit> PointerDownAsObservable => TargetView.PointerDownAsObservable;
    }
}