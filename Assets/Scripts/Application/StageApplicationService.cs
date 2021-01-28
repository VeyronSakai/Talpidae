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
        private readonly Transform _stageParent;

        public StageApplicationService(Transform stageParent)
        {
            _networkApplicationService = new StageNetworkApplicationService();
            _stageParent = stageParent;
        }

        public async UniTask InitializeStageAsync()
        {
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
                            PrefabFactory.Create<HardRockView>(StagePrefabPathDef.HardRock, _stageParent, pos);
                            break;
                        case CellType.Medium:
                            PrefabFactory.Create<MediumRockView>(StagePrefabPathDef.MediumRock, _stageParent, pos);
                            break;
                        case CellType.Normal:
                            PrefabFactory.Create<NormalRockView>(StagePrefabPathDef.NormalRock, _stageParent, pos);
                            break;
                        case CellType.Treasure:
                            PrefabFactory.Create<TreasureCellView>(StagePrefabPathDef.TreasureCell, _stageParent, pos);
                            break;
                        case CellType.Trap:
                            break;
                        case CellType.ArrowUp:
                            PrefabFactory.Create<TmpArrowCellView>(StagePrefabPathDef.TmpArrowCell, _stageParent, pos);
                            break;
                        case CellType.ArrowDown:
                            PrefabFactory.Create<TmpArrowCellView>(StagePrefabPathDef.TmpArrowCell, _stageParent, pos);
                            break;
                        case CellType.ArrowRight:
                            PrefabFactory.Create<TmpArrowCellView>(StagePrefabPathDef.TmpArrowCell, _stageParent, pos);
                            break;
                        case CellType.ArrowLeft:
                            PrefabFactory.Create<TmpArrowCellView>(StagePrefabPathDef.TmpArrowCell, _stageParent, pos);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }
        }
    }
}