using System;
using Presentation.View.InGame;
using UniPresentation.Presenter;
using UnityEngine;

namespace Presentation.Presenter.InGame
{
    public sealed class UIInGameBattlePresenter : PresenterBase<UIInGameBattleWindow>
    {
        public IObservable<Vector2> MoveDir => TargetView.MoveDir;

        public UIInGameBattlePresenter(PrefabGenParams prefabGenParams) : base(prefabGenParams)
        {
        }

        public void InitializeUIInGameBattleWindow(Camera camera)
        {
            TargetView.InitializeVirtualPad(camera);
        }
    }
}