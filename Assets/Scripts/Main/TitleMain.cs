using Cameras;
using Canvases;
using PrefabGenerator;
using UI.Title;

namespace Main
{
    public sealed class TitleMain : MainBase
    {
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
            var canvasRoot = EmptyObjectFactory.Create(TitleDef.CanvasRootName, transform);
            var app0Canvas = PrefabFactory.Create<AppCanvas>(TitleDef.App0CanvasPath, canvasRoot.transform);
            app0Canvas.SetCamera(titleCamera);

            PrefabFactory.Create<UITitleBackGroundWindow>(TitleDef.UITitleBackgroundWindowPath, app0Canvas.transform);
        }

        private TitleCamera BuildCameras()
        {
            var cameraRoot = EmptyObjectFactory.Create(TitleDef.CameraRootName, transform);
            var titleCamera = PrefabFactory.Create<TitleCamera>(TitleDef.TitleCameraPath, cameraRoot.transform);
            return titleCamera;
        }
    }
}