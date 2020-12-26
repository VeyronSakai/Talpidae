using PrefabGenerator;
using UnityEngine;

namespace OutGame.Common.Cameras
{
    public sealed class CameraBuilder
    {
        private readonly Transform _parentTransform;

        public CameraBuilder(Transform parentTransform)
        {
            _parentTransform = parentTransform;
        }

        public ICamera BuildCamera()
        {
            var cameraRoot = EmptyObjectFactory.Create(UITitleCommonDef.CameraRootName, _parentTransform);
            var titleCamera = PrefabFactory.Create<CameraBase>(UITitleCommonDef.TitleCameraPath, cameraRoot.transform);
            return titleCamera;
        }
    }
}