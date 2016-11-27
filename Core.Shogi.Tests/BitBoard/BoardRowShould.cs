using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using NUnit.Framework;

namespace Core.Shogi.Tests.BitBoard
{
    [TestFixture]
    [SuppressMessage("ReSharper", "ObjectCreationAsStatement")]
    public class BoardRowShould
    {
        [Test]
        public void UseOnly2BytesOfMemory()
        {
            var expectedSizeInBytes = 2;
            var actualSizeInBytes = Marshal.SizeOf<BitboardRow>();

            Assert.AreEqual(expectedSizeInBytes, actualSizeInBytes);
        }

        [Test]
        public void NotAllowValuesGreaterThan511()
        {
            BitboardRow row = new BitboardRow(0x200);
            ushort expected = BitboardRow.MaxValue;

            Assert.AreEqual(expected, row.Value);
        }

        [Test]
        public void CastImplicitlyFromString10000()
        {
            BitboardRow row = "000010000";
            ushort expected = 1 << 4;

            Assert.AreEqual(expected, row.Value);
        }
    }
}
