using PrefabGenerator;
using UnityEngine;

namespace OutGame.Common.Cameras
{
    public abstract class CameraBase : PrefabBase, ICamera
    {
        public abstract Camera GetRawCamera();
    }
}