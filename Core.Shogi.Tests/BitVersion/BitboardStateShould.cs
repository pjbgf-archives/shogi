using System;
using System.Runtime.InteropServices;
using Core.Shogi.BitVersion;
using Xunit;

namespace Core.Shogi.Tests.BitVersion
{
    
    public class BitboardStateShould
    {
        [Fact]
        public void UseOnly18BytesOfMemoryToHoldBoardState()
        {
            var expectedSizeInBytes = 18;
            var actualSizeInBytes = Marshal.SizeOf<BitboardState>();

            Assert.Equal(expectedSizeInBytes, actualSizeInBytes);
        }

        [Fact]
        public void SupportXorBinaryBetweenTwoBitboardStates()
        {
            var state1 = new BitboardState(        0x100, 0x0, 0x0, 0x0,    0x0, 0x0, 0x0, 0x0, 0x0);
            var state2 = new BitboardState(        0x001, 0x0, 0x0, 0x0, 1 << 4, 0x0, 0x0, 0x0, 0x0);
            var expectedState = new BitboardState( 0x101, 0x0, 0x0, 0x0, 1 << 4, 0x0, 0x0, 0x0, 0x0);

            var actualState = state1 ^ state2;

            Assert.Equal(expectedState, actualState);
        }

        [Fact]
        public void SupportAndBinaryBetweentwoBitboardStates()
        {
            var state1 = new BitboardState(    1 << 8, 0x0, 0x0, 0x0, 1 << 4, 0x0, 0x0, 0x0, 0x0);
            var state2 = new BitboardState(         1, 0x0, 0x0, 0x0, 1 << 4, 0x0, 0x0, 0x0, 0x0);
            var expectedState = new BitboardState(0x0, 0x0, 0x0, 0x0, 1 << 4, 0x0, 0x0, 0x0, 0x0);

            var actualState = state1 & state2;

            Assert.Equal(expectedState, actualState);
        }

        [Fact]
        public void ThrowIndexOutOfRangeExceptionForIndexesBelow0()
        {
            var state = new BitboardState(0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0);

            Assert.Throws<IndexOutOfRangeException>(() => state[-1]);
        }

        [Fact]
        public void ThrowIndexOutOfRangeExceptionForIndexesGreaterThan80()
        {
            var state = new BitboardState(0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0);

            Assert.Throws<IndexOutOfRangeException>(() => state[81]);
        }

        [Fact]
        public void GetBitBasedOnIndexedProperty()
        {
            var state = new BitboardState(1 << 8, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0);

            Assert.True(state[0]);
        }
    }
}