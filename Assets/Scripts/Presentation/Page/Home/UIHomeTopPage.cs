using Presentation.Def;
using Presentation.Presenter.Home;
using Presentation.View.Home;
using UniPresentation.Canvases;
using UniPresentation.Page;
using UniRx;

namespace Presentation.Page.Home
{
    public sealed class UIHomeTopPage : PageBase
    {
        private readonly UIHomeBackgroundPresenter _backgroundPresenter;

        public UIHomeTopPage(CanvasContainer canvasContainer) : base(canvasContainer)
        {
            _backgroundPresenter =
                CreatePresenter<UIHomeBackgroundPresenter, UIHomeBackgroundWindow>(canvasContainer.Canvases[0],
                    UIHomePrefabPathDef.UIHomeBackgroundWindow);

            _backgroundPresenter.SetActiveView(true);

            _backgroundPresenter
                .OnTapMatchingButton
                .Subscribe(_ => ShowPage<UIHomeMatchingPage>(canvasContainer))
                .AddTo(_backgroundPresenter.TargetView);
        }
    }
}