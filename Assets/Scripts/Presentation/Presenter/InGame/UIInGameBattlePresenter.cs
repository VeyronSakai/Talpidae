using System;
using Domain.Model;
using Presentation.View.InGame;
using UniPresentation.Presenter;
using UniRx;
using UnityEngine;

namespace Presentation.Presenter.InGame
{
    public sealed class UIInGameBattlePresenter : PresenterBase<UIInGameBattleWindow>
    {
        public IObservable<Vector2> MoveDir => TargetView.MoveDir;
        public IObservable<Unit> OnTapCameraButton => TargetView.OnTapCameraButton;

        public UIInGameBattlePresenter(PrefabGenParams prefabGenParams) : base(prefabGenParams)
        {
        }

        public void InitializeUIInGameBattleWindow(Camera camera)
        {
            TargetView.InitializeVirtualPad(camera);
        }

        public void UpdateScoreText(Score score)
        {
            TargetView.UpdateScoreText(score);
        }
    }
}