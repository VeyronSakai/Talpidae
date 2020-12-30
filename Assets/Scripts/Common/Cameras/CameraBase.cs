using PrefabGenerator;
using UnityEngine;

namespace Common.Cameras
{
    public abstract class CameraBase : PrefabBase, ICamera
    {
        public abstract Camera GetRawCamera();
    }
}