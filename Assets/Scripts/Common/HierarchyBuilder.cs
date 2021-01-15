using System.Collections.Generic;
using Canvases;
using Common.OutGame.Def;
using UniPresentation.Camera;
using UniPresentation.Canvases;

namespace Common
{
    public sealed class HierarchyBuilder
    {
        private readonly CameraBuilder _cameraBuilder;
        private readonly CanvasesBuilder _canvasesBuilder;

        public HierarchyBuilder(CameraBuilder cameraBuilder, CanvasesBuilder canvasesBuilder)
        {
            _cameraBuilder = cameraBuilder;
            _canvasesBuilder = canvasesBuilder;
        }

        public Hierarchy BuildHierarchy<T>(string cameraPrefabPath, string cameraRootName) where T : CameraBase
        {
            var camera = _cameraBuilder.BuildCamera<T>(cameraPrefabPath, cameraRootName);

            var canvasPaths = new List<string>()
            {
                UICommonDef.App0CanvasPrefabPath,
                UICommonDef.App1CanvasPrefabPath
            };

            var canvasPathParams = new CanvasPathParams(UICommonDef.CameraRootName, canvasPaths);

            var canvasContainer =
                _canvasesBuilder.BuildCanvases<AppCanvasContainer>(camera, canvasPathParams,
                    UICommonDef.UITouchBlockWindow);

            var hierarchy = new Hierarchy(canvasContainer, camera);
            return hierarchy;
        }
    }
}