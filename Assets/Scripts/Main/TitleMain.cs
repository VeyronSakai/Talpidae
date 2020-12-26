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
            BuildHierarchy();
        }

        protected override void OnStart()
        {
        }

        protected override void OnUpdate()
        {
        }


        private void BuildHierarchy()
        {
            var titleCamera = BuildCameras();
            
            BuildCanvases(titleCamera);
        }

        private void BuildCanvases(ICamera titleCamera)
        {
            var canvasRoot = EmptyObjectFactory.Create(CanvasRootName, transform);
            var app0Canvas = PrefabFactory.Create<AppCanvas>(App0CanvasPath, canvasRoot.transform);
            app0Canvas.SetCamera(titleCamera);

            PrefabFactory.Create<UITitleBackGroundWindow>(UITitleBackgroundWindowPath, app0Canvas.transform);
        }

        private TitleCamera BuildCameras()
        {
            var cameraRoot = EmptyObjectFactory.Create(CameraRootName, transform);
            var titleCamera = PrefabFactory.Create<TitleCamera>(TitleCameraPath, cameraRoot.transform);
            return titleCamera;
        }
    }
}