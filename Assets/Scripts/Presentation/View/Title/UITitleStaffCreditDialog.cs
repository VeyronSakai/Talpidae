using System;
using Common.OutGame.Presentation.View;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.View.Title
{
    public sealed class UITitleStaffCreditDialog : ViewBase
    {
        [SerializeField] private Button returnButton = default;
        public IObservable<Unit> OnTapReturnButton => returnButton.OnClickAsObservable();
    }
}