using Core.Shogi.BitVersion;
using Xunit;

namespace Core.Shogi.Tests.BitVersion
{
    public class BinaryShould
    {
        [Fact]
        public void CastImplicitlyFromString0001()
        {
            BitboardRow row = "0001";
            ushort expected = 1;

            Assert.Equal(expected, row.Value);
        }

        [Fact]
        public void CastImplicitlyFromString0010()
        {
            BitboardRow row = "0010";
            ushort expected = 2;

            Assert.Equal(expected, row.Value);
        }
    }
}