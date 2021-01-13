using UniPresentation.Camera;
using UnityEngine;

namespace Cameras
{
    public class TitleCamera : CameraBase
    {
        private Camera _titleRawCamera;

        public override Camera GetRawCamera()
        {
            if (_titleRawCamera == null) _titleRawCamera = GetComponent<Camera>();

            return _titleRawCamera;
        }
    }
}