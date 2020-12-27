using OutGame.Common.Cameras;
using OutGame.Title;
using PrefabGenerator;
using UI.Presenter.Title;
using UnityEngine;

namespace OutGame.Common.Canvases
{
    public sealed class CanvasBuilder
    {
        private readonly Transform _parentTransform;

        public CanvasBuilder(Transform parentTransform)
        {
            _parentTransform = parentTransform;
        }

        public void BuildCanvas(ICamera renderCamera)
        {
            var canvasRoot = EmptyObjectFactory.Create(UITitleCommonDef.CanvasRootName, _parentTransform);
            var app0Canvas =
                PrefabFactory.Create<AppCanvas>(UITitleCommonDef.App0CanvasPrefabPath, canvasRoot.transform);
            app0Canvas.SetCamera(renderCamera);

            // TODO: Factory Method に切り出す
            var presenter = new UITitleBackGroundPresenter(app0Canvas.transform);
        }
    }
}