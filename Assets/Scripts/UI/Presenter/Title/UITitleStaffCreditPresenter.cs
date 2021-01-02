using System;
using Common.OutGame.Presenter;
using Cysharp.Threading.Tasks;
using UI.View.Title;
using UniRx;

namespace UI.Presenter.Title
{
    public sealed class UITitleStaffCreditPresenter : PresenterBase<UITitleStaffCreditDialog>
    {
        public IObservable<Unit> ReturnButtonAsObservable => TargetView.ReturnButtonAsObservable;

        public UITitleStaffCreditPresenter(PrefabGenParams prefabGenParams) : base(prefabGenParams)
        {
        }

        public async UniTask ShowAsync()
        {
            SetActiveTouchBlock(true);
            SetActive(true);
            await TargetView.PlayOpenAnimationAsync();
        }

        public async UniTask HideAsync()
        {
            SetActiveTouchBlock(false);
            await TargetView.PlayCloseAnimationAsync();
            SetActive(false);
        }
    }
}