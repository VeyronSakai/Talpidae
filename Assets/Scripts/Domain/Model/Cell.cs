namespace Domain.Model
{
    public sealed class Cell
    {
        public readonly int W;
        public readonly int H;
        public CellType CellType;

        public Cell(int w, int h, CellType cellType)
        {
            W = w;
            H = h;
            CellType = cellType;
        }
    }

    public enum CellType
    {
        Normal, // サクサク
        Medium, // カチカチ
        Hard, // ゴチゴチ
        Treasure, // オタカラ
        Trap, // ワナ
        Arrow, // ヤジルシ
    }
}