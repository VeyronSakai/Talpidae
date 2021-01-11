﻿using Common;
using Common.Camera;
using Common.OutGame.Def;
using Presentation.Canvases;
using Presentation.Page.Title;
using UniPresentation.Page;

namespace Main
{
    public sealed class TitleMain : MainBase
    {
        private HierarchyBuilder _hierarchyBuilder;
        private Hierarchy _hierarchy;

        protected override void Inject()
        {
            var titleMainTransform = transform;

            var titleCameraBuilder = new CameraBuilder(titleMainTransform);
            var canvasesBuilder = new CanvasesBuilder(titleMainTransform);
            _hierarchyBuilder = new HierarchyBuilder(titleCameraBuilder, canvasesBuilder);
        }

        protected override void OnAwake()
        {
            _hierarchy = _hierarchyBuilder.BuildHierarchy<TitleCamera>(UICommonDef.TitleCameraPrefabPath);
        }

        protected override void OnStart()
        {
            PageFactory<UITitleTopPage, AppCanvasContainer>.Create(_hierarchy.AppCanvasContainer);
        }

        protected override void OnUpdate()
        {
        }
    }
}