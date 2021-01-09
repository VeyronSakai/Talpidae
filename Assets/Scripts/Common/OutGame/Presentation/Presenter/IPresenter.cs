using System;

namespace Common.OutGame.Presentation.Presenter
{
    public interface IPresenter : IDisposable
    {
        void SetActiveView(bool isActive);
    }
}