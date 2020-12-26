using OutGame.Common.Cameras;
using PrefabGenerator;
using UnityEngine;

namespace OutGame.Common.Canvases
{
    public class AppCanvas : PrefabBase
    {
        private Canvas _rawCanvas;

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
    }
}