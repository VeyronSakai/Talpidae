using OutGame.Common.Canvases;
using UI.Presenter.Title;
using UniRx;

namespace UI.Page.Title
{
    public sealed class UITitleTopPage
    {
        private readonly UITitleBackGroundPresenter _backGroundPresenter;
        private UITitleStaffCreditPresenter _staffCreditPresenter;

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
            _staffCreditPresenter = new UITitleStaffCreditPresenter(canvasParams.App0Canvas);
        }
    }
}