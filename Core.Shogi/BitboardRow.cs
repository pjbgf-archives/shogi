using System;

namespace Core.Shogi
{
    public struct BitboardRow
    {
        public static readonly ushort MinValue = 0;
        public static readonly ushort MaxValue = 0x1FF;
        public static readonly BitboardRow Empty = new BitboardRow(MinValue);

        public ushort Value { get; }

        public BitboardRow(ushort value)
        {
            if (value > MaxValue)
                value = MaxValue;

            Value = value;
        }

        public static BitboardRow operator &(BitboardRow row1, BitboardRow row2)
        {
            var newValue = (ushort) (row1.Value & row2.Value);
            return new BitboardRow(newValue);
        }

        public static BitboardRow operator ^(BitboardRow row1, BitboardRow row2)
        {
            var newValue = (ushort)(row1.Value ^ row2.Value);
            return new BitboardRow(newValue);
        }

        public static BitboardRow operator ~(BitboardRow row)
        {
            return new BitboardRow((ushort)~row.Value);
        }

        public static implicit operator BitboardRow(string boardRow)
        {
            var rowState = Binary.ConvertToUInt16(boardRow);
            return new BitboardRow(rowState);
        }

        public static implicit operator BitboardRow(ushort row)
        {
            return new BitboardRow(row);
        }

        public bool this[int index]
        {
            get
            {
                var value = (ushort)Math.Pow(2, 8 - index);
                return (value == Value);
            }
        }
    }
}