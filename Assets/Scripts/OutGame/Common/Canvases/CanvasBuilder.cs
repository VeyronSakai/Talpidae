using OutGame.Common.Cameras;
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

        public void BuildCanvas(ICamera titleCamera)
        {
            var canvasRoot = EmptyObjectFactory.Create(UITitleCommonDef.CanvasRootName, _parentTransform);
            var app0Canvas = PrefabFactory.Create<AppCanvas>(UITitleCommonDef.App0CanvasPath, canvasRoot.transform);
            app0Canvas.SetCamera(titleCamera);

            PrefabFactory.Create<UITitleBackGroundWindow>(UITitleDef.UITitleBackgroundWindowPath, app0Canvas.transform);
        }
    }
}