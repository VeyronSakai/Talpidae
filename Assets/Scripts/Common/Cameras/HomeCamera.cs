using UniPresentation.Cameras;
using UnityEngine;

namespace Common.Cameras
{
    public sealed class HomeCamera : CameraBase
    {
        private Camera _homeRawCamera;

        public override Camera GetRawCamera()
        {
            if (_homeRawCamera == null) _homeRawCamera = GetComponent<Camera>();

            return _homeRawCamera;
        }
    }
}