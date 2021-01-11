using UniPresentation.Shared.Canvases;

namespace Presentation.Canvases
{
    public class AppCanvasContainer : ICanvasContainer
    {
        // TODO: 他のAppCanvasも持たせる
        public ICanvas App0Canvas { get; }
        public ICanvas App1Canvas { get; }

        public AppCanvasContainer(ICanvas app0Canvas, ICanvas app1Canvas)
        {
            App0Canvas = app0Canvas;
            App1Canvas = app1Canvas;
        }
    }
}