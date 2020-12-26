using PrefabGenerator;
using UnityEngine;

namespace Cameras
{
    public class TitleCamera : PrefabBase, ICamera
    {
        private Camera _titleRawCamera;

        public Camera GetRawCamera()
        {
            if (_titleRawCamera == null)
            {
                _titleRawCamera = GetComponent<Camera>();
            }

            return _titleRawCamera;
        }
    }
}