using Common.OutGame.Canvas;
using Common.OutGame.Presentation.Page;
using Cysharp.Threading.Tasks;
using UI.Def;
using UI.Presenter.Title;
using UI.View.Title;
using UI.View.Title.Def;
using UniRx;
using UnityEngine.SceneManagement;

namespace UI.Page.Title
{
    public sealed class UITitleTopPage : PageBase
    {
        private readonly UITitleBackGroundPresenter _backGroundPresenter;
        private readonly UITitleStaffCreditPresenter _staffCreditPresenter;

        public UITitleTopPage(AppCanvasContainer canvasContainer)
        {
            _backGroundPresenter =
                CreatePresenter<UITitleBackGroundPresenter, UITitleBackGroundWindow>(canvasContainer.App0Canvas,
                    UITitlePrefabPathDef.UITitleBackgroundWindow);

            _staffCreditPresenter =
                CreatePresenter<UITitleStaffCreditPresenter, UITitleStaffCreditDialog>(canvasContainer.App1Canvas,
                    UITitlePrefabPathDef.UITitleStaffCreditDialog);

            _backGroundPresenter.SetActiveView(true);

            // イベントの購読
            _backGroundPresenter
                .CreditButtonOnClickAsObservable
                .Subscribe(async _ => await _staffCreditPresenter.ShowAsync())
                .AddTo(_backGroundPresenter.TargetView);

            _backGroundPresenter
                .PointerDownAsObservable
                .Subscribe(async _ => await SceneManager.LoadSceneAsync(SceneDef.HomeScene))
                .AddTo(_backGroundPresenter.TargetView);

            _staffCreditPresenter
                .ReturnButtonAsObservable
                .Subscribe(async _ => await _staffCreditPresenter.HideAsync())
                .AddTo(_staffCreditPresenter.TargetView);
        }
    }
}