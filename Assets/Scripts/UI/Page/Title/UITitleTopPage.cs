using Common.OutGame.Canvas;
using Common.OutGame.Presentation.Page;
using Cysharp.Threading.Tasks;
using UI.Def;
using UI.Presenter.Title;
using UI.View.Title;
using UniRx;
using UnityEngine.SceneManagement;

namespace UI.Page.Title
{
    public sealed class UITitleTopPage : PageBase
    {
        private readonly UITitleBackgroundPresenter _backgroundPresenter;
        private readonly UITitleStaffCreditPresenter _staffCreditPresenter;

        public UITitleTopPage(AppCanvasContainer canvasContainer)
        {
            _backgroundPresenter =
                CreatePresenter<UITitleBackgroundPresenter, UITitleBackgroundWindow>(canvasContainer.App0Canvas,
                    UITitlePrefabPathDef.UITitleBackgroundWindow);

            _staffCreditPresenter =
                CreatePresenter<UITitleStaffCreditPresenter, UITitleStaffCreditDialog>(canvasContainer.App1Canvas,
                    UITitlePrefabPathDef.UITitleStaffCreditDialog);

            _backgroundPresenter.SetActiveView(true);

            // イベントの購読
            _backgroundPresenter
                .CreditButtonOnClickAsObservable
                .Subscribe(async _ => await _staffCreditPresenter.ShowAsync())
                .AddTo(_backgroundPresenter.TargetView);

            _backgroundPresenter
                .PointerDownAsObservable
                .Subscribe(async _ => await SceneManager.LoadSceneAsync(SceneDef.HomeScene))
                .AddTo(_backgroundPresenter.TargetView);

            _staffCreditPresenter
                .ReturnButtonAsObservable
                .Subscribe(async _ => await _staffCreditPresenter.HideAsync())
                .AddTo(_staffCreditPresenter.TargetView);
        }
    }
}