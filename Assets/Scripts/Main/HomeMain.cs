using Cameras;
using Common;
using Common.OutGame.Def;
using Presentation.Canvases;
using Presentation.Page.Home;
using UniPresentation.Camera;
using UniPresentation.Page;

namespace Main
{
    public sealed class HomeMain : MainBase
    {
        private HierarchyBuilder _hierarchyBuilder;
        private Hierarchy _hierarchy;

        protected override void Inject()
        {
            var homeMainTransform = transform;

            var homeCameraBuilder = new CameraBuilder(homeMainTransform);
            var canvasBuilder = new CanvasesBuilder(homeMainTransform);
            _hierarchyBuilder = new HierarchyBuilder(homeCameraBuilder, canvasBuilder);
        }

        protected override void OnAwake()
        {
            _hierarchy =
                _hierarchyBuilder.BuildHierarchy<HomeCamera>(UICommonDef.HomeCameraPrefabPath,
                    UICommonDef.CameraRootName);
        }

        protected override void OnStart()
        {
            PageFactory<UIHomeTopPage, AppCanvasContainer>.Create(_hierarchy.AppCanvasContainer);
        }

        protected override void OnUpdate()
        {
        }
    }
}