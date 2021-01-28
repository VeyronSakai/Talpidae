using Application;
using Cysharp.Threading.Tasks;

namespace Main
{
    public sealed class InGameMain : MainBase
    {
        private StageApplicationService _stageApplicationService;
        private SetUpInGameApplicationService _setUpInGameApplicationService;

        protected override void Inject()
        {
            var inGameMainTransform = transform;
            _stageApplicationService = new StageApplicationService(inGameMainTransform);
            _setUpInGameApplicationService = new SetUpInGameApplicationService(inGameMainTransform);
        }

        protected override void OnAwake()
        {
            _stageApplicationService.InitializeStageAsync().Forget();
            _setUpInGameApplicationService.SetUp();
        }

        protected override void OnStart()
        {
        }

        protected override void OnUpdate()
        {
        }
    }
}