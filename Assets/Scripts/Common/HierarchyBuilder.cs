using System.Collections.Generic;
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

        public Hierarchy BuildHierarchy<TCamera, TCanvasContainer>
        (
            string cameraRootName,
            string cameraPrefabPath,
            string canvasRootName,
            List<string> canvasPaths,
            string touchBlockWindowPrefabPath
        )
            where TCamera : CameraBase
            where TCanvasContainer : ICanvasContainer
        {
            var camera = _cameraBuilder.BuildCamera<TCamera>(cameraPrefabPath, cameraRootName);

            var canvasPathParams = new CanvasPathParams(canvasRootName, canvasPaths);

            var canvasContainer =
                _canvasesBuilder.BuildCanvases<TCanvasContainer>(camera, canvasPathParams,
                    touchBlockWindowPrefabPath);

            var hierarchy = new Hierarchy(canvasContainer, camera);
            return hierarchy;
        }
    }
}