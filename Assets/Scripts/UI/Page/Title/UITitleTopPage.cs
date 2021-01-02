using Common.OutGame.Canvases;
using Common.OutGame.Page;
using UI.Presenter.Title;
using UI.View.Title;
using UI.View.Title.Def;
using UniRx;

namespace UI.Page.Title
{
    public sealed class UITitleTopPage : PageBase
    {
        private readonly UITitleBackGroundPresenter _backGroundPresenter;
        private readonly UITitleStaffCreditPresenter _staffCreditPresenter;

        public UITitleTopPage(AppCanvasParams canvasParams)
        {
            _backGroundPresenter =
                CreatePresenter<UITitleBackGroundPresenter, UITitleBackGroundWindow>(canvasParams.App0Canvas,
                    UITitlePrefabPathDef.UITitleBackgroundWindow);

            _staffCreditPresenter =
                CreatePresenter<UITitleStaffCreditPresenter, UITitleStaffCreditDialog>(canvasParams.App1Canvas,
                    UITitlePrefabPathDef.UITitleStaffCreditDialog);

            _backGroundPresenter.SetActive(true);

            // イベントの購読
            _backGroundPresenter
                .CreditButtonObservable
                .Subscribe(async _ => await _staffCreditPresenter.ShowAsync())
                .AddTo(_backGroundPresenter.TargetView);

            _staffCreditPresenter
                .ReturnButtonAsObservable
                .Subscribe(async _ => await _staffCreditPresenter.HideAsync())
                .AddTo(_staffCreditPresenter.TargetView);
        }
    }
}