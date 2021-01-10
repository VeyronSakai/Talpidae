using System;
using Common.OutGame.Presentation.View;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UI.View.Home
{
    public sealed class UIHomeMatchingTopWindow : ViewBase
    {
        [SerializeField] private Button autoMatchButton = default;
        [SerializeField] private Button createRoomButton = default;
        [SerializeField] private Button searchRoomButton = default;

        public IObservable<Unit> OnTapAutoMatchButton => autoMatchButton.OnClickAsObservable();
        public IObservable<Unit> OnTapCreateRoomButton => createRoomButton.OnClickAsObservable();
        public IObservable<Unit> OnTapSearchRoomButton => searchRoomButton.OnClickAsObservable();
    }
}