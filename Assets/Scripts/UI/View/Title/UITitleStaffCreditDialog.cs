using System;
using Common.OutGame.View;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UI.View.Title
{
    public sealed class UITitleStaffCreditDialog : ViewBase
    {
        [SerializeField] private Button returnButton = default;
        public IObservable<Unit> ReturnButtonAsObservable => returnButton.OnClickAsObservable();
    }
}