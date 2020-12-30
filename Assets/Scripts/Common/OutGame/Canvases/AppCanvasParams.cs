namespace Common.OutGame.Canvases
{
    public sealed class AppCanvasParams
    {
        public AppCanvasParams(AppCanvas app0Canvas, AppCanvas app1Canvas)
        {
            App0Canvas = app0Canvas;
            App1Canvas = app1Canvas;
        }

        // TODO: 他のAppCanvasも持たせる
        public AppCanvas App0Canvas { get; }
        public AppCanvas App1Canvas { get; }
    }
}