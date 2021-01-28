namespace Domain.Model
{
    public sealed class Stage
    {
        public const int Width = 80;
        public const int Height = 150;
        private Cell[,] _cells;

        public Stage()
        {
            // 0を考慮して+1している
            _cells = new Cell[Width, Height];
        }

        public Cell[,] GetAllCells()
        {
            return _cells;
        }

        public Cell GetCell(int w, int h)
        {
            return _cells[w, h];
        }

        /// <summary>
        /// オタカラマスのまわりに岩系のマスを生成する
        /// </summary>
        public void CreateRockAroundTreasure(Cell treasureCell)
        {
            CreateHardRocks(treasureCell);
            CreateMediumRocks(treasureCell);
            CreateNormalRock();
        }

        private void CreateHardRocks(Cell treasureCell)
        {
            CreateHardRock(treasureCell.W - 1, treasureCell.H - 1);
            CreateHardRock(treasureCell.W - 1, treasureCell.H);
            CreateHardRock(treasureCell.W - 1, treasureCell.H + 1);
            CreateHardRock(treasureCell.W, treasureCell.H - 1);
            CreateHardRock(treasureCell.W, treasureCell.H + 1);
            CreateHardRock(treasureCell.W + 1, treasureCell.H - 1);
            CreateHardRock(treasureCell.W + 1, treasureCell.H);
            CreateHardRock(treasureCell.W + 1, treasureCell.H + 1);
        }

        private void CreateMediumRocks(Cell treasureCell)
        {
            CreateMediumRock(treasureCell.W - 2, treasureCell.H - 2);
            CreateMediumRock(treasureCell.W - 2, treasureCell.H - 1);
            CreateMediumRock(treasureCell.W - 2, treasureCell.H);
            CreateMediumRock(treasureCell.W - 2, treasureCell.H + 1);
            CreateMediumRock(treasureCell.W - 2, treasureCell.H + 2);

            CreateMediumRock(treasureCell.W - 1, treasureCell.H - 2);
            CreateMediumRock(treasureCell.W, treasureCell.H - 2);
            CreateMediumRock(treasureCell.W + 1, treasureCell.H - 2);

            CreateMediumRock(treasureCell.W - 1, treasureCell.H + 2);
            CreateMediumRock(treasureCell.W, treasureCell.H + 2);
            CreateMediumRock(treasureCell.W + 1, treasureCell.H + 2);

            CreateMediumRock(treasureCell.W + 2, treasureCell.H - 2);
            CreateMediumRock(treasureCell.W + 2, treasureCell.H - 1);
            CreateMediumRock(treasureCell.W + 2, treasureCell.H);
            CreateMediumRock(treasureCell.W + 2, treasureCell.H + 1);
            CreateMediumRock(treasureCell.W + 2, treasureCell.H + 2);
        }

        private void CreateHardRock(int w, int h)
        {
            CreateCell(w, h, CellType.Hard);
        }

        private void CreateMediumRock(int w, int h)
        {
            CreateCell(w, h, CellType.Medium);
        }

        private void CreateNormalRock()
        {
            for (var i = 0; i < Width; i++)
            {
                for (var j = 0; j < Height; j++)
                {
                    _cells[i, j] ??= new Cell(i, j, CellType.Normal);
                }
            }
        }

        public Cell CreateCell(int w, int h, CellType cellType)
        {
            if (w < 0 || w >= Width || h < 0 || h >= Height)
            {
                return null;
            }

            _cells[w, h] = new Cell(w, h, cellType);
            return _cells[w, h];
        }
    }
}