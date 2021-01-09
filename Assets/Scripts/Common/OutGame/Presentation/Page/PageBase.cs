using System;
using System.Collections.Generic;
using Common.OutGame.Canvas;
using Common.OutGame.Presentation.Presenter;
using Common.OutGame.Presentation.View;

namespace Common.OutGame.Presentation.Page
{
    public abstract class PageBase : IPage, IDisposable 
    {
        private readonly List<IPresenter> _presenters = new List<IPresenter>();

        protected TPresenter CreatePresenter<TPresenter, TView>(AppCanvas appCanvas, string prefabPath)
            where TPresenter : PresenterBase<TView> where TView : ViewBase
        {
            var prefabGenParams = PrefabGenParamsFactory.Create(appCanvas, prefabPath);

            var presenter = PresenterFactory<TPresenter, TView>.Create(prefabGenParams);

            _presenters.Add(presenter);

            return presenter;
        }

        protected void ShowPage<T>(AppCanvasContainer canvasContainer) where T : IPage
        {
            SetActivePage(false);
            PageFactory<T>.Create(canvasContainer);
        }

        public virtual void Dispose()
        {
            foreach (var presenter in _presenters)
            {
                presenter.Dispose();
            }
        }

        private void SetActivePage(bool isActive)
        {
            foreach (var presenter in _presenters)
            {
                presenter.SetActiveView(isActive);
            }
        }
    }
}