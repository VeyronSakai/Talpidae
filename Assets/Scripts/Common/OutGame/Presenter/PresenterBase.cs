﻿using System;
using Common.OutGame.View;
using PrefabGenerator;

namespace Common.OutGame.Presenter
{
    public abstract class PresenterBase<T> : IDisposable where T : ViewBase
    {
        public T TargetView;

        protected PresenterBase(PrefabGenParams prefabGenParams)
        {
            TargetView = PrefabFactory.Create<T>(prefabGenParams.PrefabPath, prefabGenParams.AppCanvas.GetTransform());
        }

        public virtual void Dispose()
        {
            PrefabDestroyer.Destroy(ref TargetView);
        }
    }
}