namespace Common.OutGame.Canvas
{
    public class AppCanvasContainer
    {
        // TODO: 他のAppCanvasも持たせる
        public readonly AppCanvas App0Canvas;
        public readonly AppCanvas App1Canvas;

        public AppCanvasContainer(AppCanvas app0Canvas, AppCanvas app1Canvas)
        {
            App0Canvas = app0Canvas;
            App1Canvas = app1Canvas;
        }
    }
}