namespace Common.Camera
{
    public class HomeCamera : CameraBase
    {
        private UnityEngine.Camera _homeRawCamera;

        public override UnityEngine.Camera GetRawCamera()
        {
            if (_homeRawCamera == null) _homeRawCamera = GetComponent<UnityEngine.Camera>();

            return _homeRawCamera;
        }
    }
}