using OutGame.Common.Cameras;
using OutGame.Common.Canvases;

namespace OutGame.Common
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

        public void BuildHierarchy()
        {
            var titleCamera = _cameraBuilder.BuildCamera();

            _canvasBuilder.BuildCanvas(titleCamera);
        }
    }
}