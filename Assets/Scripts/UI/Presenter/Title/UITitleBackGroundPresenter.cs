using OutGame.Common.Canvases;
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

        public UITitleBackGroundPresenter(AppCanvas canvas)
        {
            _backGroundWindow =
                PrefabFactory.Create<UITitleBackGroundWindow>(UITitleDef.UITitleBackgroundWindowPath, canvas.GetTransform());
            
            _backGroundWindow.TapToStartButtonObservable.Subscribe(_ => Debug.Log("test")).AddTo(_backGroundWindow);
            _backGroundWindow.CreditButtonObservable.Subscribe(_ => Debug.Log("Creditボタン")).AddTo(_backGroundWindow);
        }
    }
}