using Cameras;
using Canvases;
using Common;
using Common.OutGame.Def;
using Presentation.Page.Title;
using UniPresentation.Camera;
using UniPresentation.Page;

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
            _hierarchy =
                _hierarchyBuilder.BuildHierarchy<TitleCamera>(UICommonDef.TitleCameraPrefabPath,
                    UICommonDef.CameraRootName);
        }

        protected override void OnStart()
        {
            PageFactory<UITitleTopPage>.Create(_hierarchy.CanvasContainer);
        }

        protected override void OnUpdate()
        {
        }
    }
}