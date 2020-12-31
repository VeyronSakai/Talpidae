using Common.OutGame.Canvases;

namespace Common.OutGame.Presenter
{
    public static class PrefabGenParamsFactory
    {
        public static PrefabGenParams Create(AppCanvas canvas, string prefabPath)
        {
            return new PrefabGenParams(canvas, prefabPath);
        }
    }
}