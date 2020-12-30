using Common.Cameras;
using PrefabGenerator;
using UnityEngine;

namespace Common.OutGame.Canvases
{
    public class AppCanvas : PrefabBase
    {
        private Transform _canvasTransform;
        private Canvas _rawCanvas;

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
    }
}