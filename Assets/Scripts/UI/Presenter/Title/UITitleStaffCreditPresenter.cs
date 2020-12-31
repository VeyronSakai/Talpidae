using System;
using Common.OutGame.Presenter;
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
        
        public void Open()
        {
            SetActive(true);
            SetActiveTouchBlock(true);
        }

        public void Close()
        {
            SetActive(false);
            SetActiveTouchBlock(false);
        }
    }
}