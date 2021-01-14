using Cysharp.Threading.Tasks;
using Presentation.Def;
using Presentation.Presenter.Home;
using Presentation.View.Home;
using UniPresentation.Canvases;
using UniPresentation.Page;

namespace Presentation.Page.Home
{
    public sealed class UIHomeMatchingPage : PageBase
    {
        private readonly UIHomeMatchingTopPresenter _matchingTopPresenter;

        public UIHomeMatchingPage(ICanvasContainer canvasContainer) : base(canvasContainer)
        {
            _matchingTopPresenter =
                CreatePresenter<UIHomeMatchingTopPresenter, UIHomeMatchingTopWindow>(canvasContainer.Canvases[0],
                    UIHomePrefabPathDef.UIHomeMatchingTopWindow);

            _matchingTopPresenter.ShowWindowCommonAsync().Forget();
        }
    }
}