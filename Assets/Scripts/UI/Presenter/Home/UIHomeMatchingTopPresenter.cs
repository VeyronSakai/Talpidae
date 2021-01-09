using System;
using Common.OutGame.Presentation.Presenter;
using UI.View.Home;
using UniRx;

namespace UI.Presenter.Home
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