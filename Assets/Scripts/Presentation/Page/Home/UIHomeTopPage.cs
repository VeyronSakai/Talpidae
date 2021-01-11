using Presentation.Canvases;
using Presentation.Def;
using Presentation.Presenter.Home;
using Presentation.View.Home;
using UniPresentation.Page;
using UniRx;

namespace Presentation.Page.Home
{
    public sealed class UIHomeTopPage : PageBase
    {
        private readonly UIHomeBackgroundPresenter _backgroundPresenter;

        public UIHomeTopPage(AppCanvasContainer canvasContainer) : base(canvasContainer)
        {
            _backgroundPresenter =
                CreatePresenter<UIHomeBackgroundPresenter, UIHomeBackgroundWindow>(canvasContainer.App0Canvas,
                    UIHomePrefabPathDef.UIHomeBackgroundWindow);

            _backgroundPresenter.SetActiveView(true);

            _backgroundPresenter
                .OnTapMatchingButton
                .Subscribe(_ => ShowPage<UIHomeMatchingPage, AppCanvasContainer>(canvasContainer))
                .AddTo(_backgroundPresenter.TargetView);
        }
    }
}