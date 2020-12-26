using System.Text;
using PrefabGenerator;
using UI.Title;
using UnityEngine;

namespace Main
{
    public sealed class TitleMain : MainBase
    {
        private const string CanvasRoot = "CanvasRoot";
        private const string UITitleBackgroundWindow = "UI/Title/UITitleBackgroundWindow";

        protected override void Inject()
        {
        }

        protected override void OnAwake()
        {
        }

        protected override void OnStart()
        {
            var canvasRoot = EmptyObjectFactory.Create(CanvasRoot);
            var titleCanvas = EmptyObjectFactory.Create("TitleCanvas", canvasRoot.transform);
            titleCanvas.AddComponent<Canvas>();
            PrefabFactory.Create<UITitleBackGroundWindow>(UITitleBackgroundWindow, titleCanvas.transform);
        }

        protected override void OnUpdate()
        {
        }
    }
}