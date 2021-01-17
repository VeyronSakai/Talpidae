using System.Collections.Generic;
using Common.Cameras;
using Common.Def;
using PrefabGenerator;
using Presentation.Page.Home;
using UniPresentation.Cameras;
using UniPresentation.Canvases;
using UniPresentation.Page;
using UnityEngine;

namespace Main
{
    public sealed class HomeMain : MainBase
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
            PageFactory<UIHomeTopPage>.Create(_canvasContainer);
        }

        protected override void OnUpdate()
        {
        }

        private void SetUp()
        {
            var homeMainTransform = transform;

            var homeUICamera = BuildCamera(homeMainTransform);

            BuildCanvas(homeMainTransform, homeUICamera);
        }

        private static ICamera BuildCamera(Transform homeMainTransform)
        {
            // CameraのRootとなるGameObjectを作る
            var cameraRoot = EmptyObjectFactory.Create(UICommonDef.CameraRootName, homeMainTransform);

            // Cameraを作る
            return CameraBuilder.BuildCamera<HomeCamera>(UICommonDef.HomeCameraPrefabPath, cameraRoot.transform);
        }
        
        private void BuildCanvas(Transform homeMainTransform, ICamera homeUICamera)
        {
            // CanvasのPrefabのパスのリスト
            var canvasPaths = new List<string>()
            {
                UICommonDef.App0CanvasPrefabPath,
                UICommonDef.App1CanvasPrefabPath
            };

            var canvasPathParams = new CanvasPathParams(UICommonDef.CanvasRootName, canvasPaths);

            var canvasRoot = EmptyObjectFactory.Create(canvasPathParams.CanvasRootName, homeMainTransform);

            _canvasContainer = CanvasBuilder.BuildCanvases(homeUICamera, canvasPathParams,
                UICommonDef.UITouchBlockWindow, canvasRoot.transform);
        }
    }
}