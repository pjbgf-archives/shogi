namespace Core.Shogi.BitVersion
{
    public static class BinaryValues
    {
        public const int EmptyRow =    0b000_000_000;
        public const int FullRow  =    0b111_111_111;
        public const int TwoPieceRow = 0b010_000_010;
    }
}