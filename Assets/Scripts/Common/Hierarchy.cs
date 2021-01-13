using Presentation.Canvases;
using UniPresentation.Camera;

namespace Common
{
    public class Hierarchy
    {
        public AppCanvasContainer AppCanvasContainer;
        public ICamera Camera;

        public Hierarchy(AppCanvasContainer canvasContainer, ICamera camera)
        {
            AppCanvasContainer = canvasContainer;
            Camera = camera;
        }
    }
}