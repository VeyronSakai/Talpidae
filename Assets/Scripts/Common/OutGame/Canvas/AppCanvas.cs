using Common.Camera;
using PrefabGenerator;
using UI.Presenter.Title;
using UnityEngine;

namespace Common.OutGame.Canvas
{
    public class AppCanvas : PrefabBase
    {
        private Transform _canvasTransform;
        private UnityEngine.Canvas _rawCanvas;
        private UITouchBlockPresenter _touchBlockPresenter;

        public UnityEngine.Canvas GetRawCanvas()
        {
            if (_rawCanvas == null) _rawCanvas = GetComponent<UnityEngine.Canvas>();

            return _rawCanvas;
        }

        public void SetCamera(ICamera targetCamera)
        {
            if (_rawCanvas == null) _rawCanvas = GetComponent<UnityEngine.Canvas>();

            _rawCanvas.worldCamera = targetCamera.GetRawCamera();
        }

        public Transform GetTransform()
        {
            if (_canvasTransform == null) _canvasTransform = transform;

            return _canvasTransform;
        }

        public void SetTouchBlockPresenter(UITouchBlockPresenter presenter)
        {
            _touchBlockPresenter = presenter;
        }

        public void SetActiveTouchBlockWindow(bool isActive)
        {
            _touchBlockPresenter.SetActiveView(isActive);
        }

        public bool IsTouchBlockEnabled()
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