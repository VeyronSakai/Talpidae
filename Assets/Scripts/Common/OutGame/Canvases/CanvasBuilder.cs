using Common.Cameras;
using Common.OutGame.Presenter;
using Common.OutGame.Title;
using PrefabGenerator;
using UI.Page.Title;
using UI.Presenter.Title;
using UI.View.Title;
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

        public void BuildCanvases(ICamera renderCamera)
        {
            var canvasRoot = EmptyObjectFactory.Create(UICommonDef.CanvasRootName, _parentTransform);
            var rootTransform = canvasRoot.transform;

            _app0Canvas = CreateCanvas(renderCamera, rootTransform, UICommonDef.App0CanvasPrefabPath);

            _app1Canvas = CreateCanvas(renderCamera, rootTransform, UICommonDef.App1CanvasPrefabPath);

            _appCanvasParams = new AppCanvasParams(_app0Canvas, _app1Canvas);

            var topPage = new UITitleTopPage(_appCanvasParams);
        }

        private static AppCanvas CreateCanvas(ICamera renderCamera, Transform rootTransform, string canvasPrefabPath)
        {
            var appCanvas = PrefabFactory.Create<AppCanvas>(canvasPrefabPath, rootTransform);
            appCanvas.SetCamera(renderCamera);
            var touchBlockPresenter = CreateTouchBlockPresenter(appCanvas);
            appCanvas.SetTouchBlockPresenter(touchBlockPresenter);
            return appCanvas;
        }

        private static UITouchBlockPresenter CreateTouchBlockPresenter(AppCanvas canvas)
        {
            var touchBlockPrefabParams = PrefabGenParamsFactory.Create(canvas, UICommonDef.UITouchBlockWindow);
            var touchBlockPresenter =
                PresenterFactory<UITouchBlockPresenter, UITouchBlockWindow>.Create(touchBlockPrefabParams);
            return touchBlockPresenter;
        }
    }
}