using Canvases;
using Common;
using UniPresentation.Camera;

namespace Main
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

            var canvasContainer = _canvasesBuilder.BuildCanvases(camera);

            var hierarchy = new Hierarchy(canvasContainer, camera);
            return hierarchy;
        }
    }
}