using System;
using PrefabGenerator;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UI.View.Title
{
    public sealed class UITitleBackGroundWindow : PrefabBase
    {
        [SerializeField] private Button tapToStartButton = default;
        [SerializeField] private Button creditButton = default;

        public IObservable<Unit> TapToStartButtonObservable => tapToStartButton.OnClickAsObservable();
        public IObservable<Unit> CreditButtonObservable => creditButton.OnClickAsObservable();
    }
}