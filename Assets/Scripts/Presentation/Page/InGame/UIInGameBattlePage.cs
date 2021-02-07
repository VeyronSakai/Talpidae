using System;
using Application;
using Domain.Model;
using Presentation.Def;
using Presentation.Presenter.InGame;
using Presentation.View.InGame;
using UniPresentation.Canvases;
using UniPresentation.Page;
using UniRx;
using UnityEngine;

namespace Presentation.Page.InGame
{
    public sealed class UIInGameBattlePage : PageBase, IUIInGameBattlePage
    {
        public IObservable<Vector2> MoveDir => _inGameBattlePresenter.MoveDir;
        public IObservable<Unit> OnTapCameraButton => _inGameBattlePresenter.OnTapCameraButton;

        private readonly UIInGameBattlePresenter _inGameBattlePresenter;

        public UIInGameBattlePage(CanvasContainer canvasContainer) : base(canvasContainer)
        {
            _inGameBattlePresenter =
                CreatePresenter<UIInGameBattlePresenter, UIInGameBattleWindow>(canvasContainer.Canvases[0],
                    UIInGamePrefabPathDef.UIInGameBattleWindow);

            _inGameBattlePresenter.SetActiveView(true);

            _inGameBattlePresenter.InitializeUIInGameBattleWindow(canvasContainer.Canvases[0].GetCamera());
        }

        private void UpdateScoreText(Score score)
        {
            _inGameBattlePresenter.UpdateScoreText(score);
        }

        public void UpdateLimitTimeText(uint leftTime)
        {
            _inGameBattlePresenter.UpdateLimitTimeText(leftTime);
        }
    }
}