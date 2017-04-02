using System.Runtime.InteropServices;
using Core.Shogi.BitVersion;
using Xunit;

namespace Core.Shogi.Tests.BitVersion
{
    public class BitboardStateRowShould
    {
        [Fact]
        public void UseOnly2BytesOfMemory()
        {
            var expectedSizeInBytes = 2;
            var actualSizeInBytes = Marshal.SizeOf<BitboardStateRow>();

            Assert.Equal(expectedSizeInBytes, actualSizeInBytes);
        }

        [Fact]
        public void NotAllowValuesGreaterThan511()
        {
            BitboardStateRow stateRow = new BitboardStateRow(0x200);
            ushort expected = 0;

            Assert.Equal(expected, stateRow.Value);
        }

        [Fact]
        public void CastImplicitlyFromString10000()
        {
            BitboardStateRow stateRow = "000010000";
            ushort expected = 1 << 4;

            Assert.Equal(expected, stateRow.Value);
        }

        [Fact]
        public void BeAbleToFlipBits()
        {
            BitboardStateRow expectedStateRow = "011111111";
            BitboardStateRow stateRow = "100000000";

            var actualStateRow = ~stateRow;

            Assert.Equal(expectedStateRow, actualStateRow);
        }
    }
}
