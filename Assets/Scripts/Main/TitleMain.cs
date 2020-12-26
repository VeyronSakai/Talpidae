using Cameras;
using Canvases;
using PrefabGenerator;
using UI.Title;

namespace Main
{
    public sealed class TitleMain : MainBase
    {
        // GameObject Name
        private const string CanvasRootName = "CanvasRoot";
        private const string CameraRootName = "CameraRoot";

        // Path
        private const string UITitleBackgroundWindowPath = "UI/Title/UITitleBackgroundWindow";
        private const string App0CanvasPath = "Canvases/App0Canvas";
        private const string TitleCameraPath = "Cameras/TitleCamera";

        protected override void Inject()
        {
        }

        protected override void OnAwake()
        {
            // Instantiate Roots
            var canvasRoot = EmptyObjectFactory.Create(CanvasRootName);
            var cameraRoot = EmptyObjectFactory.Create(CameraRootName);

            // Instantiate Camera Prefab
            PrefabFactory.Create<TitleCamera>(TitleCameraPath, cameraRoot.transform);

            // Instantiate Canvases
            var app0Canvas = PrefabFactory.Create<AppCanvas>(App0CanvasPath, canvasRoot.transform);

            PrefabFactory.Create<UITitleBackGroundWindow>(UITitleBackgroundWindowPath, app0Canvas.transform);
        }

        protected override void OnStart()
        {
        }

        protected override void OnUpdate()
        {
        }
    }
}