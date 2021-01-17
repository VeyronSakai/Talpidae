using System.Collections.Generic;
using Common.Cameras;
using Common.Def;
using PrefabGenerator;
using Presentation.Page.Title;
using UniPresentation.Cameras;
using UniPresentation.Canvases;
using UniPresentation.Page;
using UnityEngine;

namespace Main
{
    public sealed class TitleMain : MainBase
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
            PageFactory<UITitleTopPage>.Create(_canvasContainer);
        }

        protected override void OnUpdate()
        {
        }

        private void SetUp()
        {
            var titleMainTransform = transform;

            var titleUICamera = BuildCamera(titleMainTransform);

            BuildCanvas(titleMainTransform, titleUICamera);
        }

        private static ICamera BuildCamera(Transform titleMainTransform)
        {
            // CameraのRootとなるGameObjectを作る
            var cameraRoot = EmptyObjectFactory.Create(UICommonDef.CameraRootName, titleMainTransform);

            // Cameraを作る
            return CameraBuilder.BuildCamera<TitleCamera>(UICommonDef.TitleCameraPrefabPath, cameraRoot.transform);
        }


        private void BuildCanvas(Transform titleMainTransform, ICamera titleUICamera)
        {
            // CanvasのPrefabのパスのリスト
            var canvasPaths = new List<string>()
            {
                UICommonDef.App0CanvasPrefabPath,
                UICommonDef.App1CanvasPrefabPath
            };

            var canvasPathParams = new CanvasPathParams(UICommonDef.CanvasRootName, canvasPaths);

            // CanvasのRootを作成
            var canvasRoot = EmptyObjectFactory.Create(canvasPathParams.CanvasRootName, titleMainTransform);

            // Canvasを作成
            _canvasContainer = CanvasBuilder.BuildCanvases(titleUICamera, canvasPathParams,
                UICommonDef.UITouchBlockWindow, canvasRoot.transform);
        }
    }
}