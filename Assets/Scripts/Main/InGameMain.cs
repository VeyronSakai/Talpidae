using System.Collections.Generic;
using Common.Cameras;
using Common.Def;
using PrefabGenerator;
using UniPresentation.Cameras;
using UniPresentation.Canvases;
using UnityEngine;

namespace Main
{
    public sealed class InGameMain : MainBase
    {
        private CanvasContainer _canvasContainer;

        protected override void Inject()
        {
            SetUp();
        }

        protected override void OnAwake()
        {
        }

        protected override void OnStart()
        {
        }

        protected override void OnUpdate()
        {
        }

        private void SetUp()
        {
            var inGameMainTransform = transform;

            var inGameMainCamera = BuildCamera(inGameMainTransform);

            BuildCanvas(inGameMainTransform, inGameMainCamera);
        }

        private static ICamera BuildCamera(Transform inGameMainTransform)
        {
            // CameraのRootとなるGameObjectを作る
            var cameraRoot = EmptyObjectFactory.Create(UICommonDef.CameraRootName, inGameMainTransform);

            // Cameraを作る
            return CameraBuilder.BuildCamera<InGameBattleCamera>(UICommonDef.InGameBattleCameraPrefabPath, cameraRoot.transform);
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

            _canvasContainer = CanvasBuilder.BuildCanvases(inGameBattleCamera, canvasPathParams,
                UICommonDef.UITouchBlockWindow, canvasRoot.transform);
        }
    }
}