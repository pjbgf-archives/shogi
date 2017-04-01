using System.Runtime.InteropServices;
using Core.Shogi.BitVersion;
using Xunit;

namespace Core.Shogi.Tests.BitVersion
{
    public class BoardRowShould
    {
        [Fact]
        public void UseOnly2BytesOfMemory()
        {
            var expectedSizeInBytes = 2;
            var actualSizeInBytes = Marshal.SizeOf<BitboardRow>();

            Assert.Equal(expectedSizeInBytes, actualSizeInBytes);
        }

        [Fact]
        public void NotAllowValuesGreaterThan511()
        {
            BitboardRow row = new BitboardRow(0x200);
            ushort expected = BitboardRow.MaxValue;

            Assert.Equal(expected, row.Value);
        }

        [Fact]
        public void CastImplicitlyFromString10000()
        {
            BitboardRow row = "000010000";
            ushort expected = 1 << 4;

            Assert.Equal(expected, row.Value);
        }
    }
}
