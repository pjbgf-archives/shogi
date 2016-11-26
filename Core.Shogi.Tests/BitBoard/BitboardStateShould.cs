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
        public void BeAbleToXORtwoStates()
        {
            var state1 = new BitboardState();// rowE: "000010000" );
            var state2 = new BitboardState();
            var expectedState = new BitboardState();

            var state3 = state1 & state2;

            Assert.AreEqual(expectedState, state3);
        }
    }
}