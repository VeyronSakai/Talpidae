using OutGame.Common.Cameras;
using PrefabGenerator;
using UnityEngine;

namespace OutGame.Common.Canvases
{
    public class AppCanvas : PrefabBase
    {
        private Canvas _rawCanvas;
        private Transform _canvasTransform;

        public Canvas GetRawCanvas()
        {
            if (_rawCanvas == null)
            {
                _rawCanvas = GetComponent<Canvas>();
            }

            return _rawCanvas;
        }

        public void SetCamera(ICamera targetCamera)
        {
            if (_rawCanvas == null)
            {
                _rawCanvas = GetComponent<Canvas>();
            }

            _rawCanvas.worldCamera = targetCamera.GetRawCamera();
        }

        public Transform GetTransform()
        {
            if (_canvasTransform == null)
            {
                _canvasTransform = transform;
            }

            return _canvasTransform;
        }
    }
}