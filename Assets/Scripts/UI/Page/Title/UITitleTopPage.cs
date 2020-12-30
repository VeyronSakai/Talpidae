using OutGame.Common.Canvases;
using UI.Presenter.Title;
using UniRx;

namespace UI.Page.Title
{
    public sealed class UITitleTopPage
    {
        private readonly UITitleBackGroundPresenter _backGroundPresenter;

        public UITitleTopPage(AppCanvasParams canvasParams)
        {
            _backGroundPresenter = new UITitleBackGroundPresenter(canvasParams.App0Canvas);

            _backGroundPresenter.CreditButtonObservable.Subscribe(_ => _backGroundPresenter.Dispose()).AddTo(_backGroundPresenter.BackGroundWindow);
        }
    }
}