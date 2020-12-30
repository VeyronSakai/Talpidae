using Common.OutGame.Canvases;

namespace Common.OutGame.Presenter
{
    /// <summary>
    ///     Presenterを生成する時にコンストラクタに毎回渡すパラメータ
    /// </summary>
    public readonly struct PresenterCommonArgs
    {
        public readonly AppCanvas AppCanvas;
        public readonly string PrefabPath;

        public PresenterCommonArgs(AppCanvas canvas, string prefabPath)
        {
            AppCanvas = canvas;
            PrefabPath = prefabPath;
        }
    }
}