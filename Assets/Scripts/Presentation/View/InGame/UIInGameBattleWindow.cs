using System;
using Domain.Model;
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
        [SerializeField] private Text scoreText = default;
        [SerializeField] private Text timeLimitText = default;

        public IObservable<Vector2> MoveDir => virtualPad.MoveDir;
        public IObservable<Unit> OnTapCameraButton => cameraButton.OnClickAsObservable();

        public void InitializeVirtualPad(Camera targetCamera)
        {
            virtualPad.Initialize(targetCamera);
        }

        public void UpdateScoreText(Score score)
        {
            scoreText.text = score.ToString();
        }

        public void UpdateTimeLimitText(uint timeLimitSeconds)
        {
            var minutes = timeLimitSeconds / 60;
            var seconds = timeLimitSeconds % 60;

            timeLimitText.text = $"{minutes.ToString()}:{seconds.ToString()}";
        }
    }
}