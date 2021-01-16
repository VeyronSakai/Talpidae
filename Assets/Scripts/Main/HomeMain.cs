using System.Collections.Generic;
using Common.Cameras;
using Common.Def;
using Presentation.Page.Home;
using UniPresentation.Camera;
using UniPresentation.Canvases;
using UniPresentation.Hierarchy;
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
            var canvasPaths = new List<string>()
            {
                UICommonDef.App0CanvasPrefabPath,
                UICommonDef.App1CanvasPrefabPath
            };

            _hierarchy =
                _hierarchyBuilder.BuildHierarchy<HomeCamera>
                (
                    UICommonDef.CameraRootName,
                    UICommonDef.HomeCameraPrefabPath,
                    UICommonDef.CanvasRootName,
                    canvasPaths,
                    UICommonDef.UITouchBlockWindow
                );
        }

        protected override void OnStart()
        {
            PageFactory<UIHomeTopPage>.Create(_hierarchy.CanvasContainer);
        }

        protected override void OnUpdate()
        {
        }
    }
}