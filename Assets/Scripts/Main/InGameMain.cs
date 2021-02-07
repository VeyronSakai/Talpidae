using Application;
using Cysharp.Threading.Tasks;
using Infrastructure;
using Presentation.Page.InGame;
using UniPresentation.Page;
using UnityEngine;
using UniRx;

namespace Main
{
    public sealed class InGameMain : MainBase
    {
        private StageApplicationService _stageApplicationService;
        private SetUpInGameApplicationService _setUpInGameApplicationService;
        private InGameTimeApplicationService _inGameTimeApplicationService;
        private UIInGameBattlePage _uiInGameBattlePage;

        // private IInputProvider _inputProvider;
        private Vector2 _moveDir;
        [SerializeField] private uint _initialLimitTime = 10;

        protected override void Inject()
        {
            var inGameMainTransform = transform;
            _stageApplicationService = new StageApplicationService(inGameMainTransform);
            _setUpInGameApplicationService = new SetUpInGameApplicationService(inGameMainTransform);

            // _inputProvider = GetComponent<IInputProvider>();
        }

        protected override void OnAwake()
        {
            _stageApplicationService.InitializeStageAsync().Forget();
            _setUpInGameApplicationService.SetUp();
            InitializeInGameBattlePage();
            _inGameTimeApplicationService =
                new InGameTimeApplicationService(new InGameTimeFactory(), _uiInGameBattlePage, _initialLimitTime);

            // _inputProvider.OnAwake();
        }

        protected override void OnStart()
        {
            // _inputProvider.MoveDirection.Subscribe(vec => {
            //     _moveDir = vec;
            // });
        }

        protected override void OnUpdate()
        {
            // Debug.Log("x : " + _moveDir.x + "/ y : " + _moveDir.y);

            _inGameTimeApplicationService.UpdateInGameTime();
        }

        private void InitializeInGameBattlePage()
        {
            _uiInGameBattlePage =
                PageFactory<UIInGameBattlePage>.Create(_setUpInGameApplicationService.CanvasContainer);
            _uiInGameBattlePage.MoveDir.Subscribe(x => _moveDir = x).AddTo(this);
            _uiInGameBattlePage.OnTapCameraButton.Subscribe(_ => OnTapCameraButton()).AddTo(this);
        }

        private static void OnTapCameraButton()
        {
            Debug.Log("カメラボタンが押されました");
        }
    }
}