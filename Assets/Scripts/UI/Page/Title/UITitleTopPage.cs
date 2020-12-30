using Common.OutGame.Canvases;
using Common.OutGame.Presenter;
using UI.Presenter.Title;
using UI.View.Title.Def;
using UniRx;

namespace UI.Page.Title
{
    public sealed class UITitleTopPage
    {
        private readonly UITitleBackGroundPresenter _backGroundPresenter;
        private UITitleStaffCreditPresenter _staffCreditPresenter;

        public UITitleTopPage(AppCanvasParams canvasParams)
        {
            var backgroundWindowParams = PresenterCommonArgsFactory.Create(canvasParams.App0Canvas,
                UITitleDef.UITitleBackgroundWindowPath);

            _backGroundPresenter = new UITitleBackGroundPresenter(backgroundWindowParams);

            _backGroundPresenter
                .CreditButtonObservable
                .Subscribe(_ => ShowStaffCredit(canvasParams))
                .AddTo(_backGroundPresenter.TargetView);
        }

        private void ShowStaffCredit(AppCanvasParams canvasParams)
        {
            var commonParams =
                PresenterCommonArgsFactory.Create(canvasParams.App0Canvas, UITitleDef.UITitleStaffCreditDialog);

            _staffCreditPresenter = new UITitleStaffCreditPresenter(commonParams);
        }
    }
}