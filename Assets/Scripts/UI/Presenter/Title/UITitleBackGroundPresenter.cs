using System;
using OutGame.Common.Canvases;
using PrefabGenerator;
using UI.View.Title;
using UI.View.Title.Def;
using UniRx;

namespace UI.Presenter.Title
{
    public sealed class UITitleBackGroundPresenter : IDisposable
    {
        public UITitleBackGroundWindow BackGroundWindow;

        public IObservable<Unit> CreditButtonObservable => BackGroundWindow.CreditButtonObservable;
        public IObservable<Unit> TapToStartButtonObservable => BackGroundWindow.TapToStartButtonObservable;

        public UITitleBackGroundPresenter(AppCanvas canvas)
        {
            BackGroundWindow =
                PrefabFactory.Create<UITitleBackGroundWindow>(UITitleDef.UITitleBackgroundWindowPath,
                    canvas.GetTransform());
        }

        public void Dispose()
        {
            PrefabDestroyer.Destroy(ref BackGroundWindow);
        }
    }
}