using System;
using Cysharp.Threading.Tasks;
using Domain.Model;
using PrefabGenerator;
using Presentation.View.InGame;
using UnityEngine;

namespace Application
{
    public sealed class StageApplicationService
    {
        private readonly StageNetworkApplicationService _networkApplicationService;
        private readonly Transform _inGameMainTransform;
        private const string StageRoot = "StageRoot";
        private Transform _stageRootTransform;

        public StageApplicationService(Transform inGameMainTransform)
        {
            _networkApplicationService = new StageNetworkApplicationService();
            _inGameMainTransform = inGameMainTransform;
        }

        public async UniTask InitializeStageAsync()
        {
            var stageRoot = EmptyObjectFactory.Create(StageRoot, _inGameMainTransform);
            _stageRootTransform = stageRoot.transform;

            var stage = await _networkApplicationService.GetStageStartAsync();
            InstantiateStage(stage);
        }

        private void InstantiateStage(Stage stage)
        {
            for (var i = 0; i < Stage.Width; i++)
            {
                for (var j = 0; j < Stage.Height; j++)
                {
                    var cell = stage.GetCell(i, j);
                    var pos = new Vector3(i, 0, j);
                    switch (cell.CellType)
                    {
                        case CellType.Hard:
                            PrefabFactory.Create<HardRockView>(StagePrefabPathDef.HardRock, _stageRootTransform, pos);
                            break;
                        case CellType.Medium:
                            PrefabFactory.Create<MediumRockView>(StagePrefabPathDef.MediumRock, _stageRootTransform,
                                pos);
                            break;
                        case CellType.Normal:
                            PrefabFactory.Create<NormalRockView>(StagePrefabPathDef.NormalRock, _stageRootTransform,
                                pos);
                            break;
                        case CellType.Treasure:
                            PrefabFactory.Create<TreasureCellView>(StagePrefabPathDef.TreasureCell, _stageRootTransform,
                                pos);
                            break;
                        case CellType.Trap:
                            break;
                        case CellType.ArrowUp:
                            PrefabFactory.Create<TmpArrowCellView>(StagePrefabPathDef.TmpArrowCell, _stageRootTransform,
                                pos);
                            break;
                        case CellType.ArrowDown:
                            PrefabFactory.Create<TmpArrowCellView>(StagePrefabPathDef.TmpArrowCell, _stageRootTransform,
                                pos);
                            break;
                        case CellType.ArrowRight:
                            PrefabFactory.Create<TmpArrowCellView>(StagePrefabPathDef.TmpArrowCell, _stageRootTransform,
                                pos);
                            break;
                        case CellType.ArrowLeft:
                            PrefabFactory.Create<TmpArrowCellView>(StagePrefabPathDef.TmpArrowCell,
                                _stageRootTransform, pos);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }
        }
    }
}