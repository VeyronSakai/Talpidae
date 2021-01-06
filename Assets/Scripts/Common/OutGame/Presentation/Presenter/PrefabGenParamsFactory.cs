﻿using Common.OutGame.Canvas;

namespace Common.OutGame.Presentation.Presenter
{
    public static class PrefabGenParamsFactory
    {
        public static PrefabGenParams Create(AppCanvas canvas, string prefabPath)
        {
            return new PrefabGenParams(canvas, prefabPath);
        }
    }
}