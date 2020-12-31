using Common.OutGame.Canvases;
using Common.OutGame.Presenter;
using Common.OutGame.View;

namespace Common.OutGame.Page
{
    public abstract class PageBase
    {
        protected static TPresenter CreatePresenter<TPresenter, TView>(AppCanvas appCanvas, string prefabPath)
            where TPresenter : PresenterBase<TView> where TView : ViewBase
        {
            var prefabGenParams = PrefabGenParamsFactory.Create(appCanvas, prefabPath);

            var presenter = PresenterFactory<TPresenter, TView>.Create(prefabGenParams);

            return presenter;
        }
    }
}