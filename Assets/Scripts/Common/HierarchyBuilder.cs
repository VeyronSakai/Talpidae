using Common.Cameras;
using Common.OutGame.Canvases;

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

        public void BuildHierarchy<T>(string cameraPrefabPath) where T : CameraBase
        {
            var camera = _cameraBuilder.BuildCamera<T>(cameraPrefabPath);

            _canvasesBuilder.BuildCanvases(camera);
        }
    }
}