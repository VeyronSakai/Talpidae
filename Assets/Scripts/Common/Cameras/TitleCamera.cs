using UniPresentation.Cameras;
using UnityEngine;

namespace Common.Cameras
{
    public sealed class TitleCamera : CameraBase
    {
        private Camera _titleRawCamera;

        public override Camera GetRawCamera()
        {
            if (_titleRawCamera == null) _titleRawCamera = GetComponent<Camera>();

            return _titleRawCamera;
        }
    }
}