using UniPresentation.Camera;
using UnityEngine;

namespace Cameras
{
    public class HomeCamera : CameraBase
    {
        private Camera _homeRawCamera;

        public override Camera GetRawCamera()
        {
            if (_homeRawCamera == null) _homeRawCamera = GetComponent<Camera>();

            return _homeRawCamera;
        }
    }
}