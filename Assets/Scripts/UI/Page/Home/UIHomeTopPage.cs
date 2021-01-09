using Common.OutGame.Canvas;
using Common.OutGame.Presentation.Page;
using UI.Def;
using UI.Presenter.Home;
using UI.View.Home;
using UniRx;

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

            _backgroundPresenter.SetActiveView(true);

            _backgroundPresenter
                .MatchingButtonOnClickAsObservable
                .Subscribe(_ => ShowPage<UIHomeMatchingPage>(canvasContainer))
                .AddTo(_backgroundPresenter.TargetView);
        }
    }
}