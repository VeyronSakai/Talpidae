using Common;
using Common.Camera;
using Common.OutGame.Canvases;
using Common.OutGame.Def;
using Presentation.Page.Home;

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
            _hierarchy = _hierarchyBuilder.BuildHierarchy<HomeCamera>(UICommonDef.HomeCameraPrefabPath);
        }

        protected override void OnStart()
        {
            new UIHomeTopPage(_hierarchy.AppCanvasContainer);
        }

        protected override void OnUpdate()
        {
        }
    }
}