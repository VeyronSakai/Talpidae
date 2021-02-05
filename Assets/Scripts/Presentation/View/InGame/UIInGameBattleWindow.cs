using System;
using UniPresentation.View;
using UnityEngine;

namespace Presentation.View.InGame
{
    public sealed class UIInGameBattleWindow : ViewBase
    {
        [SerializeField] private VirtualPad virtualPad = default;

        public IObservable<Vector2> MoveDir => virtualPad.MoveDir;

        public void InitializeVirtualPad(Camera targetCamera)
        {
            virtualPad.Initialize(targetCamera);
        }
    }
}
