using System.Collections.Generic;
using Common.Cameras;
using Common.Def;
using UniPresentation.Cameras;
using UniPresentation.Canvases;
using UniPresentation.Hierarchy;

namespace Main
{
    public sealed class GameMain : MainBase
    {
        private HierarchyBuilder _hierarchyBuilder;
        private Hierarchy _hierarchy;

        protected override void Inject()
        {
            var gameMainTransform = transform;

            var homeCameraBuilder = new CameraBuilder(gameMainTransform);
            var canvasBuilder = new CanvasesBuilder(gameMainTransform);
            _hierarchyBuilder = new HierarchyBuilder(homeCameraBuilder, canvasBuilder);
        }

        protected override void OnAwake()
        {
            var canvasPaths = new List<string>()
            {
                UICommonDef.App0CanvasPrefabPath,
                UICommonDef.App1CanvasPrefabPath
            };

            _hierarchy = _hierarchyBuilder.BuildHierarchy<GameCamera>
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
        }

        protected override void OnUpdate()
        {
        }
    }
}