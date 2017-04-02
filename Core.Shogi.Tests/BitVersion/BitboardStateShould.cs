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
            var state1 = new BitboardState(        0x100, HexValues.EmptyRow, HexValues.EmptyRow, HexValues.EmptyRow,    HexValues.EmptyRow, HexValues.EmptyRow, HexValues.EmptyRow, HexValues.EmptyRow, HexValues.EmptyRow);
            var state2 = new BitboardState(        0x1, HexValues.EmptyRow, HexValues.EmptyRow, HexValues.EmptyRow, 1 << 4, HexValues.EmptyRow, HexValues.EmptyRow, HexValues.EmptyRow, HexValues.EmptyRow);
            var expectedState = new BitboardState( 0x101, HexValues.EmptyRow, HexValues.EmptyRow, HexValues.EmptyRow, 1 << 4, HexValues.EmptyRow, HexValues.EmptyRow, HexValues.EmptyRow, HexValues.EmptyRow);

            var actualState = state1 ^ state2;

            Assert.Equal(expectedState, actualState);
        }

        [Fact]
        public void SupportAndBinaryBetweentwoBitboardStates()
        {
            var state1 = new BitboardState(    1 << 8, HexValues.EmptyRow, HexValues.EmptyRow, HexValues.EmptyRow, 1 << 4, HexValues.EmptyRow, HexValues.EmptyRow, HexValues.EmptyRow, HexValues.EmptyRow);
            var state2 = new BitboardState(         1, HexValues.EmptyRow, HexValues.EmptyRow, HexValues.EmptyRow, 1 << 4, HexValues.EmptyRow, HexValues.EmptyRow, HexValues.EmptyRow, HexValues.EmptyRow);
            var expectedState = new BitboardState(HexValues.EmptyRow, HexValues.EmptyRow, HexValues.EmptyRow, HexValues.EmptyRow, 1 << 4, HexValues.EmptyRow, HexValues.EmptyRow, HexValues.EmptyRow, HexValues.EmptyRow);

            var actualState = state1 & state2;

            Assert.Equal(expectedState, actualState);
        }

        [Fact]
        public void ThrowIndexOutOfRangeExceptionForIndexesBelow0()
        {
            var state = new BitboardState(HexValues.EmptyRow, HexValues.EmptyRow, HexValues.EmptyRow, HexValues.EmptyRow, HexValues.EmptyRow, HexValues.EmptyRow, HexValues.EmptyRow, HexValues.EmptyRow, HexValues.EmptyRow);

            Assert.Throws<IndexOutOfRangeException>(() => state[-1]);
        }

        [Fact]
        public void ThrowIndexOutOfRangeExceptionForIndexesGreaterThan80()
        {
            var state = new BitboardState(HexValues.EmptyRow, HexValues.EmptyRow, HexValues.EmptyRow, HexValues.EmptyRow, HexValues.EmptyRow, HexValues.EmptyRow, HexValues.EmptyRow, HexValues.EmptyRow, HexValues.EmptyRow);

            Assert.Throws<IndexOutOfRangeException>(() => state[81]);
        }

        [Fact]
        public void GetBitBasedOnIndexedProperty()
        {
            var state = new BitboardState(1 << 8, HexValues.EmptyRow, HexValues.EmptyRow, HexValues.EmptyRow, HexValues.EmptyRow, HexValues.EmptyRow, HexValues.EmptyRow, HexValues.EmptyRow, HexValues.EmptyRow);

            Assert.True(state[0]);
        }
    }
}