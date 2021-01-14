using System.Collections.Generic;
using UniPresentation.Canvases;

namespace Canvases
{
    public class AppCanvasContainer : ICanvasContainer
    {
        public List<ICanvas> Canvases { get; }

        public AppCanvasContainer(ICanvas app0Canvas, ICanvas app1Canvas)
        {
            Canvases = new List<ICanvas>()
            {
                app0Canvas,
                app1Canvas
            };
        }
    }
}