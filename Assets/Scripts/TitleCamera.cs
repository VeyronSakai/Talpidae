using UniPresentation.Camera;

namespace Common.Camera
{
    public class TitleCamera : CameraBase
    {
        private UnityEngine.Camera _titleRawCamera;

        public override UnityEngine.Camera GetRawCamera()
        {
            if (_titleRawCamera == null) _titleRawCamera = GetComponent<UnityEngine.Camera>();

            return _titleRawCamera;
        }
    }
}