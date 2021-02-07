using Domain.Model;

namespace Application
{
    public sealed class InGameTimeApplicationService
    {
        private readonly IUIInGameBattlePage _uiInGameBattlePage;
        private readonly InGameTime _inGameTime;

        public InGameTimeApplicationService(IInGameTimeFactory inGameTimeFactory,
            IUIInGameBattlePage uiInGameBattlePage, uint initialLimitTime)
        {
            _uiInGameBattlePage = uiInGameBattlePage;
            _inGameTime = inGameTimeFactory.Create(initialLimitTime);
        }

        public void UpdateInGameTime()
        {
            _inGameTime.OnUpdate();
            _uiInGameBattlePage.UpdateLimitTimeText(_inGameTime.LeftTimeSeconds);
        }
    }
}