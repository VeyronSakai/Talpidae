using Common.Camera;
using Common.OutGame.Canvas;
using Common.OutGame.Def;

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
        }

        protected override void OnUpdate()
        {
        }
    }
}