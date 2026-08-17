namespace tomodachi.Engine
{
    public readonly struct SpriteFrame
    {
        public int Row { get; }
        public int Column { get; }

        public SpriteFrame(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}