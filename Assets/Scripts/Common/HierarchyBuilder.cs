using Common.Cameras;
using Common.OutGame.Canvases;

namespace Common
{
    public sealed class HierarchyBuilder
    {
        private readonly CameraBuilder _cameraBuilder;
        private readonly CanvasBuilder _canvasBuilder;

        public HierarchyBuilder(CameraBuilder cameraBuilder, CanvasBuilder canvasBuilder)
        {
            _cameraBuilder = cameraBuilder;
            _canvasBuilder = canvasBuilder;
        }

        public void BuildHierarchy<T>(string cameraPrefabPath) where T : CameraBase
        {
            var camera = _cameraBuilder.BuildCamera<T>(cameraPrefabPath);

            _canvasBuilder.BuildCanvases(camera);
        }
    }
}