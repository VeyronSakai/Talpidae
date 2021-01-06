using PrefabGenerator;

namespace Common.Camera
{
    public abstract class CameraBase : PrefabBase, ICamera
    {
        public abstract UnityEngine.Camera GetRawCamera();
    }
}