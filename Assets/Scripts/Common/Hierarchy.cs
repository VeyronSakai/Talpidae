using UniPresentation.Camera;
using UniPresentation.Canvases;

namespace Common
{
    public class Hierarchy
    {
        public ICanvasContainer CanvasContainer;
        public ICamera Camera;

        public Hierarchy(ICanvasContainer canvasContainer, ICamera camera)
        {
            CanvasContainer = canvasContainer;
            Camera = camera;
        }
    }
}