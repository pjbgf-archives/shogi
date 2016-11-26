using System;

namespace Core.Shogi.BitBoard
{
    public struct BoardRow
    {
        public static readonly ushort MinValue = 0x0;
        public static readonly ushort MaxValue = 0x1FF;

        public ushort Value { get; }

        public BoardRow(ushort value)
        {
            if (value > MaxValue)
                throw new ArgumentOutOfRangeException();

            Value = value;
        }
    }
}