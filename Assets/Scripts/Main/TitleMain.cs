using OutGame;

namespace Main
{
    public sealed class TitleMain : MainBase
    {
        private HierarchyBuilder _hierarchyBuilder;

        protected override void Inject()
        {
            var titleMainTransform = transform;

            var titleCameraBuilder = new CameraBuilder(titleMainTransform);
            var canvasBuilder = new CanvasBuilder(titleMainTransform);
            _hierarchyBuilder = new HierarchyBuilder(titleCameraBuilder, canvasBuilder);
        }

        protected override void OnAwake()
        {
            _hierarchyBuilder.BuildHierarchy();
        }

        protected override void OnStart()
        {
        }

        protected override void OnUpdate()
        {
        }
    }
}