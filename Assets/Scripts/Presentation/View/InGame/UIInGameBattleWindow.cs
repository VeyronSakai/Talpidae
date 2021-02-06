using System;
using UniPresentation.View;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.View.InGame
{
    public sealed class UIInGameBattleWindow : ViewBase
    {
        [SerializeField] private VirtualPad virtualPad = default;
        [SerializeField] private Button cameraButton = default;

        public IObservable<Vector2> MoveDir => virtualPad.MoveDir;
        public IObservable<Unit> OnTapCameraButton => cameraButton.OnClickAsObservable();

        public void InitializeVirtualPad(Camera targetCamera)
        {
            virtualPad.Initialize(targetCamera);
        }
    }
}