using Application;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UniRx;

namespace Main
{
    public sealed class InGameMain : MainBase
    {
        private StageApplicationService _stageApplicationService;
        private SetUpInGameApplicationService _setUpInGameApplicationService;
        private IInputProvider _inputProvider;

        private Vector2 _moveDir;

        protected override void Inject()
        {
            var inGameMainTransform = transform;
            _stageApplicationService = new StageApplicationService(inGameMainTransform);
            _setUpInGameApplicationService = new SetUpInGameApplicationService(inGameMainTransform);
            _inputProvider = GetComponent<IInputProvider>();
        }

        protected override void OnAwake()
        {
            _stageApplicationService.InitializeStageAsync().Forget();
            _setUpInGameApplicationService.SetUp();
            _inputProvider.OnAwake();
        }

        protected override void OnStart()
        {
            _inputProvider.MoveDirection.Subscribe(vec => {
                _moveDir = vec;
            });
        }

        protected override void OnUpdate()
        {
            Debug.Log("x : " + _moveDir.x + "/ y : " + _moveDir.y);
        }
    }
}