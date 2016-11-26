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

        public static implicit operator BoardRow(string boardRow)
        {
            var rowState = ConvertFromBinaryString(boardRow);
            return new BoardRow(rowState);
        }

        static ushort ConvertFromBinaryString(string binary)
        {
            ushort value = 0;

            if (Regex.IsMatch(binary, "^(0|1)+$", RegexOptions.Compiled | RegexOptions.Singleline))
            {
                var pow = binary.Length - 1;
                for (var i = 0; i < binary.Length; i++, pow--)
                    if (binary[i] == '1')
                        value += Convert.ToUInt16(Math.Pow(2, pow));
            }

            return value;
        }
    }
}