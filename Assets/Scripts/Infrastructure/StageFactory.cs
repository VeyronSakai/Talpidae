using System;
using Application;
using Domain.Model;

namespace Infrastructure
{
    public class StageFactory : IStageFactory
    {
        private const int MaxW = 79;
        private const int MaxH = 149;

        public Stage Create(StageInfo stageInfo)
        {
            // stageInfoを並び替えて、cell[,]に詰める
            var cells = new Cell[MaxW + 1, MaxH + 1];

            foreach (var position in stageInfo.positions)
            {
                // CellTypeを取得
                var cellType = position.value switch
                {
                    "treasure" => CellType.Treasure,
                    "arrow-up" => CellType.ArrowUp,
                    "arrow-down" => CellType.ArrowDown,
                    "arrow-left" => CellType.ArrowLeft,
                    "arrow-right" => CellType.ArrowRight,
                    _ => throw new ArgumentException()
                };

                // CellFactoryに委譲する?
                var cell = new Cell(position.w, position.h, cellType);
                cells[position.w, position.h] = cell;

                if (cell.CellType == CellType.Treasure)
                {
                    CreateRockAroundTreasure(cell, ref cells);
                }
            }

            return new Stage(cells);
        }

        /// <summary>
        /// オタカラマスのまわりに岩系のマスを生成する
        /// </summary>
        private static void CreateRockAroundTreasure(Cell treasureCell, ref Cell[,] cells)
        {
            CreateHardRocks(treasureCell, ref cells);
            CreateMediumRocks(treasureCell, ref cells);
            CreateNormalRock(treasureCell, ref cells);
        }

        private static void CreateHardRocks(Cell treasureCell, ref Cell[,] cells)
        {
            CreateHardRock(treasureCell.W - 1, treasureCell.H - 1, ref cells);
            CreateHardRock(treasureCell.W - 1, treasureCell.H, ref cells);
            CreateHardRock(treasureCell.W - 1, treasureCell.H + 1, ref cells);
            CreateHardRock(treasureCell.W, treasureCell.H - 1, ref cells);
            CreateHardRock(treasureCell.W, treasureCell.H + 1, ref cells);
            CreateHardRock(treasureCell.W + 1, treasureCell.H - 1, ref cells);
            CreateHardRock(treasureCell.W + 1, treasureCell.H, ref cells);
            CreateHardRock(treasureCell.W + 1, treasureCell.H + 1, ref cells);
        }

        private static void CreateMediumRocks(Cell treasureCell, ref Cell[,] cells)
        {
            CreateMediumRock(treasureCell.W - 2, treasureCell.H - 2, ref cells);
            CreateMediumRock(treasureCell.W - 2, treasureCell.H - 1, ref cells);
            CreateMediumRock(treasureCell.W - 2, treasureCell.H, ref cells);
            CreateMediumRock(treasureCell.W - 2, treasureCell.H + 1, ref cells);
            CreateMediumRock(treasureCell.W - 2, treasureCell.H + 2, ref cells);
            
            CreateMediumRock(treasureCell.W - 1, treasureCell.H - 2, ref cells);
            CreateMediumRock(treasureCell.W, treasureCell.H - 2, ref cells);
            CreateMediumRock(treasureCell.W + 1, treasureCell.H - 2, ref cells);
            
            CreateMediumRock(treasureCell.W - 1, treasureCell.H + 2, ref cells);
            CreateMediumRock(treasureCell.W, treasureCell.H + 2, ref cells);
            CreateMediumRock(treasureCell.W + 1, treasureCell.H + 2, ref cells);
            
            CreateMediumRock(treasureCell.W + 2, treasureCell.H - 2, ref cells);
            CreateMediumRock(treasureCell.W + 2, treasureCell.H - 1, ref cells);
            CreateMediumRock(treasureCell.W + 2, treasureCell.H, ref cells);
            CreateMediumRock(treasureCell.W + 2, treasureCell.H + 1, ref cells);
            CreateMediumRock(treasureCell.W + 2, treasureCell.H + 2, ref cells);
        }

        private static void CreateNormalRock(Cell treasureCell, ref Cell[,] cells)
        {
            for (var i = 0; i < MaxW; i++)
            {
                for (var j = 0; j < MaxH; j++)
                {
                    cells[i, j] ??= new Cell(i, j, CellType.Normal);
                }
            }
        }

        private static void CreateHardRock(int w, int h, ref Cell[,] cells)
        {
            CreateCell(w, h, ref cells, CellType.Hard);
        }

        private static void CreateMediumRock(int w, int h, ref Cell[,] cells)
        {
            CreateCell(w, h, ref cells, CellType.Medium);
        }


        private static void CreateCell(int w, int h, ref Cell[,] cells, CellType cellType)
        {
            if (w < 0 || w > MaxW || h < 0 || h > MaxH)
            {
                return;
            }

            cells[w, h] = new Cell(w, h, cellType);
        }
    }
}