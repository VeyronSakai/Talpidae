using Common.OutGame.Canvases;

namespace Common.OutGame.Presenter
{
    /// <summary>
    ///     Prefabを生成する際に必要な情報を格納する
    /// </summary>
    public readonly struct PrefabGenParams
    {
        public readonly AppCanvas AppCanvas;
        public readonly string PrefabPath;

        public PrefabGenParams(AppCanvas canvas, string prefabPath)
        {
            AppCanvas = canvas;
            PrefabPath = prefabPath;
        }
    }
}