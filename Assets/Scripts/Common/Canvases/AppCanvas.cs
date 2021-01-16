using UniPresentation.Camera;
using UniPresentation.Canvases;
using UniPresentation.TouchBlock;
using UnityEngine;

namespace Common.Canvases
{
    public class AppCanvas : CanvasBase
    {
        private Transform _canvasTransform;
        private Canvas _rawCanvas;
        private UITouchBlockPresenter _touchBlockPresenter;

        public Canvas GetRawCanvas()
        {
            if (_rawCanvas == null) _rawCanvas = GetComponent<UnityEngine.Canvas>();

            return _rawCanvas;
        }

        public override void SetCamera(ICamera targetCamera)
        {
            if (_rawCanvas == null) _rawCanvas = GetComponent<UnityEngine.Canvas>();

            _rawCanvas.worldCamera = targetCamera.GetRawCamera();
        }

        public override Transform GetTransform()
        {
            if (_canvasTransform == null) _canvasTransform = transform;

            return _canvasTransform;
        }

        public override void SetTouchBlockPresenter(UITouchBlockPresenter presenter)
        {
            _touchBlockPresenter = presenter;
        }

        public override void SetActiveTouchBlockWindow(bool isActive)
        {
            _touchBlockPresenter.SetActiveView(isActive);
        }

        public override bool IsTouchBlockEnabled()
        {
            return _touchBlockPresenter.IsViewActive();
        }

        private void OnDestroy()
        {
            if (_touchBlockPresenter != null)
            {
                _touchBlockPresenter.Dispose();
                _touchBlockPresenter = null;
            }
        }
    }
}