using Common;
using Common.Camera;
using Common.OutGame.Canvases;

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

        public Hierarchy BuildHierarchy<T>(string cameraPrefabPath) where T : CameraBase
        {
            var camera = _cameraBuilder.BuildCamera<T>(cameraPrefabPath);

            var canvasContainer = _canvasesBuilder.BuildCanvases(camera);

            var hierarchy = new Hierarchy(canvasContainer, camera);
            return hierarchy;
        }
    }
}