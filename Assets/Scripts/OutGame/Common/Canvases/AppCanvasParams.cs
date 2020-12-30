namespace OutGame.Common.Canvases
{
    public sealed class AppCanvasParams
    {
        // TODO: 他のAppCanvasも持たせる
        public AppCanvas App0Canvas { get; }

        public AppCanvasParams(AppCanvas app0Canvas)
        {
            App0Canvas = app0Canvas;
        }
    }
}