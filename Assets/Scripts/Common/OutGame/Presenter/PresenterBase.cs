using System;
using Common.OutGame.View;
using PrefabGenerator;

namespace Common.OutGame.Presenter
{
    public abstract class PresenterBase<T> : IDisposable where T : ViewBase
    {
        public T TargetView;

        protected PresenterBase(PresenterCommonArgs commonArgs)
        {
            TargetView = PrefabFactory.Create<T>(commonArgs.PrefabPath, commonArgs.AppCanvas.GetTransform());
        }

        public virtual void Dispose()
        {
            PrefabDestroyer.Destroy(ref TargetView);
        }
    }
}