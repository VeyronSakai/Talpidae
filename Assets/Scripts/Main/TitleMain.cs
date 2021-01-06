using Common;
using Common.Camera;
using Common.OutGame.Canvas;
using Common.OutGame.Def;
using UI.Page.Title;

namespace Main
{
    public sealed class TitleMain : MainBase
    {
        private HierarchyBuilder _hierarchyBuilder;
        private Hierarchy _hierarchy;

        protected override void Inject()
        {
            var titleMainTransform = transform;

            var titleCameraBuilder = new CameraBuilder(titleMainTransform);
            var canvasesBuilder = new CanvasesBuilder(titleMainTransform);
            _hierarchyBuilder = new HierarchyBuilder(titleCameraBuilder, canvasesBuilder);
        }

        protected override void OnAwake()
        {
            _hierarchy = _hierarchyBuilder.BuildHierarchy<TitleCamera>(UICommonDef.TitleCameraPrefabPath);
        }

        protected override void OnStart()
        {
            new UITitleTopPage(_hierarchy.AppCanvasContainer);
        }

        protected override void OnUpdate()
        {
        }
    }
}