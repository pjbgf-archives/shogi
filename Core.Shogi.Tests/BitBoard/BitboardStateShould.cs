using System.Runtime.InteropServices;
using Core.Shogi.BitBoard;
using NUnit.Framework;
// ReSharper disable InconsistentNaming

namespace Core.Shogi.Tests.BitBoard
{
    [TestFixture]
    public class BitboardStateShould
    {
        [Test]
        public void UseOnly18BytesOfMemory()
        {
            var expectedSizeInBytes = 18;
            var actualSizeInBytes = Marshal.SizeOf<BitboardState>();

            Assert.AreEqual(expectedSizeInBytes, actualSizeInBytes);
        }

        [Test]
        public void SupportBinaryXORBetweenTwoStates()
        {
            var state1 = new BitboardState(
                                            "100000000",
                                            "000000000",
                                            "000000000",
                                            "000000000",
                                            "000010000",
                                            "000000000",
                                            "000000000",
                                            "000000000",
                                            "000000000");
            var state2 = new BitboardState(
                                            "000000001",
                                            "000000000",
                                            "000000000",
                                            "000000000",
                                            "000010000",
                                            "000000000",
                                            "000000000",
                                            "000000000",
                                            "000000000");
            var expectedState = new BitboardState(
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

            Assert.AreEqual(expectedState.RowE.Value, state3.RowE.Value);
        }

        [Test]
        public void SupportBinaryANDBetweentwoStates()
        {
            var state1 = new BitboardState(
                                            "100000000",
                                            "000000000",
                                            "000000000",
                                            "000000000",
                                            "000010000",
                                            "000000000",
                                            "000000000",
                                            "000000000",
                                            "000000000");
            var state2 = new BitboardState(
                                            "000000001",
                                            "000000000",
                                            "000000000",
                                            "000000000",
                                            "000010000",
                                            "000000000",
                                            "000000000",
                                            "000000000",
                                            "000000000");
            var expectedState = new BitboardState(
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

            Assert.AreEqual(expectedState.RowE.Value, state3.RowE.Value);
        }
    }
}