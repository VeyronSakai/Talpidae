﻿using Common.Cameras;
using Common.OutGame.Title;
using PrefabGenerator;
using UI.Page.Title;
using UnityEngine;

namespace Common.OutGame.Canvases
{
    public sealed class CanvasBuilder
    {
        private readonly Transform _parentTransform;
        private AppCanvas _app0Canvas;
        private AppCanvas _app1Canvas;
        private AppCanvasParams _appCanvasParams;

        public CanvasBuilder(Transform parentTransform)
        {
            _parentTransform = parentTransform;
        }

        public void BuildCanvas(ICamera renderCamera)
        {
            var canvasRoot = EmptyObjectFactory.Create(UITitleCommonDef.CanvasRootName, _parentTransform);
            _app0Canvas = PrefabFactory.Create<AppCanvas>(UITitleCommonDef.App0CanvasPrefabPath, canvasRoot.transform);
            _app0Canvas.SetCamera(renderCamera);

            _app1Canvas = PrefabFactory.Create<AppCanvas>(UITitleCommonDef.App1CanvasPrefabPath, canvasRoot.transform);
            _app1Canvas.SetCamera(renderCamera);

            _appCanvasParams = new AppCanvasParams(_app0Canvas, _app1Canvas);

            var topPage = new UITitleTopPage(_appCanvasParams);
        }
    }
}