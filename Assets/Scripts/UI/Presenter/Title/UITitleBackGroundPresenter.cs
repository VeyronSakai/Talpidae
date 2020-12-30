using System;
using Common.OutGame.Canvases;
using PrefabGenerator;
using UI.View.Title;
using UI.View.Title.Def;
using UniRx;

namespace UI.Presenter.Title
{
    public sealed class UITitleBackGroundPresenter : IDisposable
    {
        public UITitleBackGroundWindow BackGroundWindow;

        public UITitleBackGroundPresenter(AppCanvas canvas)
        {
            BackGroundWindow =
                PrefabFactory.Create<UITitleBackGroundWindow>(UITitleDef.UITitleBackgroundWindowPath,
                    canvas.GetTransform());
        }

        public IObservable<Unit> CreditButtonObservable => BackGroundWindow.CreditButtonObservable;
        public IObservable<Unit> TapToStartButtonObservable => BackGroundWindow.TapToStartButtonObservable;

        public void Dispose()
        {
            PrefabDestroyer.Destroy(ref BackGroundWindow);
        }
    }
}