using Common;
using Common.OutGame.Canvases;
using Common.OutGame.Page;
using Common.OutGame.Presenter;
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

            _backGroundPresenter
                .CreditButtonObservable
                .Subscribe(_ => ShowStaffCredit(canvasParams))
                .AddTo(_backGroundPresenter.TargetView);
        }

        private void ShowStaffCredit(AppCanvasParams canvasParams)
        {
            _touchBlockPresenter =
                CreatePresenter<UITitleTouchBlockPresenter, UITitleTouchBlockWindow>(canvasParams.App0Canvas,
                    UITitlePrefabPathDef.UITitleTouchBlockWindow);

            _staffCreditPresenter =
                CreatePresenter<UITitleStaffCreditPresenter, UITitleStaffCreditDialog>(canvasParams.App1Canvas,
                    UITitlePrefabPathDef.UITitleStaffCreditDialog);
        }
    }
}