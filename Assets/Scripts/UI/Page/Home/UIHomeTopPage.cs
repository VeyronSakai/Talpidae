using Common.OutGame.Canvas;
using Common.OutGame.Presentation.Page;
using UI.Def;
using UI.Presenter.Home;
using UI.View.Home;

namespace UI.Page.Home
{
    public sealed class UIHomeTopPage : PageBase
    {
        private readonly UIHomeBackgroundPresenter _backgroundPresenter;

        public UIHomeTopPage(AppCanvasContainer canvasContainer)
        {
            _backgroundPresenter =
                CreatePresenter<UIHomeBackgroundPresenter, UIHomeBackgroundWindow>(canvasContainer.App0Canvas,
                    UIHomePrefabPathDef.UIHomeBackgroundWindow);
        }
    }
}