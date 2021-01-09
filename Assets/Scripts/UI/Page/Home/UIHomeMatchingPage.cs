using Common.OutGame.Canvas;
using Common.OutGame.Presentation.Page;
using Cysharp.Threading.Tasks;
using UI.Def;
using UI.Presenter.Home;
using UI.View.Home;

namespace UI.Page.Home
{
    public sealed class UIHomeMatchingPage : PageBase
    {
        private readonly UIHomeMatchingTopPresenter _matchingTopPresenter;

        public UIHomeMatchingPage(AppCanvasContainer canvasContainer)
        {
            _matchingTopPresenter =
                CreatePresenter<UIHomeMatchingTopPresenter, UIHomeMatchingTopWindow>(canvasContainer.App0Canvas,
                    UIHomePrefabPathDef.UIHomeMatchingTopWindow);

            _matchingTopPresenter.ShowWindowCommonAsync().Forget();
        }
    }
}