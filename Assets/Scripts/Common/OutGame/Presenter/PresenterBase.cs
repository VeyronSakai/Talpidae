using System;
using Common.OutGame.Canvases;
using Common.OutGame.View;
using PrefabGenerator;

namespace Common.OutGame.Presenter
{
    public abstract class PresenterBase<T> : IDisposable where T : ViewBase
    {
        public T TargetView;
        private readonly AppCanvas _appCanvas;

        protected PresenterBase(PrefabGenParams prefabGenParams)
        {
            TargetView = PrefabFactory.Create<T>(prefabGenParams.PrefabPath, prefabGenParams.AppCanvas.GetTransform());
            _appCanvas = prefabGenParams.AppCanvas;

            TargetView.gameObject.SetActive(false);
        }

        public void SetActive(bool isActive)
        {
            TargetView.gameObject.SetActive(isActive);
        }

        public void SetActiveTouchBlock(bool isActive)
        {
            if (_appCanvas.IsTouchBlockEnabled() != isActive)
            {
                _appCanvas.SetActiveTouchBlockWindow(isActive);
            }
        }

        public bool IsViewActive()
        {
            return TargetView.gameObject.activeInHierarchy;
        }

        public virtual void Dispose()
        {
            PrefabDestroyer.Destroy(ref TargetView);
        }
    }
}