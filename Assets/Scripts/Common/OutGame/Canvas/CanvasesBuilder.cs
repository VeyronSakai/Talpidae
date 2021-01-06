using Common.Camera;
using Common.OutGame.Def;
using Common.OutGame.Presentation.Presenter;
using PrefabGenerator;
using UI.Presenter.Title;
using UI.View.Title;
using UnityEngine;

namespace Common.OutGame.Canvas
{
    public sealed class CanvasesBuilder
    {
        private readonly Transform _parentTransform;
        private AppCanvas _app0Canvas;
        private AppCanvas _app1Canvas;
        private AppCanvasContainer _appCanvasContainer;

        public CanvasesBuilder(Transform parentTransform)
        {
            _parentTransform = parentTransform;
        }

        public AppCanvasContainer BuildCanvases(ICamera renderCamera)
        {
            var canvasRoot = EmptyObjectFactory.Create(UICommonDef.CanvasRootName, _parentTransform);
            var rootTransform = canvasRoot.transform;

            _app0Canvas = CreateCanvas(renderCamera, rootTransform, UICommonDef.App0CanvasPrefabPath);

            _app1Canvas = CreateCanvas(renderCamera, rootTransform, UICommonDef.App1CanvasPrefabPath);

            _appCanvasContainer = new AppCanvasContainer(_app0Canvas, _app1Canvas);

            return _appCanvasContainer;
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