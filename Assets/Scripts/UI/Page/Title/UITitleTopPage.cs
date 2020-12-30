using OutGame.Common.Canvases;
using UI.Presenter.Title;

namespace UI.Page.Title
{
    public sealed class UITitleTopPage
    {
        private UITitleBackGroundPresenter _backGroundPresenter;

        public UITitleTopPage(AppCanvasParams canvasParams)
        {
            _backGroundPresenter = new UITitleBackGroundPresenter(canvasParams.App0Canvas);
        }
    }
}