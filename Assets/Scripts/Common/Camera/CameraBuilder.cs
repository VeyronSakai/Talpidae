using PrefabGenerator;
using UnityEngine;

namespace Common.Camera
{
    public sealed class CameraBuilder
    {
        private readonly Transform _parentTransform;

        public CameraBuilder(Transform parentTransform)
        {
            _parentTransform = parentTransform;
        }

        public ICamera BuildCamera<T>(string cameraPrefabPath, string cameraRootName) where T : CameraBase
        {
            var cameraRoot = EmptyObjectFactory.Create(cameraRootName, _parentTransform);
            var camera = PrefabFactory.Create<T>(cameraPrefabPath, cameraRoot.transform);
            return camera;
        }
    }
}