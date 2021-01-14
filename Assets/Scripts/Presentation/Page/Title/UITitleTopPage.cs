using Cysharp.Threading.Tasks;
using Presentation.Def;
using Presentation.Presenter.Title;
using Presentation.View.Title;
using UniPresentation.Canvases;
using UniPresentation.Page;
using UniRx;
using UnityEngine.SceneManagement;

namespace Presentation.Page.Title
{
    public sealed class UITitleTopPage : PageBase
    {
        private readonly UITitleBackgroundPresenter _backgroundPresenter;
        private readonly UITitleStaffCreditPresenter _staffCreditPresenter;

        public UITitleTopPage(ICanvasContainer canvasContainer) : base(canvasContainer)
        {
            _backgroundPresenter =
                CreatePresenter<UITitleBackgroundPresenter, UITitleBackgroundWindow>(canvasContainer.Canvases[0],
                    UITitlePrefabPathDef.UITitleBackgroundWindow);

            _staffCreditPresenter =
                CreatePresenter<UITitleStaffCreditPresenter, UITitleStaffCreditDialog>(canvasContainer.Canvases[1],
                    UITitlePrefabPathDef.UITitleStaffCreditDialog);

            _backgroundPresenter.SetActiveView(true);

            // イベントの購読
            _backgroundPresenter
                .OnTapCreditButton
                .Subscribe(async _ => await _staffCreditPresenter.ShowAsync())
                .AddTo(_backgroundPresenter.TargetView);

            _backgroundPresenter
                .OnPointerDown
                .Subscribe(async _ => await SceneManager.LoadSceneAsync(SceneDef.HomeScene))
                .AddTo(_backgroundPresenter.TargetView);

            _staffCreditPresenter
                .ReturnButtonAsObservable
                .Subscribe(async _ => await _staffCreditPresenter.HideAsync())
                .AddTo(_staffCreditPresenter.TargetView);
        }
    }
}