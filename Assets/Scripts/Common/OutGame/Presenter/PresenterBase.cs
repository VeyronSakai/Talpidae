using System;
using PrefabGenerator;

namespace Common.OutGame.Presenter
{
    public abstract class PresenterBase<T> : IDisposable where T : PrefabBase
    {
        public PrefabBase TargetPrefab;

        protected PresenterBase(PresenterCommonArgs commonArgs)
        {
            TargetPrefab = PrefabFactory.Create<T>(commonArgs.PrefabPath, commonArgs.AppCanvas.GetTransform());
        }

        public virtual void Dispose()
        {
            PrefabDestroyer.Destroy(ref TargetPrefab);
        }
    }
}