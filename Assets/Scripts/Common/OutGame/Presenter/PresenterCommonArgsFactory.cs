using Common.OutGame.Canvases;

namespace Common.OutGame.Presenter
{
    public static class PresenterCommonArgsFactory
    {
        public static PresenterCommonArgs Create(AppCanvas canvas, string prefabPath)
        {
            return new PresenterCommonArgs(canvas, prefabPath);
        }
    }
}