using System;
using UniPresentation.View;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.View.Home
{
    public sealed class UIHomeBackgroundWindow : ViewBase
    {
        [SerializeField] private Button gachaButton = default;
        [SerializeField] private Button costumeButton = default;
        [SerializeField] private Button matchingButton = default;

        public IObservable<Unit> OnTapGachaButton => gachaButton.OnClickAsObservable();
        public IObservable<Unit> OnTapCostumeButton => costumeButton.OnClickAsObservable();
        public IObservable<Unit> OnTapMatchingButton => matchingButton.OnClickAsObservable();
    }
}