using Common.OutGame.Canvases;
using Common.OutGame.Presentation.Page;
using Cysharp.Threading.Tasks;
using Presentation.Def;
using Presentation.Presenter.Home;
using Presentation.View.Home;

namespace Presentation.Page.Home
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