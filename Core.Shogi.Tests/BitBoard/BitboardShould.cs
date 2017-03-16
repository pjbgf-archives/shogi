using System.Runtime.InteropServices;
using Xunit;
// ReSharper disable InconsistentNaming

namespace Core.Shogi.Tests.BitBoard
{
    
    public class BitboardShould
    {
        [Fact]
        public void UseOnly18BytesOfMemory()
        {
            var expectedSizeInBytes = 18;
            var actualSizeInBytes = Marshal.SizeOf<Bitboard>();

            Assert.Equal(expectedSizeInBytes, actualSizeInBytes);
        }

        [Fact]
        public void SupportBinaryXORBetweenTwoStates()
        {
            var state1 = new Bitboard(
                                            "100000000",
                                            "000000000",
                                            "000000000",
                                            "000000000",
                                            "000010000",
                                            "000000000",
                                            "000000000",
                                            "000000000",
                                            "000000000");
            var state2 = new Bitboard(
                                            "000000001",
                                            "000000000",
                                            "000000000",
                                            "000000000",
                                            "000010000",
                                            "000000000",
                                            "000000000",
                                            "000000000",
                                            "000000000");
            var expectedState = new Bitboard(
                                            "100000001",
                                            "000000000",
                                            "000000000",
                                            "000000000",
                                            "000000000",
                                            "000000000",
                                            "000000000",
                                            "000000000",
                                            "000000000");

            var state3 = state1 ^ state2;

            Assert.Equal(expectedState.RowE.Value, state3.RowE.Value);
        }

        [Fact]
        public void SupportBinaryANDBetweentwoStates()
        {
            var state1 = new Bitboard(
                                            "100000000",
                                            "000000000",
                                            "000000000",
                                            "000000000",
                                            "000010000",
                                            "000000000",
                                            "000000000",
                                            "000000000",
                                            "000000000");
            var state2 = new Bitboard(
                                            "000000001",
                                            "000000000",
                                            "000000000",
                                            "000000000",
                                            "000010000",
                                            "000000000",
                                            "000000000",
                                            "000000000",
                                            "000000000");
            var expectedState = new Bitboard(
                                            "000000000",
                                            "000000000",
                                            "000000000",
                                            "000000000",
                                            "000010000",
                                            "000000000",
                                            "000000000",
                                            "000000000",
                                            "000000000");

            var state3 = state1 & state2;

            Assert.Equal(expectedState.RowE.Value, state3.RowE.Value);
        }
    }
}