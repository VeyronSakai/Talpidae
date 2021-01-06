using Common.OutGame.Canvas;
using Common.OutGame.Presentation.Presenter;
using Common.OutGame.Presentation.View;

namespace Common.OutGame.Presentation.Page
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