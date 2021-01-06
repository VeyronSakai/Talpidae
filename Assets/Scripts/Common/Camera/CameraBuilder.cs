using Common.OutGame.Def;
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

        public ICamera BuildCamera<T>(string cameraPrefabPath) where T : CameraBase
        {
            var cameraRoot = EmptyObjectFactory.Create(UICommonDef.CameraRootName, _parentTransform);
            var titleCamera = PrefabFactory.Create<T>(cameraPrefabPath, cameraRoot.transform);
            return titleCamera;
        }
    }
}