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
        
        public IObservable<Unit> TapToStartButton => tapToStartButton.OnClickAsObservable();
    }
}