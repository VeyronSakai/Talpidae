using OutGame.Common.Cameras;
using OutGame.Title;
using PrefabGenerator;
using UI.Page.Title;
using UnityEngine;

namespace OutGame.Common.Canvases
{
    public sealed class CanvasBuilder
    {
        private readonly Transform _parentTransform;
        private AppCanvas _app0Canvas;

        public CanvasBuilder(Transform parentTransform)
        {
            _parentTransform = parentTransform;
        }

        public void BuildCanvas(ICamera renderCamera)
        {
            var canvasRoot = EmptyObjectFactory.Create(UITitleCommonDef.CanvasRootName, _parentTransform);
            _app0Canvas =
                PrefabFactory.Create<AppCanvas>(UITitleCommonDef.App0CanvasPrefabPath, canvasRoot.transform);
            _app0Canvas.SetCamera(renderCamera);

            var topPage = new UITitleTopPage(_app0Canvas.GetTransform());
        }
    }
}