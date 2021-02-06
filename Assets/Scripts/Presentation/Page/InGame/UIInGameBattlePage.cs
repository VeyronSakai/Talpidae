using System;
using Presentation.Def;
using Presentation.Presenter.InGame;
using Presentation.View.InGame;
using UniPresentation.Canvases;
using UniPresentation.Page;
using UniRx;
using UnityEngine;

namespace Presentation.Page.InGame
{
    public sealed class UIInGameBattlePage : PageBase
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
    }
}