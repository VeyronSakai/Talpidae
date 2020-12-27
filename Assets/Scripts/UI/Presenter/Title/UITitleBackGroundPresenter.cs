using PrefabGenerator;
using UI.View.Title;
using UI.View.Title.Def;
using UniRx;
using UnityEngine;

namespace UI.Presenter.Title
{
    public sealed class UITitleBackGroundPresenter
    {
        private readonly UITitleBackGroundWindow _backGroundWindow;

        public UITitleBackGroundPresenter(Transform parent)
        {
            _backGroundWindow =
                PrefabFactory.Create<UITitleBackGroundWindow>(UITitleDef.UITitleBackgroundWindowPath, parent);
            _backGroundWindow.TapToStartButton.Subscribe(_ => Debug.Log("test")).AddTo(_backGroundWindow);
        }
    }
}