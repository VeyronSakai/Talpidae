using System.Collections.Generic;
using Common.Cameras;
using Common.Def;
using PrefabGenerator;
using UniPresentation.Cameras;
using UniPresentation.Canvases;
using UnityEngine;

namespace Application
{
    public sealed class SetUpInGameApplicationService
    {
        private readonly Transform _inGameMainTransform;

        public SetUpInGameApplicationService(Transform inGameMainTransform)
        {
            _inGameMainTransform = inGameMainTransform;
        }

        public void SetUp()
        {
            var inGameMainCamera = BuildCamera(_inGameMainTransform);

            BuildCanvas(_inGameMainTransform, inGameMainCamera);
        }

        private static ICamera BuildCamera(Transform inGameMainTransform)
        {
            // CameraのRootとなるGameObjectを作る
            var cameraRoot = EmptyObjectFactory.Create(UICommonDef.CameraRootName, inGameMainTransform);

            // Cameraを作る
            return CameraBuilder.BuildCamera<InGameBattleCamera>(UICommonDef.InGameBattleCameraPrefabPath,
                cameraRoot.transform);
        }

        private void BuildCanvas(Transform inGameMainTransform, ICamera inGameBattleCamera)
        {
            // CanvasのPrefabのパスのリスト
            var canvasPaths = new List<string>()
            {
                UICommonDef.App0CanvasPrefabPath,
                UICommonDef.App1CanvasPrefabPath
            };

            var canvasPathParams = new CanvasPathParams(UICommonDef.CanvasRootName, canvasPaths);

            var canvasRoot = EmptyObjectFactory.Create(canvasPathParams.CanvasRootName, inGameMainTransform);

            CanvasBuilder.BuildCanvases(inGameBattleCamera, canvasPathParams, UICommonDef.UITouchBlockWindow,
                canvasRoot.transform);
        }
    }
}