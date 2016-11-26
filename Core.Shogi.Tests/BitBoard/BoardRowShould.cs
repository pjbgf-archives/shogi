using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Core.Shogi.BitBoard;
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
            var actualSizeInBytes = Marshal.SizeOf<BoardRow>();

            Assert.AreEqual(expectedSizeInBytes, actualSizeInBytes);
        }

        [Test]
        public void NotAllowValuesGreaterThan511()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => new BoardRow(0x200) // 512
            );
        }

        [Test]
        public void CastImplicitlyFromString10000()
        {
            BoardRow row = "000010000";
            ushort expected = 1 << 4;

            Assert.AreEqual(expected, row.Value);
        }
    }
}
