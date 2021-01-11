using Cysharp.Threading.Tasks;
using Presentation.Def;
using Presentation.Presenter.Home;
using Presentation.View.Home;
using UniPresentation.Page;
using UniPresentation.Shared.Canvases;

namespace Presentation.Page.Home
{
    public sealed class UIHomeMatchingPage : PageBase
    {
        private readonly UIHomeMatchingTopPresenter _matchingTopPresenter;

        public UIHomeMatchingPage(ICanvasContainer canvasContainer) : base(canvasContainer)
        {
            _matchingTopPresenter =
                CreatePresenter<UIHomeMatchingTopPresenter, UIHomeMatchingTopWindow>(canvasContainer.App0Canvas,
                    UIHomePrefabPathDef.UIHomeMatchingTopWindow);

            _matchingTopPresenter.ShowWindowCommonAsync().Forget();
        }
    }
}