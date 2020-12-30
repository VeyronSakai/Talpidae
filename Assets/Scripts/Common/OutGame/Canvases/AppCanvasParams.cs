namespace Common.OutGame.Canvases
{
    public sealed class AppCanvasParams
    {
        public AppCanvasParams(AppCanvas app0Canvas)
        {
            App0Canvas = app0Canvas;
        }

        // TODO: 他のAppCanvasも持たせる
        public AppCanvas App0Canvas { get; }
    }
}