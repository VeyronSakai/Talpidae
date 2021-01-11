using System;
using Presentation.View.Home;
using UniPresentation.Presenter;
using UniRx;

namespace Presentation.Presenter.Home
{
    public sealed class UIHomeMatchingTopPresenter : PresenterBase<UIHomeMatchingTopWindow>
    {
        public UIHomeMatchingTopPresenter(PrefabGenParams prefabGenParams) : base(prefabGenParams)
        {
        }

        public IObservable<Unit> OnTapAutoMatchingButton => TargetView.OnTapAutoMatchButton;
        public IObservable<Unit> OnTapCreateRoomButton => TargetView.OnTapCreateRoomButton;
        public IObservable<Unit> OnTapSearchRoomButton => TargetView.OnTapSearchRoomButton;
        
        
    }
}