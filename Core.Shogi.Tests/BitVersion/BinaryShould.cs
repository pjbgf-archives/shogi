using Core.Shogi.BitVersion;
using Xunit;

namespace Core.Shogi.Tests.BitVersion
{
    public class BinaryShould
    {
        [Fact]
        public void CastImplicitlyFromString0001()
        {
            BitboardStateRow stateRow = "0001";
            ushort expected = 1;

            Assert.Equal(expected, stateRow.Value);
        }

        [Fact]
        public void CastImplicitlyFromString0010()
        {
            BitboardStateRow stateRow = "0010";
            ushort expected = 2;

            Assert.Equal(expected, stateRow.Value);
        }
    }
}