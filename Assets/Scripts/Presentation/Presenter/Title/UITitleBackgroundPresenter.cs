using System;
using Presentation.View.Title;
using UniPresentation.Presenter;
using UniRx;

namespace Presentation.Presenter.Title
{
    public sealed class UITitleBackgroundPresenter : PresenterBase<UITitleBackgroundWindow>
    {
        public UITitleBackgroundPresenter(PrefabGenParams prefabGenParams) : base(prefabGenParams)
        {
        }

        public IObservable<Unit> OnTapCreditButton => TargetView.OnTapCreditButton;
        public IObservable<Unit> OnPointerDown => TargetView.OnPointerDown;
    }
}