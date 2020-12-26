using OutGame.Cameras;
using PrefabGenerator;
using UnityEngine;

namespace OutGame
{
    public sealed class CameraBuilder
    {
        private readonly Transform _parentTransform;

        public CameraBuilder(Transform parentTransform)
        {
            _parentTransform = parentTransform;
        }

        public ICamera GetCamera()
        {
            var cameraRoot = EmptyObjectFactory.Create(UITitleCommonDef.CameraRootName, _parentTransform);
            var titleCamera = PrefabFactory.Create<TitleCamera>(UITitleCommonDef.TitleCameraPath, cameraRoot.transform);
            return titleCamera;
        }
    }
}