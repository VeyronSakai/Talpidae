using Cysharp.Threading.Tasks;
using Infrastructure;

namespace Application
{
    public sealed class StageApplicationService
    {
        private readonly StageNetworkApplicationService _networkApplicationService;

        private const int MaxW = 79;
        private const int MaxH = 149;
        
        public StageApplicationService()
        {
            _networkApplicationService = new StageNetworkApplicationService(new StageFactory());
        }

        public async UniTask InitializeStageAsync()
        {
            var stage = await _networkApplicationService.GetStageStartAsync();
        }
    }
}