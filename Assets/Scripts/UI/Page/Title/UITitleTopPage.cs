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
        private UITitleStaffCreditPresenter _staffCreditPresenter;
        private UITitleTouchBlockPresenter _touchBlockPresenter;

        public UITitleTopPage(AppCanvasParams canvasParams)
        {
            _backGroundPresenter =
                CreatePresenter<UITitleBackGroundPresenter, UITitleBackGroundWindow>(canvasParams.App0Canvas,
                    UITitlePrefabPathDef.UITitleBackgroundWindow);

            _touchBlockPresenter =
                CreatePresenter<UITitleTouchBlockPresenter, UITitleTouchBlockWindow>(canvasParams.App0Canvas,
                    UITitlePrefabPathDef.UITitleTouchBlockWindow);

            _staffCreditPresenter =
                CreatePresenter<UITitleStaffCreditPresenter, UITitleStaffCreditDialog>(canvasParams.App1Canvas,
                    UITitlePrefabPathDef.UITitleStaffCreditDialog);

            _backGroundPresenter.SetActive(true);

            // イベントの購読
            _backGroundPresenter
                .CreditButtonObservable
                .Subscribe(_ => ShowStaffCredit(canvasParams))
                .AddTo(_backGroundPresenter.TargetView);
        }

        private void ShowStaffCredit(AppCanvasParams canvasParams)
        {
            _touchBlockPresenter.SetActive(true);

            _staffCreditPresenter.SetActive(true);
        }
    }
}