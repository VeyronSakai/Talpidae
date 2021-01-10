using System;
using Common.OutGame.Presentation.Presenter;
using Cysharp.Threading.Tasks;
using Presentation.View.Title;
using UniRx;

namespace Presentation.Presenter.Title
{
    public sealed class UITitleStaffCreditPresenter : PresenterBase<UITitleStaffCreditDialog>
    {
        public IObservable<Unit> ReturnButtonAsObservable => TargetView.OnTapReturnButton;

        public UITitleStaffCreditPresenter(PrefabGenParams prefabGenParams) : base(prefabGenParams)
        {
        }

        public async UniTask ShowAsync()
        {
            await ShowDialogCommonAsync();
        }

        public async UniTask HideAsync()
        {
            await HideDialogCommonAsync();
        }
    }
}