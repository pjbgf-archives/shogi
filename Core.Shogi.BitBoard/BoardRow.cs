using System;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace Core.Shogi.BitBoard
{
    public struct BoardRow
    {
        public static readonly ushort MinValue = 0;
        public static readonly ushort MaxValue = 0x1FF;
        public static readonly BoardRow Empty = new BoardRow(MinValue);

        public ushort Value { get; }

        public BoardRow(ushort value)
        {
            if (value > MaxValue)
                throw new ArgumentOutOfRangeException();

            Value = value;
        }

        public static BoardRow operator &(BoardRow row1, BoardRow row2)
        {
            var newValue = (ushort)(row1.Value & row2.Value);
            return new BoardRow(newValue);
        }

        public static BoardRow operator ^(BoardRow row1, BoardRow row2)
        {
            var newValue = (ushort)(row1.Value ^ row2.Value);
            return new BoardRow(newValue);
        }

        public static implicit operator BoardRow(string boardRow)
        {
            var rowState = Binary.ConvertToUInt16(boardRow);
            return new BoardRow(rowState);
        }
    }
}