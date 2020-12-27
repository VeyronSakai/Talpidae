using OutGame.Common.Cameras;
using OutGame.Title;
using PrefabGenerator;
using UI.Title;
using UI.Title.Def;
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

            PrefabFactory.Create<UITitleBackGroundWindow>(UITitleDef.UITitleBackgroundWindowPath, app0Canvas.transform);
        }
    }
}