using Common.Cameras;
using PrefabGenerator;
using UI.Presenter.Title;
using UnityEngine;

namespace Common.OutGame.Canvases
{
    public class AppCanvas : PrefabBase
    {
        private Transform _canvasTransform;
        private Canvas _rawCanvas;
        private UITouchBlockPresenter _touchBlockPresenter;

        public Canvas GetRawCanvas()
        {
            if (_rawCanvas == null) _rawCanvas = GetComponent<Canvas>();

            return _rawCanvas;
        }

        public void SetCamera(ICamera targetCamera)
        {
            if (_rawCanvas == null) _rawCanvas = GetComponent<Canvas>();

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
            _touchBlockPresenter.SetActive(isActive);
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