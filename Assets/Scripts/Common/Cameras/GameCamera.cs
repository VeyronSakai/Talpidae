using UniPresentation.Cameras;
using UnityEngine;

namespace Common.Cameras
{
    public sealed class GameCamera : CameraBase
    {
        private Camera _gameRawCamera;
        public override Camera GetRawCamera()
        {
            if (_gameRawCamera == null) _gameRawCamera = GetComponent<Camera>();

            return _gameRawCamera;
        }
    }
}
