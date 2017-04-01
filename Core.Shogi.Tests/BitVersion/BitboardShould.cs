using System;
using System.Runtime.InteropServices;
using Core.Shogi.BitVersion;
using Xunit;

namespace Core.Shogi.Tests.BitVersion
{
    
    public class BitboardShould
    {
        [Fact]
        public void UseOnly18BytesOfMemoryToHoldBoardState()
        {
            var expectedSizeInBytes = 18;
            var actualSizeInBytes = Marshal.SizeOf<Bitboard>();

            Assert.Equal(expectedSizeInBytes, actualSizeInBytes);
        }

        [Fact]
        public void SupportXorBinaryBetweenTwoBitboardStates()
        {
            var state1 = new Bitboard(        0x100, 0x0, 0x0, 0x0,    0x0, 0x0, 0x0, 0x0, 0x0);
            var state2 = new Bitboard(        0x001, 0x0, 0x0, 0x0, 1 << 4, 0x0, 0x0, 0x0, 0x0);
            var expectedState = new Bitboard( 0x101, 0x0, 0x0, 0x0, 1 << 4, 0x0, 0x0, 0x0, 0x0);

            var actualState = state1 ^ state2;

            Assert.Equal(expectedState, actualState);
        }

        [Fact]
        public void SupportAndBinaryBetweentwoBitboardStates()
        {
            var state1 = new Bitboard(    1 << 8, 0x0, 0x0, 0x0, 1 << 4, 0x0, 0x0, 0x0, 0x0);
            var state2 = new Bitboard(         1, 0x0, 0x0, 0x0, 1 << 4, 0x0, 0x0, 0x0, 0x0);
            var expectedState = new Bitboard(0x0, 0x0, 0x0, 0x0, 1 << 4, 0x0, 0x0, 0x0, 0x0);

            var actualState = state1 & state2;

            Assert.Equal(expectedState, actualState);
        }

        [Fact]
        public void ThrowIndexOutOfRangeExceptionForIndexesBelow0()
        {
            var state = new Bitboard(0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0);

            Assert.Throws<IndexOutOfRangeException>(() => state[-1]);
        }

        [Fact]
        public void ThrowIndexOutOfRangeExceptionForIndexesGreaterThan80()
        {
            var state = new Bitboard(0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0);

            Assert.Throws<IndexOutOfRangeException>(() => state[81]);
        }

        [Fact]
        public void GetBitBasedOnIndexedProperty()
        {
            var state = new Bitboard(1 << 8, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0);

            Assert.True(state[0]);
        }
    }
}