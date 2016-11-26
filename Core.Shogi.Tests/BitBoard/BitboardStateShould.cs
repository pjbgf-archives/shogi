using System.Runtime.InteropServices;
using Core.Shogi.BitBoard;
using NUnit.Framework;

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
    }
}