using Common.Camera;
using Common.OutGame.Canvas;

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