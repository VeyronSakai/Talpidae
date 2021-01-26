namespace Domain.Model
{
    public sealed class Stage
    {
        private Cell[,] _cells;

        public Stage(Cell[,] cells)
        {
            _cells = cells;
        }

        public Cell[,] GetCells()
        {
            return _cells;
        }
    }
}