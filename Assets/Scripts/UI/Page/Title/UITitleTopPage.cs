using Common;
using Common.OutGame.Canvases;
using Common.OutGame.Presenter;
using UI.Presenter.Title;
using UI.View.Title;
using UI.View.Title.Def;
using UniRx;

namespace UI.Page.Title
{
    public sealed class UITitleTopPage
    {
        private readonly UITitleBackGroundPresenter _backGroundPresenter;
        private UITitleStaffCreditPresenter _staffCreditPresenter;
        private UITitleTouchBlockPresenter _touchBlockPresenter;

        public UITitleTopPage(AppCanvasParams canvasParams)
        {
            var backgroundWindowParams = PrefabGenParamsFactory.Create(canvasParams.App0Canvas,
                UITitleDef.UITitleBackgroundWindowPath);

            _backGroundPresenter =
                PresenterFactory<UITitleBackGroundPresenter, UITitleBackGroundWindow>.Create(backgroundWindowParams);

            _backGroundPresenter
                .CreditButtonObservable
                .Subscribe(_ => ShowStaffCredit(canvasParams))
                .AddTo(_backGroundPresenter.TargetView);
        }

        private void ShowStaffCredit(AppCanvasParams canvasParams)
        {
            var blockArgs =
                PrefabGenParamsFactory.Create(canvasParams.App1Canvas, UITitleDef.UITitleTouchBlockWindow);

            _touchBlockPresenter =
                PresenterFactory<UITitleTouchBlockPresenter, UITitleTouchBlockWindow>.Create(blockArgs);

            var staffCreditParams =
                PrefabGenParamsFactory.Create(canvasParams.App1Canvas, UITitleDef.UITitleStaffCreditDialog);

            _staffCreditPresenter =
                PresenterFactory<UITitleStaffCreditPresenter, UITitleStaffCreditDialog>.Create(staffCreditParams);
        }
    }
}