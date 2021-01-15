using System.Collections.Generic;
using UniPresentation.Canvases;

namespace Canvases
{
    public class AppCanvasContainer : ICanvasContainer
    {
        public List<ICanvas> Canvases { get; }

        public AppCanvasContainer(List<ICanvas> canvases)
        {
            Canvases = canvases;
        }
    }
}