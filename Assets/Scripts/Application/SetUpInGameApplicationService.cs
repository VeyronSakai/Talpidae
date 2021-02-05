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
        public CanvasContainer CanvasContainer { get; private set; }

        private readonly Transform _inGameMainTransform;

        public SetUpInGameApplicationService(Transform inGameMainTransform)
        {
            _inGameMainTransform = inGameMainTransform;
        }

        public void SetUp()
        {
            // CameraのRootとなるGameObjectを作る
            var cameraRoot = EmptyObjectFactory.Create(UICommonDef.CameraRootName, _inGameMainTransform);

            // Cameraを作る
            CameraBuilder.BuildCamera<InGameBattleCamera>(UICommonDef.InGameBattleCameraPrefabPath,
                cameraRoot.transform);
            var uiCamera = CameraBuilder.BuildCamera<UICamera>(UICommonDef.UICameraPrefabPath, cameraRoot.transform);

            BuildCanvas(uiCamera);
        }

        private void BuildCanvas(ICamera inGameBattleCamera)
        {
            // CanvasのPrefabのパスのリスト
            var canvasPaths = new List<string>()
            {
                UICommonDef.App0CanvasPrefabPath,
                UICommonDef.App1CanvasPrefabPath
            };

            var canvasPathParams = new CanvasPathParams(UICommonDef.CanvasRootName, canvasPaths);

            var canvasRoot = EmptyObjectFactory.Create(canvasPathParams.CanvasRootName, _inGameMainTransform);

            CanvasContainer = CanvasBuilder.BuildCanvases(inGameBattleCamera, canvasPathParams,
                UICommonDef.UITouchBlockWindow,
                canvasRoot.transform);
        }
    }
}