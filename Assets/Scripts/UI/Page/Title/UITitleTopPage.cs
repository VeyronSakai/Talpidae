using UI.Presenter.Title;
using UnityEngine;

namespace UI.Page.Title
{
    public sealed class UITitleTopPage
    {
        private UITitleBackGroundPresenter _backGroundPresenter;

        public UITitleTopPage(Transform parent)
        {
            _backGroundPresenter = new UITitleBackGroundPresenter(parent);
        }
    }
}