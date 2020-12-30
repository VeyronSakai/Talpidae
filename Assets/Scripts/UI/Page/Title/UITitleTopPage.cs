using Common.OutGame.Canvases;
using Common.OutGame.Presenter;
using UI.Presenter.Title;
using UI.View.Title;
using UI.View.Title.Def;
using UniRx;

namespace UI.Page.Title
{
    public sealed class UITitleTopPage
    {
        private readonly UITitleBackGroundPresenter _backGroundPresenter;
        private UITitleStaffCreditPresenter<UITitleStaffCreditDialog> _staffCreditPresenter;

        public UITitleTopPage(AppCanvasParams canvasParams)
        {
            _backGroundPresenter = new UITitleBackGroundPresenter(canvasParams.App0Canvas);

            _backGroundPresenter
                .CreditButtonObservable
                .Subscribe(_ => Temp(canvasParams))
                .AddTo(_backGroundPresenter.BackGroundWindow);
        }

        private void Temp(AppCanvasParams canvasParams)
        {
            var commonParams =
                PresenterCommonArgsFactory.Create(canvasParams.App0Canvas, UITitleDef.UITitleStaffCreditDialog);

            _staffCreditPresenter =
                new UITitleStaffCreditPresenter<UITitleStaffCreditDialog>(commonParams);
        }
    }
}