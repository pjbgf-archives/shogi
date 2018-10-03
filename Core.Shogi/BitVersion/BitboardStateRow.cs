using System;

namespace Core.Shogi.BitVersion
{
    public struct BitboardStateRow
    {
        public static readonly ushort MinValue = 0;
        public static readonly ushort MaxValue = BinaryValues.FullRow;
        public static readonly BitboardStateRow Empty = new BitboardStateRow(MinValue);
        private readonly ushort _value;

        public ushort Value => _value;

        public BitboardStateRow(ushort value)
        {
            var maxValue = value & MaxValue;
            _value = (ushort)maxValue;
        }

        public static BitboardStateRow operator &(BitboardStateRow row1, BitboardStateRow row2)
        {
            var newValue = (ushort) (row1.Value & row2.Value);
            return new BitboardStateRow(newValue);
        }

        public static BitboardStateRow operator ^(BitboardStateRow row1, BitboardStateRow row2)
        {
            var newValue = (ushort)(row1.Value ^ row2.Value);
            return new BitboardStateRow(newValue);
        }

        public static bool operator ==(BitboardStateRow row1, BitboardStateRow row2)
        {
            return row1.Value == row2.Value;
        }

        public static bool operator !=(BitboardStateRow row1, BitboardStateRow row2)
        {
            return row1.Value != row2.Value;
        }

        public static BitboardStateRow operator ~(BitboardStateRow stateRow)
        {
            return new BitboardStateRow((ushort)~stateRow.Value);
        }

        public static implicit operator BitboardStateRow(string boardRow)
        {
            if (string.IsNullOrEmpty(boardRow))
                return Empty;

            var rowState = Binary.ConvertToUInt16(boardRow);
            return new BitboardStateRow(rowState);
        }

        public static implicit operator BitboardStateRow(ushort row)
        {
            return new BitboardStateRow(row);
        }

        public bool this[int index]
        {
            get
            {
                var value = (ushort)Math.Pow(2, 8 - index);
                return (value == Value);
            }
        }

        public override string ToString()
        {
            return $"0x{Value:X}";
        }

        public override bool Equals(object obj)
        {
            BitboardStateRow row = (BitboardStateRow)obj;
            
            if (row == null)
                return false;

            return (this.Value == row.Value);
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }
    }
}