using System.Collections.Generic;
using UniPresentation.Canvases;

namespace Canvases
{
    public class CanvasContainer : ICanvasContainer
    {
        public List<ICanvas> Canvases { get; }

        public CanvasContainer(List<ICanvas> canvases)
        {
            Canvases = canvases;
        }
    }
}